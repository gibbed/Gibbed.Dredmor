/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

namespace Gibbed.Dredmor.Maximap
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this._MainToolStrip = new System.Windows.Forms.ToolStrip();
            this._UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._CheatButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            this._ZoomInButton = new System.Windows.Forms.ToolStripButton();
            this._ZoomActualButton = new System.Windows.Forms.ToolStripButton();
            this._ZoomFitButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._MasterPanel = new System.Windows.Forms.Panel();
            this._MapPictureBox = new System.Windows.Forms.PictureBox();
            this._InfoTabControl = new System.Windows.Forms.TabControl();
            this._RoomTabPage = new System.Windows.Forms.TabPage();
            this._RoomListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._MonsterTabPage = new System.Windows.Forms.TabPage();
            this._MonsterListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._QuestItemTabPage = new System.Windows.Forms.TabPage();
            this._QuestItemListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._MainToolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._MasterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._MapPictureBox)).BeginInit();
            this._InfoTabControl.SuspendLayout();
            this._RoomTabPage.SuspendLayout();
            this._MonsterTabPage.SuspendLayout();
            this._QuestItemTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _MainToolStrip
            // 
            this._MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._UpdateButton,
            this.toolStripSeparator1,
            this._CheatButton,
            this.toolStripSeparator2,
            this._ZoomOutButton,
            this._ZoomInButton,
            this._ZoomActualButton,
            this._ZoomFitButton});
            this._MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this._MainToolStrip.Name = "_MainToolStrip";
            this._MainToolStrip.Size = new System.Drawing.Size(640, 25);
            this._MainToolStrip.TabIndex = 0;
            this._MainToolStrip.Text = "toolStrip1";
            // 
            // _UpdateButton
            // 
            this._UpdateButton.Image = ((System.Drawing.Image)(resources.GetObject("_UpdateButton.Image")));
            this._UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._UpdateButton.Name = "_UpdateButton";
            this._UpdateButton.Size = new System.Drawing.Size(65, 22);
            this._UpdateButton.Text = "Update";
            this._UpdateButton.Click += new System.EventHandler(this.OnUpdate);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _CheatButton
            // 
            this._CheatButton.CheckOnClick = true;
            this._CheatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._CheatButton.Image = ((System.Drawing.Image)(resources.GetObject("_CheatButton.Image")));
            this._CheatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._CheatButton.Name = "_CheatButton";
            this._CheatButton.Size = new System.Drawing.Size(23, 22);
            this._CheatButton.Text = "The Cheat (don\'t respect square visibility)";
            this._CheatButton.CheckedChanged += new System.EventHandler(this._CheatButton_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _ZoomOutButton
            // 
            this._ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ZoomOutButton.Enabled = false;
            this._ZoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("_ZoomOutButton.Image")));
            this._ZoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ZoomOutButton.Name = "_ZoomOutButton";
            this._ZoomOutButton.Size = new System.Drawing.Size(23, 22);
            this._ZoomOutButton.Text = "Zoom Out";
            this._ZoomOutButton.Click += new System.EventHandler(this.OnChangeScale);
            // 
            // _ZoomInButton
            // 
            this._ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ZoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("_ZoomInButton.Image")));
            this._ZoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ZoomInButton.Name = "_ZoomInButton";
            this._ZoomInButton.Size = new System.Drawing.Size(23, 22);
            this._ZoomInButton.Text = "Zoom In";
            this._ZoomInButton.Click += new System.EventHandler(this.OnChangeScale);
            // 
            // _ZoomActualButton
            // 
            this._ZoomActualButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ZoomActualButton.Image = ((System.Drawing.Image)(resources.GetObject("_ZoomActualButton.Image")));
            this._ZoomActualButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ZoomActualButton.Name = "_ZoomActualButton";
            this._ZoomActualButton.Size = new System.Drawing.Size(23, 22);
            this._ZoomActualButton.Text = "Zoom 1:1";
            this._ZoomActualButton.Click += new System.EventHandler(this.OnChangeScale);
            // 
            // _ZoomFitButton
            // 
            this._ZoomFitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ZoomFitButton.Image = ((System.Drawing.Image)(resources.GetObject("_ZoomFitButton.Image")));
            this._ZoomFitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ZoomFitButton.Name = "_ZoomFitButton";
            this._ZoomFitButton.Size = new System.Drawing.Size(23, 22);
            this._ZoomFitButton.Text = "Zoom Fit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._MasterPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._InfoTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(640, 273);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 3;
            // 
            // _MasterPanel
            // 
            this._MasterPanel.AutoScroll = true;
            this._MasterPanel.BackColor = System.Drawing.Color.Black;
            this._MasterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._MasterPanel.Controls.Add(this._MapPictureBox);
            this._MasterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MasterPanel.Location = new System.Drawing.Point(0, 0);
            this._MasterPanel.Name = "_MasterPanel";
            this._MasterPanel.Size = new System.Drawing.Size(400, 273);
            this._MasterPanel.TabIndex = 2;
            // 
            // _MapPictureBox
            // 
            this._MapPictureBox.Location = new System.Drawing.Point(0, 0);
            this._MapPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this._MapPictureBox.Name = "_MapPictureBox";
            this._MapPictureBox.Size = new System.Drawing.Size(32, 32);
            this._MapPictureBox.TabIndex = 0;
            this._MapPictureBox.TabStop = false;
            // 
            // _InfoTabControl
            // 
            this._InfoTabControl.Controls.Add(this._RoomTabPage);
            this._InfoTabControl.Controls.Add(this._MonsterTabPage);
            this._InfoTabControl.Controls.Add(this._QuestItemTabPage);
            this._InfoTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._InfoTabControl.Location = new System.Drawing.Point(0, 0);
            this._InfoTabControl.Multiline = true;
            this._InfoTabControl.Name = "_InfoTabControl";
            this._InfoTabControl.SelectedIndex = 0;
            this._InfoTabControl.Size = new System.Drawing.Size(236, 273);
            this._InfoTabControl.TabIndex = 0;
            // 
            // _RoomTabPage
            // 
            this._RoomTabPage.Controls.Add(this._RoomListView);
            this._RoomTabPage.Location = new System.Drawing.Point(4, 22);
            this._RoomTabPage.Name = "_RoomTabPage";
            this._RoomTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._RoomTabPage.Size = new System.Drawing.Size(228, 247);
            this._RoomTabPage.TabIndex = 0;
            this._RoomTabPage.Text = "Rooms";
            this._RoomTabPage.UseVisualStyleBackColor = true;
            // 
            // _RoomListView
            // 
            this._RoomListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this._RoomListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._RoomListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._RoomListView.Location = new System.Drawing.Point(3, 3);
            this._RoomListView.Name = "_RoomListView";
            this._RoomListView.Size = new System.Drawing.Size(222, 241);
            this._RoomListView.TabIndex = 1;
            this._RoomListView.UseCompatibleStateImageBehavior = false;
            this._RoomListView.View = System.Windows.Forms.View.Details;
            this._RoomListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // _MonsterTabPage
            // 
            this._MonsterTabPage.Controls.Add(this._MonsterListView);
            this._MonsterTabPage.Location = new System.Drawing.Point(4, 22);
            this._MonsterTabPage.Name = "_MonsterTabPage";
            this._MonsterTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._MonsterTabPage.Size = new System.Drawing.Size(228, 247);
            this._MonsterTabPage.TabIndex = 1;
            this._MonsterTabPage.Text = "Monsters";
            this._MonsterTabPage.UseVisualStyleBackColor = true;
            // 
            // _MonsterListView
            // 
            this._MonsterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this._MonsterListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MonsterListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._MonsterListView.Location = new System.Drawing.Point(3, 3);
            this._MonsterListView.Name = "_MonsterListView";
            this._MonsterListView.Size = new System.Drawing.Size(222, 241);
            this._MonsterListView.TabIndex = 2;
            this._MonsterListView.UseCompatibleStateImageBehavior = false;
            this._MonsterListView.View = System.Windows.Forms.View.Details;
            this._MonsterListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnItemSelectionChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 200;
            // 
            // _QuestItemTabPage
            // 
            this._QuestItemTabPage.Controls.Add(this._QuestItemListView);
            this._QuestItemTabPage.Location = new System.Drawing.Point(4, 22);
            this._QuestItemTabPage.Name = "_QuestItemTabPage";
            this._QuestItemTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._QuestItemTabPage.Size = new System.Drawing.Size(228, 247);
            this._QuestItemTabPage.TabIndex = 2;
            this._QuestItemTabPage.Text = "Quest Items";
            this._QuestItemTabPage.UseVisualStyleBackColor = true;
            // 
            // _QuestItemListView
            // 
            this._QuestItemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this._QuestItemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._QuestItemListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._QuestItemListView.Location = new System.Drawing.Point(3, 3);
            this._QuestItemListView.Name = "_QuestItemListView";
            this._QuestItemListView.Size = new System.Drawing.Size(222, 241);
            this._QuestItemListView.TabIndex = 2;
            this._QuestItemListView.UseCompatibleStateImageBehavior = false;
            this._QuestItemListView.View = System.Windows.Forms.View.Details;
            this._QuestItemListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnItemSelectionChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 200;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._MainToolStrip);
            this.Name = "Viewer";
            this.Text = "Gibbed\'s Dungeons of Dredmor Maximap";
            this._MainToolStrip.ResumeLayout(false);
            this._MainToolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this._MasterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._MapPictureBox)).EndInit();
            this._InfoTabControl.ResumeLayout(false);
            this._RoomTabPage.ResumeLayout(false);
            this._MonsterTabPage.ResumeLayout(false);
            this._QuestItemTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _MainToolStrip;
        private System.Windows.Forms.ToolStripButton _UpdateButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _CheatButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _ZoomActualButton;
        private System.Windows.Forms.ToolStripButton _ZoomInButton;
        private System.Windows.Forms.ToolStripButton _ZoomOutButton;
        private System.Windows.Forms.ToolStripButton _ZoomFitButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel _MasterPanel;
        private System.Windows.Forms.PictureBox _MapPictureBox;
        private System.Windows.Forms.TabControl _InfoTabControl;
        private System.Windows.Forms.TabPage _RoomTabPage;
        private System.Windows.Forms.ListView _RoomListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage _MonsterTabPage;
        private System.Windows.Forms.ListView _MonsterListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage _QuestItemTabPage;
        private System.Windows.Forms.ListView _QuestItemListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

