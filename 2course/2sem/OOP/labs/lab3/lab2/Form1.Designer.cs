namespace lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.ModelComboBox = new System.Windows.Forms.ComboBox();
            this.TeamListBox = new System.Windows.Forms.ListBox();
            this.PlacesTextBox = new System.Windows.Forms.TextBox();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ClearButton1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TypeSearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.PlacesSearchButton = new System.Windows.Forms.Button();
            this.CapacitySearchButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.NameSortButton = new System.Windows.Forms.Button();
            this.IdSearchButton = new System.Windows.Forms.Button();
            this.YearSearchButton = new System.Windows.Forms.Button();
            this.ClearButton2 = new System.Windows.Forms.Button();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(174, 14);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 22);
            this.IdTextBox.TabIndex = 0;
            this.IdTextBox.TextChanged += new System.EventHandler(this.IdTextBox_TextChanged);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(153, 57);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.TypeComboBox.TabIndex = 1;
            // 
            // ModelComboBox
            // 
            this.ModelComboBox.FormattingEnabled = true;
            this.ModelComboBox.Location = new System.Drawing.Point(153, 97);
            this.ModelComboBox.Name = "ModelComboBox";
            this.ModelComboBox.Size = new System.Drawing.Size(121, 24);
            this.ModelComboBox.TabIndex = 2;
            // 
            // TeamListBox
            // 
            this.TeamListBox.FormattingEnabled = true;
            this.TeamListBox.ItemHeight = 16;
            this.TeamListBox.Location = new System.Drawing.Point(153, 137);
            this.TeamListBox.Name = "TeamListBox";
            this.TeamListBox.Size = new System.Drawing.Size(323, 84);
            this.TeamListBox.TabIndex = 3;
            // 
            // PlacesTextBox
            // 
            this.PlacesTextBox.Location = new System.Drawing.Point(174, 245);
            this.PlacesTextBox.Name = "PlacesTextBox";
            this.PlacesTextBox.Size = new System.Drawing.Size(100, 22);
            this.PlacesTextBox.TabIndex = 4;
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(174, 303);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(100, 22);
            this.YearTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "модель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "члены \r\nэкипажа";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "кол-во мест";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "год выпуска";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "грузоподъёмность";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 34);
            this.label8.TabIndex = 15;
            this.label8.Text = "дата последнего \r\nтех. обслуживания";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(174, 373);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 56);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(433, 243);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(131, 42);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(589, 243);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(131, 42);
            this.UploadButton.TabIndex = 19;
            this.UploadButton.Text = "Загрузить";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(280, 291);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(440, 250);
            this.infoBox.TabIndex = 20;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(498, 14);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(196, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(51, 643);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 20);
            this.toolStripLabel1.Text = "About";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // ClearButton1
            // 
            this.ClearButton1.Location = new System.Drawing.Point(281, 547);
            this.ClearButton1.Name = "ClearButton1";
            this.ClearButton1.Size = new System.Drawing.Size(131, 42);
            this.ClearButton1.TabIndex = 25;
            this.ClearButton1.Text = "Очистить";
            this.ClearButton1.UseVisualStyleBackColor = true;
            this.ClearButton1.Click += new System.EventHandler(this.ClearButton1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(841, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Поиск";
            // 
            // TypeSearchButton
            // 
            this.TypeSearchButton.Location = new System.Drawing.Point(775, 68);
            this.TypeSearchButton.Name = "TypeSearchButton";
            this.TypeSearchButton.Size = new System.Drawing.Size(98, 30);
            this.TypeSearchButton.TabIndex = 27;
            this.TypeSearchButton.Text = "по типу";
            this.TypeSearchButton.UseVisualStyleBackColor = true;
            this.TypeSearchButton.Click += new System.EventHandler(this.TypeSearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(775, 39);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(276, 22);
            this.SearchTextBox.TabIndex = 28;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // PlacesSearchButton
            // 
            this.PlacesSearchButton.Location = new System.Drawing.Point(879, 68);
            this.PlacesSearchButton.Name = "PlacesSearchButton";
            this.PlacesSearchButton.Size = new System.Drawing.Size(172, 30);
            this.PlacesSearchButton.TabIndex = 30;
            this.PlacesSearchButton.Text = "по кол-ву мест";
            this.PlacesSearchButton.UseVisualStyleBackColor = true;
            this.PlacesSearchButton.Click += new System.EventHandler(this.PlacesSearchButton_Click);
            // 
            // CapacitySearchButton
            // 
            this.CapacitySearchButton.Location = new System.Drawing.Point(822, 104);
            this.CapacitySearchButton.Name = "CapacitySearchButton";
            this.CapacitySearchButton.Size = new System.Drawing.Size(172, 30);
            this.CapacitySearchButton.TabIndex = 31;
            this.CapacitySearchButton.Text = "по грузоподъемности";
            this.CapacitySearchButton.UseVisualStyleBackColor = true;
            this.CapacitySearchButton.Click += new System.EventHandler(this.CapacitySearchButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(841, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 32;
            this.label11.Text = "Сортировка";
            // 
            // NameSortButton
            // 
            this.NameSortButton.Location = new System.Drawing.Point(775, 185);
            this.NameSortButton.Name = "NameSortButton";
            this.NameSortButton.Size = new System.Drawing.Size(98, 30);
            this.NameSortButton.TabIndex = 33;
            this.NameSortButton.Text = "по модели";
            this.NameSortButton.UseVisualStyleBackColor = true;
            this.NameSortButton.Click += new System.EventHandler(this.NameSortButton_Click);
            // 
            // IdSearchButton
            // 
            this.IdSearchButton.Location = new System.Drawing.Point(879, 185);
            this.IdSearchButton.Name = "IdSearchButton";
            this.IdSearchButton.Size = new System.Drawing.Size(80, 30);
            this.IdSearchButton.TabIndex = 34;
            this.IdSearchButton.Text = "по Id";
            this.IdSearchButton.UseVisualStyleBackColor = true;
            this.IdSearchButton.Click += new System.EventHandler(this.IdSearchButton_Click);
            // 
            // YearSearchButton
            // 
            this.YearSearchButton.Location = new System.Drawing.Point(968, 185);
            this.YearSearchButton.Name = "YearSearchButton";
            this.YearSearchButton.Size = new System.Drawing.Size(83, 30);
            this.YearSearchButton.TabIndex = 35;
            this.YearSearchButton.Text = "по году";
            this.YearSearchButton.UseVisualStyleBackColor = true;
            this.YearSearchButton.Click += new System.EventHandler(this.YearSearchButton_Click);
            // 
            // ClearButton2
            // 
            this.ClearButton2.Location = new System.Drawing.Point(750, 524);
            this.ClearButton2.Name = "ClearButton2";
            this.ClearButton2.Size = new System.Drawing.Size(104, 78);
            this.ClearButton2.TabIndex = 37;
            this.ClearButton2.Text = "Очистить";
            this.ClearButton2.UseVisualStyleBackColor = true;
            this.ClearButton2.Click += new System.EventHandler(this.ClearButton2_Click);
            // 
            // ResultListView
            // 
            this.ResultListView.Location = new System.Drawing.Point(750, 234);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(385, 269);
            this.ResultListView.TabIndex = 38;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.SelectedIndexChanged += new System.EventHandler(this.ResultListView_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(863, 525);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 78);
            this.button2.TabIndex = 39;
            this.button2.Text = "Сохранить результат поиска";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 643);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.ClearButton2);
            this.Controls.Add(this.YearSearchButton);
            this.Controls.Add(this.IdSearchButton);
            this.Controls.Add(this.NameSortButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CapacitySearchButton);
            this.Controls.Add(this.PlacesSearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.TypeSearchButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ClearButton1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.PlacesTextBox);
            this.Controls.Add(this.TeamListBox);
            this.Controls.Add(this.ModelComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.IdTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox ModelComboBox;
        private System.Windows.Forms.ListBox TeamListBox;
        private System.Windows.Forms.TextBox PlacesTextBox;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button ClearButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button TypeSearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button PlacesSearchButton;
        private System.Windows.Forms.Button CapacitySearchButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button NameSortButton;
        private System.Windows.Forms.Button IdSearchButton;
        private System.Windows.Forms.Button YearSearchButton;
        private System.Windows.Forms.Button ClearButton2;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.Button button2;
    }
}

