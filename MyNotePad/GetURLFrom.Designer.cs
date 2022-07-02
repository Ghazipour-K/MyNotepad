
namespace MyNotepad
{
    partial class GetURLFrom
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
            this.captionLable = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.loadURLButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // captionLable
            // 
            this.captionLable.AutoSize = true;
            this.captionLable.Location = new System.Drawing.Point(12, 9);
            this.captionLable.Name = "captionLable";
            this.captionLable.Size = new System.Drawing.Size(60, 13);
            this.captionLable.TabIndex = 0;
            this.captionLable.Text = "Enter URL:";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(12, 25);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(459, 20);
            this.URLTextBox.TabIndex = 1;
            // 
            // loadURLButton
            // 
            this.loadURLButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.loadURLButton.Location = new System.Drawing.Point(315, 51);
            this.loadURLButton.Name = "loadURLButton";
            this.loadURLButton.Size = new System.Drawing.Size(75, 23);
            this.loadURLButton.TabIndex = 2;
            this.loadURLButton.Text = "Load URL";
            this.loadURLButton.UseVisualStyleBackColor = true;
            this.loadURLButton.Click += new System.EventHandler(this.LoadURLButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancleButton.Location = new System.Drawing.Point(396, 51);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(75, 23);
            this.cancleButton.TabIndex = 2;
            this.cancleButton.Text = "Cancle";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.CancleButton_Click);
            // 
            // GetURLFrom
            // 
            this.AcceptButton = this.loadURLButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancleButton;
            this.ClientSize = new System.Drawing.Size(482, 86);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.loadURLButton);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.captionLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetURLFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load URL";
            this.Load += new System.EventHandler(this.GetURLFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captionLable;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button loadURLButton;
        private System.Windows.Forms.Button cancleButton;
    }
}