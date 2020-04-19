namespace client {
    partial class StartForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.result = new System.Windows.Forms.RichTextBox();
            this.getStudents = new System.Windows.Forms.Button();
            this.getNotes = new System.Windows.Forms.Button();
            this.button55 = new System.Windows.Forms.Button();
            this.button66 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(12, 12);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(693, 293);
            this.result.TabIndex = 0;
            this.result.Text = "";
            // 
            // getStudents
            // 
            this.getStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getStudents.Location = new System.Drawing.Point(12, 311);
            this.getStudents.Name = "getStudents";
            this.getStudents.Size = new System.Drawing.Size(150, 71);
            this.getStudents.TabIndex = 1;
            this.getStudents.Text = "students";
            this.getStudents.UseVisualStyleBackColor = true;
            this.getStudents.Click += new System.EventHandler(this.getStudents_Click);
            // 
            // getNotes
            // 
            this.getNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getNotes.Location = new System.Drawing.Point(448, 311);
            this.getNotes.Name = "getNotes";
            this.getNotes.Size = new System.Drawing.Size(257, 71);
            this.getNotes.TabIndex = 2;
            this.getNotes.Text = "notes";
            this.getNotes.UseVisualStyleBackColor = true;
            this.getNotes.Click += new System.EventHandler(this.getNotes_Click);
            // 
            // button55
            // 
            this.button55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button55.Location = new System.Drawing.Point(168, 311);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(127, 71);
            this.button55.TabIndex = 3;
            this.button55.Text = "Add";
            this.button55.UseVisualStyleBackColor = true;
            this.button55.Click += new System.EventHandler(this.button55_Click);
            // 
            // button66
            // 
            this.button66.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button66.Location = new System.Drawing.Point(301, 311);
            this.button66.Name = "button66";
            this.button66.Size = new System.Drawing.Size(141, 71);
            this.button66.TabIndex = 4;
            this.button66.Text = "Update";
            this.button66.UseVisualStyleBackColor = true;
            this.button66.Click += new System.EventHandler(this.button66_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 394);
            this.Controls.Add(this.button66);
            this.Controls.Add(this.button55);
            this.Controls.Add(this.getNotes);
            this.Controls.Add(this.getStudents);
            this.Controls.Add(this.result);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox result;
        private System.Windows.Forms.Button getStudents;
        private System.Windows.Forms.Button getNotes;
        private System.Windows.Forms.Button button55;
        private System.Windows.Forms.Button button66;
    }
}