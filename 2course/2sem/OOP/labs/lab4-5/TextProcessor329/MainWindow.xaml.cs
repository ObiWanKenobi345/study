using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;

namespace TextProcessor329
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int docCount = 1;
        public MainWindow()
        {
            InitializeComponent();
          
            FontFamilyCB.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (ofDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(ofDialog.FileName, FileMode.Open);
                TextRange textRange = new TextRange(RchTxtBx.Document.ContentStart, RchTxtBx.Document.ContentEnd);
                textRange.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                FileName = Title,
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(RchTxtBx.Document.ContentStart, RchTxtBx.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void RchTxtBx_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = RchTxtBx.Selection.GetPropertyValue(Inline.FontWeightProperty);
            buttonBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = RchTxtBx.Selection.GetPropertyValue(Inline.FontStyleProperty);
            buttonItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = RchTxtBx.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            buttonUnderlined.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = RchTxtBx.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyCB.SelectedItem = temp;
            temp = RchTxtBx.Selection.GetPropertyValue(Inline.FontSizeProperty);
            
        }

        private void FontFamilyCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyCB.SelectedItem != null)
            {
                RchTxtBx.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyCB.SelectedItem);
            }
        }

        private void FontSizeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RchTxtBx.Selection.ApplyPropertyValue(Inline.FontSizeProperty, Font_Size.Value);
        }

        private void RchTxtBx_Drop(object sender, DragEventArgs e)
        {
            FileStream fileStream = new FileStream((string)e.Data.GetData(DataFormats.Text), FileMode.Create);
            TextRange textRange = new TextRange(RchTxtBx.Document.ContentStart, RchTxtBx.Document.ContentEnd);
            textRange.Load(fileStream, DataFormats.Rtf);
        }

        private void buttonNewFile_Click(object sender, RoutedEventArgs e)
        {
            docCount++;
            MainWindow window = new MainWindow
            {
                Title = "file"+docCount
            };
            window.Show();
        }

        private void Font_Size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (Font_Size.IsFocused && Font_Size.Value > 0)
                {
                    TextRange tr = new TextRange(RchTxtBx.Document.ContentStart, RchTxtBx.Document.ContentEnd);

                    tr.ApplyPropertyValue(FontSizeProperty, Font_Size.Value);
                }
                else if (Font_Size.Value == 0)
                {
                    MessageBox.Show("error: can't be zero");
                    Font_Size.Value = 12;
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void RchTxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbSymbols.Text =" Symbols: "+((new TextRange(RchTxtBx.Document.ContentStart, RchTxtBx.Document.ContentEnd)).Text.Length-2).ToString();
        }

        private void Font_Size_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip = Font_Size.Value.ToString();
        }

        private void Font_Size_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Font_Size.IsFocused)
            {
                ToolTip = Font_Size.Value.ToString();
            }
        }
    }
}
