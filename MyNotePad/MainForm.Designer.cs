
namespace MyNotepad
{
    partial class MainForm
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
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newDocumentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openURLMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.pageSetupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.searchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.findMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.findPreviousMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.goToLineMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.formatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFeedbackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorMenu3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutNotepadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lineIndicatorListBox = new System.Windows.Forms.ListBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // noteTextBox
            // 
            this.noteTextBox.AllowDrop = true;
            this.noteTextBox.Location = new System.Drawing.Point(59, 24);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noteTextBox.Size = new System.Drawing.Size(907, 582);
            this.noteTextBox.TabIndex = 0;
            this.noteTextBox.WordWrap = false;
            this.noteTextBox.TextChanged += new System.EventHandler(this.NoteTextBox_TextChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.formatMenu,
            this.viewMenu,
            this.helpMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(983, 24);
            this.mainMenu.TabIndex = 1;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDocumentMenu,
            this.newWindowMenu,
            this.openMenu,
            this.openURLMenu,
            this.saveMenu,
            this.saveAsMenu,
            this.separatorLine1,
            this.pageSetupMenu,
            this.printMenu,
            this.separatorLine2,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // newDocumentMenu
            // 
            this.newDocumentMenu.Name = "newDocumentMenu";
            this.newDocumentMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newDocumentMenu.Size = new System.Drawing.Size(220, 22);
            this.newDocumentMenu.Text = "New";
            this.newDocumentMenu.Click += new System.EventHandler(this.NewDocumentMenu_Click);
            // 
            // newWindowMenu
            // 
            this.newWindowMenu.Name = "newWindowMenu";
            this.newWindowMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.newWindowMenu.Size = new System.Drawing.Size(220, 22);
            this.newWindowMenu.Text = "New Window";
            this.newWindowMenu.Click += new System.EventHandler(this.NewWindowMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(220, 22);
            this.openMenu.Text = "Open...";
            this.openMenu.Click += new System.EventHandler(this.OpenMenu_Click);
            // 
            // openURLMenu
            // 
            this.openURLMenu.Name = "openURLMenu";
            this.openURLMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.openURLMenu.Size = new System.Drawing.Size(220, 22);
            this.openURLMenu.Text = "Open URL";
            this.openURLMenu.Click += new System.EventHandler(this.OpenURLMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenu.Size = new System.Drawing.Size(220, 22);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.SaveMenu_Click);
            // 
            // saveAsMenu
            // 
            this.saveAsMenu.Name = "saveAsMenu";
            this.saveAsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenu.Size = new System.Drawing.Size(220, 22);
            this.saveAsMenu.Text = "Save As..";
            this.saveAsMenu.Click += new System.EventHandler(this.SaveAsMenu_Click);
            // 
            // separatorLine1
            // 
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(217, 6);
            // 
            // pageSetupMenu
            // 
            this.pageSetupMenu.Name = "pageSetupMenu";
            this.pageSetupMenu.Size = new System.Drawing.Size(220, 22);
            this.pageSetupMenu.Text = "Page Setup..";
            this.pageSetupMenu.Click += new System.EventHandler(this.PageSetupMenu_Click);
            // 
            // printMenu
            // 
            this.printMenu.Name = "printMenu";
            this.printMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printMenu.Size = new System.Drawing.Size(220, 22);
            this.printMenu.Text = "Print...";
            this.printMenu.Click += new System.EventHandler(this.PrintMenu_Click);
            // 
            // separatorLine2
            // 
            this.separatorLine2.Name = "separatorLine2";
            this.separatorLine2.Size = new System.Drawing.Size(217, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(220, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenu,
            this.CopyMenu,
            this.cutMenu,
            this.pasteMenu,
            this.deleteMenu,
            this.toolStripSeparator4,
            this.searchMenu,
            this.findMenu,
            this.findNextMenu,
            this.findPreviousMenu,
            this.replaceMenu,
            this.goToLineMenu,
            this.toolStripSeparator5,
            this.selectAllMenu,
            this.dateTimeMenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // undoMenu
            // 
            this.undoMenu.Name = "undoMenu";
            this.undoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoMenu.Size = new System.Drawing.Size(225, 22);
            this.undoMenu.Text = "Undo";
            this.undoMenu.Click += new System.EventHandler(this.UndoMenu_Click);
            // 
            // CopyMenu
            // 
            this.CopyMenu.Name = "CopyMenu";
            this.CopyMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyMenu.Size = new System.Drawing.Size(225, 22);
            this.CopyMenu.Text = "Copy";
            this.CopyMenu.Click += new System.EventHandler(this.CopyMenu_Click);
            // 
            // cutMenu
            // 
            this.cutMenu.Name = "cutMenu";
            this.cutMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutMenu.Size = new System.Drawing.Size(225, 22);
            this.cutMenu.Text = "Cut";
            this.cutMenu.Click += new System.EventHandler(this.CutMenu_Click);
            // 
            // pasteMenu
            // 
            this.pasteMenu.Name = "pasteMenu";
            this.pasteMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenu.Size = new System.Drawing.Size(225, 22);
            this.pasteMenu.Text = "Paste";
            this.pasteMenu.Click += new System.EventHandler(this.PasteMenu_Click);
            // 
            // deleteMenu
            // 
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteMenu.Size = new System.Drawing.Size(225, 22);
            this.deleteMenu.Text = "Delete";
            this.deleteMenu.Click += new System.EventHandler(this.DeleteMenu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(222, 6);
            // 
            // searchMenu
            // 
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.searchMenu.Size = new System.Drawing.Size(225, 22);
            this.searchMenu.Text = "Search with Google...";
            this.searchMenu.Click += new System.EventHandler(this.SearchWithGoogleMenu_Click);
            // 
            // findMenu
            // 
            this.findMenu.Name = "findMenu";
            this.findMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findMenu.Size = new System.Drawing.Size(225, 22);
            this.findMenu.Text = "Find";
            this.findMenu.Click += new System.EventHandler(this.FindMenu_Click);
            // 
            // findNextMenu
            // 
            this.findNextMenu.Name = "findNextMenu";
            this.findNextMenu.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextMenu.Size = new System.Drawing.Size(225, 22);
            this.findNextMenu.Text = "Find Next";
            this.findNextMenu.Click += new System.EventHandler(this.FindNextMenu_Click);
            // 
            // findPreviousMenu
            // 
            this.findPreviousMenu.Name = "findPreviousMenu";
            this.findPreviousMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.findPreviousMenu.Size = new System.Drawing.Size(225, 22);
            this.findPreviousMenu.Text = "Find Previous..";
            this.findPreviousMenu.Click += new System.EventHandler(this.FindPreviousMenu_Click);
            // 
            // replaceMenu
            // 
            this.replaceMenu.Name = "replaceMenu";
            this.replaceMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceMenu.Size = new System.Drawing.Size(225, 22);
            this.replaceMenu.Text = "Replace..";
            this.replaceMenu.Click += new System.EventHandler(this.ReplaceMenu_Click);
            // 
            // goToLineMenu
            // 
            this.goToLineMenu.Name = "goToLineMenu";
            this.goToLineMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToLineMenu.Size = new System.Drawing.Size(225, 22);
            this.goToLineMenu.Text = "Go To...";
            this.goToLineMenu.Click += new System.EventHandler(this.GoToLineMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(222, 6);
            // 
            // selectAllMenu
            // 
            this.selectAllMenu.Name = "selectAllMenu";
            this.selectAllMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllMenu.Size = new System.Drawing.Size(225, 22);
            this.selectAllMenu.Text = "Select All";
            this.selectAllMenu.Click += new System.EventHandler(this.SelectAllMenu_Click);
            // 
            // dateTimeMenu
            // 
            this.dateTimeMenu.Name = "dateTimeMenu";
            this.dateTimeMenu.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.dateTimeMenu.Size = new System.Drawing.Size(225, 22);
            this.dateTimeMenu.Text = "Time/Date";
            this.dateTimeMenu.Click += new System.EventHandler(this.DateTimeMenu_Click);
            // 
            // formatMenu
            // 
            this.formatMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapMenu,
            this.fontMenu});
            this.formatMenu.Name = "formatMenu";
            this.formatMenu.Size = new System.Drawing.Size(57, 20);
            this.formatMenu.Text = "Format";
            // 
            // wordWrapMenu
            // 
            this.wordWrapMenu.Name = "wordWrapMenu";
            this.wordWrapMenu.Size = new System.Drawing.Size(180, 22);
            this.wordWrapMenu.Text = "Word Wrap";
            this.wordWrapMenu.Click += new System.EventHandler(this.WordWrapMenu_Click);
            // 
            // fontMenu
            // 
            this.fontMenu.Name = "fontMenu";
            this.fontMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.fontMenu.Size = new System.Drawing.Size(180, 22);
            this.fontMenu.Text = "Font...";
            this.fontMenu.Click += new System.EventHandler(this.FontMenu_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenu});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "View";
            // 
            // zoomMenu
            // 
            this.zoomMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.restoreDefaultToolStripMenuItem});
            this.zoomMenu.Name = "zoomMenu";
            this.zoomMenu.Size = new System.Drawing.Size(180, 22);
            this.zoomMenu.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom in";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInMenu_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutMenu_Click);
            // 
            // restoreDefaultToolStripMenuItem
            // 
            this.restoreDefaultToolStripMenuItem.Name = "restoreDefaultToolStripMenuItem";
            this.restoreDefaultToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.restoreDefaultToolStripMenuItem.Text = "Restore Default  Zoom";
            this.restoreDefaultToolStripMenuItem.Click += new System.EventHandler(this.RestoreDefaultMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpMenu,
            this.sendFeedbackMenu,
            this.separatorMenu3,
            this.aboutNotepadMenu});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "Help";
            // 
            // viewHelpMenu
            // 
            this.viewHelpMenu.Name = "viewHelpMenu";
            this.viewHelpMenu.Size = new System.Drawing.Size(180, 22);
            this.viewHelpMenu.Text = "View Help";
            this.viewHelpMenu.Click += new System.EventHandler(this.ViewHelpMenu_Click);
            // 
            // sendFeedbackMenu
            // 
            this.sendFeedbackMenu.Name = "sendFeedbackMenu";
            this.sendFeedbackMenu.Size = new System.Drawing.Size(180, 22);
            this.sendFeedbackMenu.Text = "Send Feedback";
            // 
            // separatorMenu3
            // 
            this.separatorMenu3.Name = "separatorMenu3";
            this.separatorMenu3.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutNotepadMenu
            // 
            this.aboutNotepadMenu.Name = "aboutNotepadMenu";
            this.aboutNotepadMenu.Size = new System.Drawing.Size(180, 22);
            this.aboutNotepadMenu.Text = "About Notepad";
            this.aboutNotepadMenu.Click += new System.EventHandler(this.AboutNotepadMenu_Click);
            // 
            // lineIndicatorListBox
            // 
            this.lineIndicatorListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineIndicatorListBox.FormattingEnabled = true;
            this.lineIndicatorListBox.Items.AddRange(new object[] {
            "1"});
            this.lineIndicatorListBox.Location = new System.Drawing.Point(0, 24);
            this.lineIndicatorListBox.Name = "lineIndicatorListBox";
            this.lineIndicatorListBox.Size = new System.Drawing.Size(53, 584);
            this.lineIndicatorListBox.TabIndex = 2;
            this.lineIndicatorListBox.SelectedIndexChanged += new System.EventHandler(this.LineIndicatorListBox_SelectedIndexChanged);
            this.lineIndicatorListBox.MouseEnter += new System.EventHandler(this.LineIndicatorListBox_MouseEnter);
            this.lineIndicatorListBox.MouseLeave += new System.EventHandler(this.LineIndicatorListBox_MouseLeave);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 608);
            this.Controls.Add(this.lineIndicatorListBox);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem formatMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem wordWrapMenu;
        private System.Windows.Forms.ToolStripMenuItem fontMenu;
        private System.Windows.Forms.ToolStripMenuItem viewHelpMenu;
        private System.Windows.Forms.ToolStripMenuItem sendFeedbackMenu;
        private System.Windows.Forms.ToolStripSeparator separatorMenu3;
        private System.Windows.Forms.ToolStripMenuItem aboutNotepadMenu;
        private System.Windows.Forms.ToolStripMenuItem newDocumentMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
        private System.Windows.Forms.ToolStripSeparator separatorLine1;
        private System.Windows.Forms.ToolStripMenuItem pageSetupMenu;
        private System.Windows.Forms.ToolStripMenuItem printMenu;
        private System.Windows.Forms.ToolStripSeparator separatorLine2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem undoMenu;
        private System.Windows.Forms.ToolStripMenuItem CopyMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem searchMenu;
        private System.Windows.Forms.ToolStripMenuItem findMenu;
        private System.Windows.Forms.ToolStripMenuItem findNextMenu;
        private System.Windows.Forms.ToolStripMenuItem findPreviousMenu;
        private System.Windows.Forms.ToolStripMenuItem replaceMenu;
        private System.Windows.Forms.ToolStripMenuItem goToLineMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenu;
        private System.Windows.Forms.ToolStripMenuItem dateTimeMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDefaultToolStripMenuItem;
        public System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.ToolStripMenuItem cutMenu;
        private System.Windows.Forms.ListBox lineIndicatorListBox;
        private System.Windows.Forms.ToolStripMenuItem openURLMenu;
    }
}

