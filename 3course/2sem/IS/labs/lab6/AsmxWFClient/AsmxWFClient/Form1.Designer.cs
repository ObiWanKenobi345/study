namespace AsmxWFClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.XTextBox = new System.Windows.Forms.TextBox();
            this.YTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.StringTextBox = new System.Windows.Forms.TextBox();
            this.GetStringButton = new System.Windows.Forms.Button();
            this.SetStringButton = new System.Windows.Forms.Button();
            this.IntTextBox = new System.Windows.Forms.TextBox();
            this.GetIntButton = new System.Windows.Forms.Button();
            this.SetIntButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // XTextBox
            // 
            this.XTextBox.Location = new System.Drawing.Point(44, 13);
            this.XTextBox.Name = "XTextBox";
            this.XTextBox.Size = new System.Drawing.Size(100, 20);
            this.XTextBox.TabIndex = 0;
            // 
            // YTextBox
            // 
            this.YTextBox.Location = new System.Drawing.Point(44, 40);
            this.YTextBox.Name = "YTextBox";
            this.YTextBox.Size = new System.Drawing.Size(100, 20);
            this.YTextBox.TabIndex = 1;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(44, 67);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 20);
            this.ResultTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Res.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.MinusButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "*";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.MulButton_Click);
            // 
            // StringTextBox
            // 
            this.StringTextBox.Location = new System.Drawing.Point(288, 13);
            this.StringTextBox.Name = "StringTextBox";
            this.StringTextBox.Size = new System.Drawing.Size(100, 20);
            this.StringTextBox.TabIndex = 9;
            // 
            // GetStringButton
            // 
            this.GetStringButton.Location = new System.Drawing.Point(288, 40);
            this.GetStringButton.Name = "GetStringButton";
            this.GetStringButton.Size = new System.Drawing.Size(100, 23);
            this.GetStringButton.TabIndex = 10;
            this.GetStringButton.Text = "Get String";
            this.GetStringButton.UseVisualStyleBackColor = true;
            this.GetStringButton.Click += new System.EventHandler(this.GetStringButton_Click);
            // 
            // SetStringButton
            // 
            this.SetStringButton.Location = new System.Drawing.Point(288, 67);
            this.SetStringButton.Name = "SetStringButton";
            this.SetStringButton.Size = new System.Drawing.Size(100, 23);
            this.SetStringButton.TabIndex = 11;
            this.SetStringButton.Text = "Set String";
            this.SetStringButton.UseVisualStyleBackColor = true;
            this.SetStringButton.Click += new System.EventHandler(this.SetStringButton_Click);
            // 
            // IntTextBox
            // 
            this.IntTextBox.Location = new System.Drawing.Point(415, 13);
            this.IntTextBox.Name = "IntTextBox";
            this.IntTextBox.Size = new System.Drawing.Size(100, 20);
            this.IntTextBox.TabIndex = 12;
            // 
            // GetIntButton
            // 
            this.GetIntButton.Location = new System.Drawing.Point(415, 40);
            this.GetIntButton.Name = "GetIntButton";
            this.GetIntButton.Size = new System.Drawing.Size(100, 23);
            this.GetIntButton.TabIndex = 13;
            this.GetIntButton.Text = "Get Int";
            this.GetIntButton.UseVisualStyleBackColor = true;
            this.GetIntButton.Click += new System.EventHandler(this.GetIntButton_Click);
            // 
            // SetIntButton
            // 
            this.SetIntButton.Location = new System.Drawing.Point(415, 67);
            this.SetIntButton.Name = "SetIntButton";
            this.SetIntButton.Size = new System.Drawing.Size(100, 23);
            this.SetIntButton.TabIndex = 14;
            this.SetIntButton.Text = "Set Int";
            this.SetIntButton.UseVisualStyleBackColor = true;
            this.SetIntButton.Click += new System.EventHandler(this.SetIntButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 139);
            this.Controls.Add(this.SetIntButton);
            this.Controls.Add(this.GetIntButton);
            this.Controls.Add(this.IntTextBox);
            this.Controls.Add(this.SetStringButton);
            this.Controls.Add(this.GetStringButton);
            this.Controls.Add(this.StringTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.YTextBox);
            this.Controls.Add(this.XTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.TextBox YTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox StringTextBox;
        private System.Windows.Forms.Button GetStringButton;
        private System.Windows.Forms.Button SetStringButton;
        private System.Windows.Forms.TextBox IntTextBox;
        private System.Windows.Forms.Button GetIntButton;
        private System.Windows.Forms.Button SetIntButton;
    }
}

