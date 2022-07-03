
namespace MyNotepad
{
    partial class ReplaceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chkboxMatchcase = new System.Windows.Forms.CheckBox();
            this.ChckboxWraparound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Replace with:";
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(87, 25);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(169, 20);
            this.findTextBox.TabIndex = 2;
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(87, 48);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(169, 20);
            this.replaceTextBox.TabIndex = 3;
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(262, 25);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(75, 23);
            this.findNextButton.TabIndex = 4;
            this.findNextButton.Text = "Find Next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(262, 54);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 5;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(262, 83);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.replaceAllButton.TabIndex = 6;
            this.replaceAllButton.Text = "Replace All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.BtnReplaceAll_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(262, 112);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // chkboxMatchcase
            // 
            this.chkboxMatchcase.AutoSize = true;
            this.chkboxMatchcase.Location = new System.Drawing.Point(9, 102);
            this.chkboxMatchcase.Name = "chkboxMatchcase";
            this.chkboxMatchcase.Size = new System.Drawing.Size(82, 17);
            this.chkboxMatchcase.TabIndex = 8;
            this.chkboxMatchcase.Text = "Match case";
            this.chkboxMatchcase.UseVisualStyleBackColor = true;
            // 
            // ChckboxWraparound
            // 
            this.ChckboxWraparound.AutoSize = true;
            this.ChckboxWraparound.Location = new System.Drawing.Point(9, 125);
            this.ChckboxWraparound.Name = "ChckboxWraparound";
            this.ChckboxWraparound.Size = new System.Drawing.Size(88, 17);
            this.ChckboxWraparound.TabIndex = 9;
            this.ChckboxWraparound.Text = "Wrap around";
            this.ChckboxWraparound.UseVisualStyleBackColor = true;
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(347, 152);
            this.Controls.Add(this.ChckboxWraparound);
            this.Controls.Add(this.chkboxMatchcase);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowInTaskbar = false;
            this.Text = "Replace";
            this.Load += new System.EventHandler(this.Replace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox chkboxMatchcase;
        private System.Windows.Forms.CheckBox ChckboxWraparound;
        public System.Windows.Forms.TextBox findTextBox;
    }
}