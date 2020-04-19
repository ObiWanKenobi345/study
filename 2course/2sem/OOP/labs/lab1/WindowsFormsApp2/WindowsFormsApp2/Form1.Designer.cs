namespace WindowsFormsApp2
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
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.CollectionTextBox = new System.Windows.Forms.TextBox();
            this.newTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(394, 48);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(153, 22);
            this.SizeTextBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 79);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сортировать по возрастанию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SortVozrButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(322, 80);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сгенерировать коллекцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(765, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 79);
            this.button3.TabIndex = 6;
            this.button3.Text = "Сортировать по убыванию";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SortUbButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 280);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 77);
            this.button4.TabIndex = 7;
            this.button4.Text = "Минимальный элемент";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.MinElemButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(417, 280);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 77);
            this.button5.TabIndex = 8;
            this.button5.Text = "Максимальный элемент";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.MaxElemButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(686, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 77);
            this.button6.TabIndex = 9;
            this.button6.Text = "Сумма элементов";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.SumElem_Click);
            // 
            // CollectionTextBox
            // 
            this.CollectionTextBox.Location = new System.Drawing.Point(46, 402);
            this.CollectionTextBox.Multiline = true;
            this.CollectionTextBox.Name = "CollectionTextBox";
            this.CollectionTextBox.Size = new System.Drawing.Size(353, 257);
            this.CollectionTextBox.TabIndex = 10;
            // 
            // newTextBox
            // 
            this.newTextBox.Location = new System.Drawing.Point(565, 402);
            this.newTextBox.Multiline = true;
            this.newTextBox.Name = "newTextBox";
            this.newTextBox.Size = new System.Drawing.Size(353, 257);
            this.newTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Размер коллекции";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 671);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newTextBox);
            this.Controls.Add(this.CollectionTextBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SizeTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox CollectionTextBox;
        private System.Windows.Forms.TextBox newTextBox;
        private System.Windows.Forms.Label label1;
    }
}

