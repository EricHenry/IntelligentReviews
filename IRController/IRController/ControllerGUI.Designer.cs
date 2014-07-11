namespace IRController
{
    partial class ControllerGUI
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
            this.AssoRulesGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.runAssoRules = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.assoOutputSearch = new System.Windows.Forms.Button();
            this.assoOutputTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.assoInputSearch = new System.Windows.Forms.Button();
            this.assoInputTextBox = new System.Windows.Forms.TextBox();
            this.reviewCleaningBox.SuspendLayout();
            this.AssoRulesGroup.SuspendLayout();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(137, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // startCleaning
            // 
            this.startCleaning.Location = new System.Drawing.Point(9, 135);
            this.startCleaning.Name = "startCleaning";
            this.startCleaning.Size = new System.Drawing.Size(127, 23);
            this.startCleaning.TabIndex = 6;
            this.startCleaning.Text = "Clean Review";
            this.startCleaning.UseVisualStyleBackColor = true;
            this.startCleaning.Click += new System.EventHandler(this.startCleaning_Click_1);
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
            // AssoRulesGroup
            // 
            this.AssoRulesGroup.Controls.Add(this.label5);
            this.AssoRulesGroup.Controls.Add(this.textBox3);
            this.AssoRulesGroup.Controls.Add(this.runAssoRules);
            this.AssoRulesGroup.Controls.Add(this.label3);
            this.AssoRulesGroup.Controls.Add(this.assoOutputSearch);
            this.AssoRulesGroup.Controls.Add(this.assoOutputTextBox);
            this.AssoRulesGroup.Controls.Add(this.label4);
            this.AssoRulesGroup.Controls.Add(this.assoInputSearch);
            this.AssoRulesGroup.Controls.Add(this.assoInputTextBox);
            this.AssoRulesGroup.Location = new System.Drawing.Point(209, 12);
            this.AssoRulesGroup.Name = "AssoRulesGroup";
            this.AssoRulesGroup.Size = new System.Drawing.Size(191, 216);
            this.AssoRulesGroup.TabIndex = 8;
            this.AssoRulesGroup.TabStop = false;
            this.AssoRulesGroup.Text = "Run Association Rules";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Max Output Associations";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(19, 156);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(28, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // runAssoRules
            // 
            this.runAssoRules.Location = new System.Drawing.Point(19, 182);
            this.runAssoRules.Name = "runAssoRules";
            this.runAssoRules.Size = new System.Drawing.Size(127, 23);
            this.runAssoRules.TabIndex = 6;
            this.runAssoRules.Text = "Run Association Rules";
            this.runAssoRules.UseVisualStyleBackColor = true;
            this.runAssoRules.Click += new System.EventHandler(this.runAssoRules_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output File";
            // 
            // assoOutputSearch
            // 
            this.assoOutputSearch.Location = new System.Drawing.Point(152, 99);
            this.assoOutputSearch.Name = "assoOutputSearch";
            this.assoOutputSearch.Size = new System.Drawing.Size(26, 20);
            this.assoOutputSearch.TabIndex = 4;
            this.assoOutputSearch.Text = "...";
            this.assoOutputSearch.UseVisualStyleBackColor = true;
            this.assoOutputSearch.Click += new System.EventHandler(this.assoOutputSearch_Click);
            // 
            // assoOutputTextBox
            // 
            this.assoOutputTextBox.Location = new System.Drawing.Point(9, 99);
            this.assoOutputTextBox.Name = "assoOutputTextBox";
            this.assoOutputTextBox.Size = new System.Drawing.Size(137, 20);
            this.assoOutputTextBox.TabIndex = 3;
            this.assoOutputTextBox.TextChanged += new System.EventHandler(this.assoOutputTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Input File";
            // 
            // assoInputSearch
            // 
            this.assoInputSearch.Location = new System.Drawing.Point(152, 41);
            this.assoInputSearch.Name = "assoInputSearch";
            this.assoInputSearch.Size = new System.Drawing.Size(26, 20);
            this.assoInputSearch.TabIndex = 1;
            this.assoInputSearch.Text = "...";
            this.assoInputSearch.UseVisualStyleBackColor = true;
            this.assoInputSearch.Click += new System.EventHandler(this.assoInputSearch_Click);
            // 
            // assoInputTextBox
            // 
            this.assoInputTextBox.Location = new System.Drawing.Point(9, 41);
            this.assoInputTextBox.Name = "assoInputTextBox";
            this.assoInputTextBox.Size = new System.Drawing.Size(137, 20);
            this.assoInputTextBox.TabIndex = 0;
            this.assoInputTextBox.TextChanged += new System.EventHandler(this.assoInputTextBox_TextChanged);
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 349);
            this.Controls.Add(this.AssoRulesGroup);
            this.Controls.Add(this.reviewCleaningBox);
            this.Name = "ControllerGUI";
            this.Text = "Intelligent Reviews";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.reviewCleaningBox.ResumeLayout(false);
            this.reviewCleaningBox.PerformLayout();
            this.AssoRulesGroup.ResumeLayout(false);
            this.AssoRulesGroup.PerformLayout();
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
        private System.Windows.Forms.GroupBox AssoRulesGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button runAssoRules;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button assoOutputSearch;
        private System.Windows.Forms.TextBox assoOutputTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button assoInputSearch;
        private System.Windows.Forms.TextBox assoInputTextBox;
    }
}

