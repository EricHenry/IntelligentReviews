namespace IRController
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.startCleaning = new System.Windows.Forms.Button();
            this.reviewCleaningBox = new System.Windows.Forms.GroupBox();
            this.reviewCleaningBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output File";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(137, 20);
            this.textBox2.TabIndex = 3;
            // 
            // startCleaning
            // 
            this.startCleaning.Location = new System.Drawing.Point(9, 135);
            this.startCleaning.Name = "startCleaning";
            this.startCleaning.Size = new System.Drawing.Size(127, 23);
            this.startCleaning.TabIndex = 6;
            this.startCleaning.Text = "Clean Review";
            this.startCleaning.UseVisualStyleBackColor = true;
            // 
            // reviewCleaningBox
            // 
            this.reviewCleaningBox.Controls.Add(this.startCleaning);
            this.reviewCleaningBox.Controls.Add(this.label2);
            this.reviewCleaningBox.Controls.Add(this.button2);
            this.reviewCleaningBox.Controls.Add(this.textBox2);
            this.reviewCleaningBox.Controls.Add(this.label1);
            this.reviewCleaningBox.Controls.Add(this.button1);
            this.reviewCleaningBox.Controls.Add(this.textBox1);
            this.reviewCleaningBox.Location = new System.Drawing.Point(12, 12);
            this.reviewCleaningBox.Name = "reviewCleaningBox";
            this.reviewCleaningBox.Size = new System.Drawing.Size(191, 178);
            this.reviewCleaningBox.TabIndex = 7;
            this.reviewCleaningBox.TabStop = false;
            this.reviewCleaningBox.Text = "Clean Reviews";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 329);
            this.Controls.Add(this.reviewCleaningBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.reviewCleaningBox.ResumeLayout(false);
            this.reviewCleaningBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button startCleaning;
        private System.Windows.Forms.GroupBox reviewCleaningBox;
    }
}

