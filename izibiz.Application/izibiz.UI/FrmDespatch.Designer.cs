﻿namespace izibiz.UI
{
    partial class FrmDespatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespatch));
            this.btnFilterList = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.timeStartFilter = new System.Windows.Forms.DateTimePicker();
            this.timeFinishFilter = new System.Windows.Forms.DateTimePicker();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.btnTakeDespatch = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemIncomingInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSentInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTakeGibUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListGibUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlIncomingDespatch = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIncomingInvGetState = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlSendDespatch = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSendInvGetState = new System.Windows.Forms.Button();
            this.pnlDraftDespatch = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menuInvoice.SuspendLayout();
            this.pnlIncomingDespatch.SuspendLayout();
            this.pnlSendDespatch.SuspendLayout();
            this.pnlDraftDespatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilterList
            // 
            this.btnFilterList.BackColor = System.Drawing.Color.Lavender;
            this.btnFilterList.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFilterList.FlatAppearance.BorderSize = 2;
            this.btnFilterList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterList.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilterList.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilterList.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterList.Image")));
            this.btnFilterList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterList.Location = new System.Drawing.Point(25, 81);
            this.btnFilterList.Name = "btnFilterList";
            this.btnFilterList.Size = new System.Drawing.Size(107, 27);
            this.btnFilterList.TabIndex = 28;
            this.btnFilterList.Text = "Filtrele";
            this.btnFilterList.UseVisualStyleBackColor = false;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnFilterList);
            this.grpFilter.Controls.Add(this.timeStartFilter);
            this.grpFilter.Controls.Add(this.timeFinishFilter);
            this.grpFilter.Location = new System.Drawing.Point(1033, 29);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(147, 114);
            this.grpFilter.TabIndex = 39;
            this.grpFilter.TabStop = false;
            this.grpFilter.Visible = false;
            // 
            // timeStartFilter
            // 
            this.timeStartFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeStartFilter.Location = new System.Drawing.Point(25, 11);
            this.timeStartFilter.Name = "timeStartFilter";
            this.timeStartFilter.Size = new System.Drawing.Size(107, 20);
            this.timeStartFilter.TabIndex = 26;
            // 
            // timeFinishFilter
            // 
            this.timeFinishFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeFinishFilter.Location = new System.Drawing.Point(25, 45);
            this.timeFinishFilter.Name = "timeFinishFilter";
            this.timeFinishFilter.Size = new System.Drawing.Size(107, 20);
            this.timeFinishFilter.TabIndex = 27;
            // 
            // btnHomePage
            // 
            this.btnHomePage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnHomePage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHomePage.BackgroundImage")));
            this.btnHomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHomePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomePage.FlatAppearance.BorderSize = 0;
            this.btnHomePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHomePage.ForeColor = System.Drawing.Color.Snow;
            this.btnHomePage.Location = new System.Drawing.Point(9, 22);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(115, 70);
            this.btnHomePage.TabIndex = 40;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            // 
            // btnTakeDespatch
            // 
            this.btnTakeDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeDespatch.FlatAppearance.BorderSize = 2;
            this.btnTakeDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeDespatch.Location = new System.Drawing.Point(211, 62);
            this.btnTakeDespatch.Name = "btnTakeDespatch";
            this.btnTakeDespatch.Size = new System.Drawing.Size(120, 35);
            this.btnTakeDespatch.TabIndex = 38;
            this.btnTakeDespatch.Text = "fatura al";
            this.btnTakeDespatch.UseVisualStyleBackColor = false;
            this.btnTakeDespatch.Visible = false;
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.GridColor = System.Drawing.SystemColors.Control;
            this.tableGrid.Location = new System.Drawing.Point(243, 364);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(905, 188);
            this.tableGrid.TabIndex = 35;
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemIncomingInvoice,
            this.itemSentInvoice,
            this.itemDraftInvoice,
            this.itemNewInvoice,
            this.itemTakeGibUsers,
            this.itemListGibUserList});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(135, 608);
            this.menuInvoice.TabIndex = 32;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemIncomingInvoice
            // 
            this.itemIncomingInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemIncomingInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemIncomingInvoice.Margin = new System.Windows.Forms.Padding(0, 110, 0, 0);
            this.itemIncomingInvoice.Name = "itemIncomingInvoice";
            this.itemIncomingInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemIncomingInvoice.Size = new System.Drawing.Size(128, 29);
            this.itemIncomingInvoice.Text = "Gelen İrsaliye";
            this.itemIncomingInvoice.Click += new System.EventHandler(this.itemIncomingInvoice_Click);
            // 
            // itemSentInvoice
            // 
            this.itemSentInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemSentInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemSentInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemSentInvoice.Name = "itemSentInvoice";
            this.itemSentInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemSentInvoice.Size = new System.Drawing.Size(128, 29);
            this.itemSentInvoice.Text = " Giden İrsaliye";
            this.itemSentInvoice.Click += new System.EventHandler(this.itemSentInvoice_Click);
            // 
            // itemDraftInvoice
            // 
            this.itemDraftInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemDraftInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemDraftInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemDraftInvoice.Name = "itemDraftInvoice";
            this.itemDraftInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemDraftInvoice.Size = new System.Drawing.Size(128, 29);
            this.itemDraftInvoice.Text = "Taslak İrsaliye";
            this.itemDraftInvoice.Click += new System.EventHandler(this.itemDraftInvoice_Click);
            // 
            // itemNewInvoice
            // 
            this.itemNewInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemNewInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemNewInvoice.Name = "itemNewInvoice";
            this.itemNewInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewInvoice.Size = new System.Drawing.Size(128, 29);
            this.itemNewInvoice.Text = "Yeni İrsaliye";
            // 
            // itemTakeGibUsers
            // 
            this.itemTakeGibUsers.BackColor = System.Drawing.Color.Teal;
            this.itemTakeGibUsers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemTakeGibUsers.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemTakeGibUsers.Name = "itemTakeGibUsers";
            this.itemTakeGibUsers.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemTakeGibUsers.Size = new System.Drawing.Size(128, 29);
            this.itemTakeGibUsers.Text = "Gib User List Al";
            this.itemTakeGibUsers.Click += new System.EventHandler(this.itemTakeGibUsers_Click);
            // 
            // itemListGibUserList
            // 
            this.itemListGibUserList.BackColor = System.Drawing.Color.Teal;
            this.itemListGibUserList.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemListGibUserList.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemListGibUserList.Name = "itemListGibUserList";
            this.itemListGibUserList.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemListGibUserList.Size = new System.Drawing.Size(128, 29);
            this.itemListGibUserList.Text = "Gib User Listele";
            this.itemListGibUserList.Click += new System.EventHandler(this.itemListGibUserList_Click);
            // 
            // pnlIncomingDespatch
            // 
            this.pnlIncomingDespatch.Controls.Add(this.button1);
            this.pnlIncomingDespatch.Controls.Add(this.btnIncomingInvGetState);
            this.pnlIncomingDespatch.Location = new System.Drawing.Point(337, 37);
            this.pnlIncomingDespatch.Name = "pnlIncomingDespatch";
            this.pnlIncomingDespatch.Size = new System.Drawing.Size(646, 103);
            this.pnlIncomingDespatch.TabIndex = 41;
            this.pnlIncomingDespatch.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(155, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 24;
            this.button1.Text = "Yanıt Ver";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnIncomingInvGetState
            // 
            this.btnIncomingInvGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnIncomingInvGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnIncomingInvGetState.FlatAppearance.BorderSize = 2;
            this.btnIncomingInvGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomingInvGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIncomingInvGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIncomingInvGetState.Location = new System.Drawing.Point(18, 25);
            this.btnIncomingInvGetState.Name = "btnIncomingInvGetState";
            this.btnIncomingInvGetState.Size = new System.Drawing.Size(117, 35);
            this.btnIncomingInvGetState.TabIndex = 23;
            this.btnIncomingInvGetState.Text = "Durum sorgula";
            this.btnIncomingInvGetState.UseVisualStyleBackColor = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblText.Location = new System.Drawing.Point(569, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(113, 25);
            this.lblText.TabIndex = 42;
            this.lblText.Text = "Hosgeldınız";
            // 
            // pnlSendDespatch
            // 
            this.pnlSendDespatch.Controls.Add(this.button2);
            this.pnlSendDespatch.Controls.Add(this.btnSendInvGetState);
            this.pnlSendDespatch.Location = new System.Drawing.Point(337, 146);
            this.pnlSendDespatch.Name = "pnlSendDespatch";
            this.pnlSendDespatch.Size = new System.Drawing.Size(646, 103);
            this.pnlSendDespatch.TabIndex = 42;
            this.pnlSendDespatch.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(155, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "E mail Gönder";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnSendInvGetState
            // 
            this.btnSendInvGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendInvGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendInvGetState.FlatAppearance.BorderSize = 2;
            this.btnSendInvGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendInvGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendInvGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendInvGetState.Location = new System.Drawing.Point(18, 33);
            this.btnSendInvGetState.Name = "btnSendInvGetState";
            this.btnSendInvGetState.Size = new System.Drawing.Size(117, 35);
            this.btnSendInvGetState.TabIndex = 24;
            this.btnSendInvGetState.Text = "Durum sorgula";
            this.btnSendInvGetState.UseVisualStyleBackColor = false;
            // 
            // pnlDraftDespatch
            // 
            this.pnlDraftDespatch.Controls.Add(this.button4);
            this.pnlDraftDespatch.Controls.Add(this.button3);
            this.pnlDraftDespatch.Location = new System.Drawing.Point(337, 255);
            this.pnlDraftDespatch.Name = "pnlDraftDespatch";
            this.pnlDraftDespatch.Size = new System.Drawing.Size(646, 103);
            this.pnlDraftDespatch.TabIndex = 42;
            this.pnlDraftDespatch.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CadetBlue;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(155, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 26;
            this.button4.Text = "İptal Et";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(18, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 35);
            this.button3.TabIndex = 25;
            this.button3.Text = "Gönder";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // FrmDespatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 608);
            this.Controls.Add(this.pnlSendDespatch);
            this.Controls.Add(this.pnlDraftDespatch);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pnlIncomingDespatch);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnTakeDespatch);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menuInvoice);
            this.Name = "FrmDespatch";
            this.Text = "FrmDespatch";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDespatch_FormClosed);
            this.Load += new System.EventHandler(this.FrmDespatch_Load);
            this.grpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            this.pnlIncomingDespatch.ResumeLayout(false);
            this.pnlSendDespatch.ResumeLayout(false);
            this.pnlDraftDespatch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilterList;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.DateTimePicker timeStartFilter;
        private System.Windows.Forms.DateTimePicker timeFinishFilter;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Button btnTakeDespatch;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemIncomingInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemSentInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemDraftInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemNewInvoice;
        private System.Windows.Forms.Panel pnlIncomingDespatch;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlSendDespatch;
        private System.Windows.Forms.Panel pnlDraftDespatch;
        private System.Windows.Forms.Button btnIncomingInvGetState;
        private System.Windows.Forms.Button btnSendInvGetState;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem itemTakeGibUsers;
        private System.Windows.Forms.ToolStripMenuItem itemListGibUserList;
    }
}