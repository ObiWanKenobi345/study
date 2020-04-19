using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PATH_LAST_FILES = "LF.txt";
        public MainWindow()
        {
            InitializeComponent();
            docBox.Visibility = Visibility.Hidden;
            this.AllowDrop = true;
            symbols.Text = "";
            PrintLastFiles();
        }
        private async void PrintLastFiles() 
        {
            string[] files = await ReadLastFiles();
            foreach (string item in files)
            {
                LastFiles.Items.Add(item);
            }
            LastFiles.MouseDoubleClick += (sender, args) =>
            {
                string path = LastFiles.SelectedItem.ToString();
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    doc.Load(fs, DataFormats.Text);
                }
            };
        }
        private async Task<string[]> ReadLastFiles()
        {
            string[] strs;
            string stroke;
            using(StreamReader sr = new StreamReader(PATH_LAST_FILES))
            {
                stroke = await sr.ReadToEndAsync();
            }
            strs = stroke.Split('$');
            string[] result = new string[strs.Length];
            int count = 0;
            foreach(string item in strs)
            {
                result[count] = item.Replace("\r\n", "");
                count++;
            }
            return result;
        }
        private async void AddLastFiles(string path)
        {
            using(StreamWriter sw = new StreamWriter(PATH_LAST_FILES, true))
            {
                await sw.WriteLineAsync(path + "$");
            }
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (docBox.Visibility == Visibility.Hidden)
            {
                docBox.Visibility = Visibility.Visible;
            }
            
            docBox.Document.Blocks.Clear();
            docBox.AllowDrop = true;
            docBox.Focus();
            symbols.Text = "0";

            UserControl1 uc1 = new UserControl1();
            MyMenu.Items.Add(uc1);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";

            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
            AddLastFiles(ofd.FileName);
        }
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            docBox.Copy();
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            docBox.Paste();
        }
        private void FontType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var fontName = FontType.SelectedItem;

                if (fontName != null)
                {
                    docBox.Selection.ApplyPropertyValue(FontFamilyProperty, fontName);
                    docBox.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            docBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            docBox.Focus();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            docBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            docBox.Focus();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            docBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            docBox.Focus();
        }
        private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int fontSize = FontSize.SelectedIndex;
                switch (fontSize)
                {
                    case 0: fontSize = 10; break;
                    case 1: fontSize = 14; break;
                    case 2: fontSize = 16; break;
                    case 3: fontSize = 18; break;
                    case 4: fontSize = 20; break;
                    case 5: fontSize = 22; break;
                    case 6: fontSize = 24; break;
                }
                
                docBox.Selection.ApplyPropertyValue(FontSizeProperty, $"{fontSize}");
                docBox.Focus();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Russia_Click(object sender, RoutedEventArgs e)
        {
            //this.Resources["aquaStyle"] = new SolidColorBrush(Colors.AliceBlue);
            file.Header = "Файл";
            New.Header = "Создать";
            Save.Header = "Сохранить";
            Open.Header = "Открыть";
            Edit.Header = "Изменить";
            Copy.Header = "Копировать";
            Paste.Header = "Вставить";
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            //this.Resources["aquaStyle"] = new SolidColorBrush(Colors.LimeGreen);
            file.Header = "File";
            New.Header = "New";
            Save.Header = "Save";
            Open.Header = "Open";
            Edit.Header = "Edit";
            Copy.Header = "Copy";
            Paste.Header = "Paste";
        }
        private void docBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd).Text;
            int count = str.Length - 2;
            symbols.Text = count.ToString();           
        }
        private void docBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            var path = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            if (path == null) return;
            using (FileStream rd = new FileStream(path[0], FileMode.Open))
            {
                TextRange range = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                range.Load(rd, DataFormats.Text);
                Title = path[0];
            }
            AddLastFiles(path[0]);
        }
        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Theme.SelectedIndex == 0)
                {
                    // определяем путь к файлу ресурсов
                    var uri = new Uri("dark.xaml", UriKind.Relative);
                    // загружаем словарь ресурсов
                    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                    // очищаем коллекцию ресурсов приложения
                    Application.Current.Resources.Clear();
                    // добавляем загруженный словарь ресурсов
                    Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                }
                else if (Theme.SelectedIndex == 1)
                {
                    var uri = new Uri("light.xaml", UriKind.Relative);
                    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
