
namespace MyNotepad
{
    partial class GoToLineForm
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
            this.LineTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gotoLineButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LineTextbox
            // 
            this.LineTextbox.Location = new System.Drawing.Point(12, 36);
            this.LineTextbox.MaxLength = 5;
            this.LineTextbox.Name = "LineTextbox";
            this.LineTextbox.Size = new System.Drawing.Size(267, 20);
            this.LineTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line Number:";
            // 
            // gotoLineButton
            // 
            this.gotoLineButton.Location = new System.Drawing.Point(125, 62);
            this.gotoLineButton.Name = "gotoLineButton";
            this.gotoLineButton.Size = new System.Drawing.Size(75, 23);
            this.gotoLineButton.TabIndex = 2;
            this.gotoLineButton.Text = "Go To";
            this.gotoLineButton.UseVisualStyleBackColor = true;
            this.gotoLineButton.Click += new System.EventHandler(this.GotoLineButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(206, 62);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GoToLineForm
            // 
            this.AcceptButton = this.gotoLineButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 96);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.gotoLineButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LineTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToLineForm";
            this.ShowInTaskbar = false;
            this.Text = "Go To Line";
            this.Load += new System.EventHandler(this.GoTo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LineTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gotoLineButton;
        private System.Windows.Forms.Button cancelButton;
    }
}