
namespace Server_TrinhPhucHieu
{
    partial class frmServer_Hieu
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
            try
            {
                base.Dispose(disposing);
            }
            catch
            {

            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServer_Hieu));
            this.flpPhongChat = new System.Windows.Forms.FlowLayoutPanel();
            this.radTeam = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.lvEmoji = new System.Windows.Forms.ListView();
            this.imgAnh = new System.Windows.Forms.ImageList(this.components);
            this.imgEmoji = new System.Windows.Forms.ImageList(this.components);
            this.lvTinNhan = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaTinNhans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnChuyenTiep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnEmoji = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnHinhAnh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnGuiTep = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xINCHAOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnXoaTin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnChuyenTin = new System.Windows.Forms.ToolStripMenuItem();
            this.cHAOBANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtGui = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.flpPhongChat.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPhongChat
            // 
            this.flpPhongChat.AutoScroll = true;
            this.flpPhongChat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flpPhongChat.Controls.Add(this.radTeam);
            this.flpPhongChat.Controls.Add(this.label1);
            this.flpPhongChat.Location = new System.Drawing.Point(731, 121);
            this.flpPhongChat.Name = "flpPhongChat";
            this.flpPhongChat.Size = new System.Drawing.Size(171, 588);
            this.flpPhongChat.TabIndex = 12;
            // 
            // radTeam
            // 
            this.radTeam.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radTeam.Checked = true;
            this.radTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTeam.Location = new System.Drawing.Point(3, 3);
            this.radTeam.Name = "radTeam";
            this.radTeam.Size = new System.Drawing.Size(164, 35);
            this.radTeam.TabIndex = 1;
            this.radTeam.TabStop = true;
            this.radTeam.Text = "Gửi cho tất cả";
            this.radTeam.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gửi Riêng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(417, 4);
            // 
            // lvEmoji
            // 
            this.lvEmoji.HideSelection = false;
            this.lvEmoji.Location = new System.Drawing.Point(4, 436);
            this.lvEmoji.MultiSelect = false;
            this.lvEmoji.Name = "lvEmoji";
            this.lvEmoji.Size = new System.Drawing.Size(724, 98);
            this.lvEmoji.TabIndex = 16;
            this.lvEmoji.UseCompatibleStateImageBehavior = false;
            this.lvEmoji.Visible = false;
            this.lvEmoji.SelectedIndexChanged += new System.EventHandler(this.lvEmoji_SelectedIndexChanged);
            this.lvEmoji.MouseLeave += new System.EventHandler(this.lvEmoji_MouseLeave);
            // 
            // imgAnh
            // 
            this.imgAnh.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAnh.ImageStream")));
            this.imgAnh.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAnh.Images.SetKeyName(0, "imageEmpty.jpg");
            // 
            // imgEmoji
            // 
            this.imgEmoji.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgEmoji.ImageSize = new System.Drawing.Size(16, 16);
            this.imgEmoji.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvTinNhan
            // 
            this.lvTinNhan.ContextMenuStrip = this.contextMenuStrip1;
            this.lvTinNhan.HideSelection = false;
            this.lvTinNhan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvTinNhan.LargeImageList = this.imgAnh;
            this.lvTinNhan.Location = new System.Drawing.Point(0, 121);
            this.lvTinNhan.Margin = new System.Windows.Forms.Padding(0);
            this.lvTinNhan.MultiSelect = false;
            this.lvTinNhan.Name = "lvTinNhan";
            this.lvTinNhan.Size = new System.Drawing.Size(728, 413);
            this.lvTinNhan.SmallImageList = this.imgAnh;
            this.lvTinNhan.StateImageList = this.imgAnh;
            this.lvTinNhan.TabIndex = 17;
            this.lvTinNhan.TileSize = new System.Drawing.Size(288, 64);
            this.lvTinNhan.UseCompatibleStateImageBehavior = false;
            this.lvTinNhan.View = System.Windows.Forms.View.Tile;
            this.lvTinNhan.SelectedIndexChanged += new System.EventHandler(this.lvTinNhan_SelectedIndexChanged);
            this.lvTinNhan.Click += new System.EventHandler(this.lvTinNhan_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaTinNhans,
            this.tsmnChuyenTiep});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // xoaTinNhans
            // 
            this.xoaTinNhans.Name = "xoaTinNhans";
            this.xoaTinNhans.Size = new System.Drawing.Size(167, 24);
            this.xoaTinNhans.Text = "Xóa Tin Nhắn";
            this.xoaTinNhans.Click += new System.EventHandler(this.xoaTinNhans_Click);
            // 
            // tsmnChuyenTiep
            // 
            this.tsmnChuyenTiep.Name = "tsmnChuyenTiep";
            this.tsmnChuyenTiep.Size = new System.Drawing.Size(167, 24);
            this.tsmnChuyenTiep.Text = "Chuyển Tiếp ";
            this.tsmnChuyenTiep.Click += new System.EventHandler(this.tsmnChuyenTiep_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnEmoji,
            this.toolStripSeparator2,
            this.tsbtnHinhAnh,
            this.toolStripSeparator1,
            this.tsbtnGuiTep});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(4, 537);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 71);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnEmoji
            // 
            this.tsbtnEmoji.AutoSize = false;
            this.tsbtnEmoji.AutoToolTip = false;
            this.tsbtnEmoji.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEmoji.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_emoji_50;
            this.tsbtnEmoji.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnEmoji.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEmoji.Name = "tsbtnEmoji";
            this.tsbtnEmoji.Size = new System.Drawing.Size(57, 57);
            this.tsbtnEmoji.Click += new System.EventHandler(this.tsbtnEmoji_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnHinhAnh
            // 
            this.tsbtnHinhAnh.AutoSize = false;
            this.tsbtnHinhAnh.AutoToolTip = false;
            this.tsbtnHinhAnh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHinhAnh.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_image_50;
            this.tsbtnHinhAnh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnHinhAnh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHinhAnh.Name = "tsbtnHinhAnh";
            this.tsbtnHinhAnh.Size = new System.Drawing.Size(57, 57);
            this.tsbtnHinhAnh.Click += new System.EventHandler(this.tsbtnHinhAnh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbtnGuiTep
            // 
            this.tsbtnGuiTep.AutoSize = false;
            this.tsbtnGuiTep.AutoToolTip = false;
            this.tsbtnGuiTep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGuiTep.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_file_48;
            this.tsbtnGuiTep.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnGuiTep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuiTep.Name = "tsbtnGuiTep";
            this.tsbtnGuiTep.Size = new System.Drawing.Size(57, 57);
            this.tsbtnGuiTep.Click += new System.EventHandler(this.tsbtnGuiTep_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xINCHAOToolStripMenuItem,
            this.cHAOBANToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 36);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // xINCHAOToolStripMenuItem
            // 
            this.xINCHAOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnXoaTin,
            this.tsmnChuyenTin});
            this.xINCHAOToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.xINCHAOToolStripMenuItem.Name = "xINCHAOToolStripMenuItem";
            this.xINCHAOToolStripMenuItem.Size = new System.Drawing.Size(123, 32);
            this.xINCHAOToolStripMenuItem.Text = "Chức Năng";
            // 
            // tsmnXoaTin
            // 
            this.tsmnXoaTin.Name = "tsmnXoaTin";
            this.tsmnXoaTin.Size = new System.Drawing.Size(215, 32);
            this.tsmnXoaTin.Text = "Xóa Tin Nhắn";
            this.tsmnXoaTin.Click += new System.EventHandler(this.tsmnXoaTin_Click);
            // 
            // tsmnChuyenTin
            // 
            this.tsmnChuyenTin.Name = "tsmnChuyenTin";
            this.tsmnChuyenTin.Size = new System.Drawing.Size(215, 32);
            this.tsmnChuyenTin.Text = "Chuyển Tiếp";
            this.tsmnChuyenTin.Click += new System.EventHandler(this.tsmnChuyenTin_Click);
            // 
            // cHAOBANToolStripMenuItem
            // 
            this.cHAOBANToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cHAOBANToolStripMenuItem.Name = "cHAOBANToolStripMenuItem";
            this.cHAOBANToolStripMenuItem.Size = new System.Drawing.Size(100, 32);
            this.cHAOBANToolStripMenuItem.Text = "Trợ Giúp";
            this.cHAOBANToolStripMenuItem.Click += new System.EventHandler(this.cHAOBANToolStripMenuItem_Click);
            // 
            // txtGui
            // 
            this.txtGui.Location = new System.Drawing.Point(5, 611);
            this.txtGui.Multiline = true;
            this.txtGui.Name = "txtGui";
            this.txtGui.Size = new System.Drawing.Size(594, 93);
            this.txtGui.TabIndex = 20;
            this.txtGui.TabStop = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.SystemColors.Window;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnHuy.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_stop_50;
            this.btnHuy.Location = new System.Drawing.Point(442, 43);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(70, 69);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.TabStop = false;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnGui
            // 
            this.btnGui.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnGui.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_send_64;
            this.btnGui.Location = new System.Drawing.Point(604, 610);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(124, 95);
            this.btnGui.TabIndex = 5;
            this.btnGui.TabStop = false;
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackColor = System.Drawing.Color.Red;
            this.btnKetNoi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnKetNoi.ForeColor = System.Drawing.Color.Transparent;
            this.btnKetNoi.Image = global::Server_TrinhPhucHieu.Properties.Resources.icons8_chain_start_50;
            this.btnKetNoi.Location = new System.Drawing.Point(354, 43);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(70, 69);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.TabStop = false;
            this.btnKetNoi.UseVisualStyleBackColor = false;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // frmServer_Hieu
            // 
            this.AcceptButton = this.btnGui;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(902, 711);
            this.Controls.Add(this.txtGui);
            this.Controls.Add(this.lvEmoji);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvTinNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.flpPhongChat);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.btnKetNoi);
            this.Location = new System.Drawing.Point(50, 50);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 758);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 758);
            this.Name = "frmServer_Hieu";
            this.Text = "Server - Phúc Hiếu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_Hieu_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Hieu_Load);
            this.flpPhongChat.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.FlowLayoutPanel flpPhongChat;
        private System.Windows.Forms.RadioButton radTeam;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ListView lvEmoji;
        private System.Windows.Forms.ImageList imgAnh;
        private System.Windows.Forms.ImageList imgEmoji;
        private System.Windows.Forms.ListView lvTinNhan;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnEmoji;
        private System.Windows.Forms.ToolStripButton tsbtnHinhAnh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xINCHAOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHAOBANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmnXoaTin;
        private System.Windows.Forms.ToolStripMenuItem tsmnChuyenTin;
        private System.Windows.Forms.ToolStripButton tsbtnGuiTep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xoaTinNhans;
        private System.Windows.Forms.ToolStripMenuItem tsmnChuyenTiep;
        private System.Windows.Forms.TextBox txtGui;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

