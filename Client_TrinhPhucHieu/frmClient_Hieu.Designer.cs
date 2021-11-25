
namespace Client_TrinhPhucHieu
{
    partial class frmClient_Hieu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient_Hieu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.troGiupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnXoaTin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnChuyenTin = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trogiup = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.imgAnh = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnEmoji = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnHinhAnh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnGuiTep = new System.Windows.Forms.ToolStripButton();
            this.flpPhongChat = new System.Windows.Forms.FlowLayoutPanel();
            this.radTeam = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lvEmoji = new System.Windows.Forms.ListView();
            this.imgEmoji = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaTinNhans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnChuyenTiep = new System.Windows.Forms.ToolStripMenuItem();
            this.lvTinNhan = new System.Windows.Forms.ListView();
            this.rtxGhi = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.btnGui = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flpPhongChat.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.troGiupToolStripMenuItem,
            this.sToolStripMenuItem,
            this.trogiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(902, 36);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // troGiupToolStripMenuItem
            // 
            this.troGiupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnXoaTin,
            this.tsmnChuyenTin});
            this.troGiupToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.troGiupToolStripMenuItem.Name = "troGiupToolStripMenuItem";
            this.troGiupToolStripMenuItem.Size = new System.Drawing.Size(123, 32);
            this.troGiupToolStripMenuItem.Text = "Chức Năng";
            this.troGiupToolStripMenuItem.Click += new System.EventHandler(this.troGiupToolStripMenuItem_Click);
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
            this.tsmnChuyenTin.Text = "Chuyển Tiếp ";
            this.tsmnChuyenTin.Click += new System.EventHandler(this.tsmnChuyenTin_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterToolStripMenuItem});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(14, 32);
            // 
            // enterToolStripMenuItem
            // 
            this.enterToolStripMenuItem.Name = "enterToolStripMenuItem";
            this.enterToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            // 
            // trogiup
            // 
            this.trogiup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trogiup.Name = "trogiup";
            this.trogiup.Size = new System.Drawing.Size(100, 32);
            this.trogiup.Text = "Trợ Giúp";
            this.trogiup.Click += new System.EventHandler(this.tr_Click);
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTen.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtTen.Location = new System.Drawing.Point(3, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(168, 50);
            this.txtTen.TabIndex = 6;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // imgAnh
            // 
            this.imgAnh.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAnh.ImageStream")));
            this.imgAnh.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAnh.Images.SetKeyName(0, "imageEmpty.jpg");
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
            this.toolStrip1.Location = new System.Drawing.Point(174, 536);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 74);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnEmoji
            // 
            this.tsbtnEmoji.AutoSize = false;
            this.tsbtnEmoji.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEmoji.Image = global::Client_TrinhPhucHieu.Properties.Resources.icons8_emoji_50;
            this.tsbtnEmoji.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnEmoji.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEmoji.Name = "tsbtnEmoji";
            this.tsbtnEmoji.Size = new System.Drawing.Size(57, 57);
            this.tsbtnEmoji.Text = "Emoji";
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
            this.tsbtnHinhAnh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHinhAnh.Image = global::Client_TrinhPhucHieu.Properties.Resources.icons8_image_50;
            this.tsbtnHinhAnh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnHinhAnh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHinhAnh.Name = "tsbtnHinhAnh";
            this.tsbtnHinhAnh.Size = new System.Drawing.Size(57, 57);
            this.tsbtnHinhAnh.Text = "Hình Ảnh";
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
            this.tsbtnGuiTep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGuiTep.Image = global::Client_TrinhPhucHieu.Properties.Resources.icons8_file_48;
            this.tsbtnGuiTep.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnGuiTep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuiTep.Name = "tsbtnGuiTep";
            this.tsbtnGuiTep.Size = new System.Drawing.Size(57, 57);
            this.tsbtnGuiTep.Text = "Tệp";
            this.tsbtnGuiTep.Click += new System.EventHandler(this.tsbtnGuiTep_Click);
            // 
            // flpPhongChat
            // 
            this.flpPhongChat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flpPhongChat.Controls.Add(this.radTeam);
            this.flpPhongChat.Controls.Add(this.label1);
            this.flpPhongChat.Location = new System.Drawing.Point(0, 97);
            this.flpPhongChat.Name = "flpPhongChat";
            this.flpPhongChat.Size = new System.Drawing.Size(171, 609);
            this.flpPhongChat.TabIndex = 13;
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
            this.radTeam.CheckedChanged += new System.EventHandler(this.radTeam_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gửi Riêng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvEmoji
            // 
            this.lvEmoji.HideSelection = false;
            this.lvEmoji.Location = new System.Drawing.Point(174, 438);
            this.lvEmoji.Name = "lvEmoji";
            this.lvEmoji.Size = new System.Drawing.Size(724, 98);
            this.lvEmoji.TabIndex = 15;
            this.lvEmoji.UseCompatibleStateImageBehavior = false;
            this.lvEmoji.Visible = false;
            this.lvEmoji.SelectedIndexChanged += new System.EventHandler(this.lvEmoji_SelectedIndexChanged);
            this.lvEmoji.MouseLeave += new System.EventHandler(this.lvEmoji_MouseLeave);
            // 
            // imgEmoji
            // 
            this.imgEmoji.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgEmoji.ImageSize = new System.Drawing.Size(16, 16);
            this.imgEmoji.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaTinNhans,
            this.tsmnChuyenTiep});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 52);
            // 
            // xoaTinNhans
            // 
            this.xoaTinNhans.Name = "xoaTinNhans";
            this.xoaTinNhans.Size = new System.Drawing.Size(183, 24);
            this.xoaTinNhans.Text = "Xóa Tin Nhắn";
            this.xoaTinNhans.Click += new System.EventHandler(this.xóaTinNhắnToolStripMenuItem1_Click);
            // 
            // tsmnChuyenTiep
            // 
            this.tsmnChuyenTiep.Name = "tsmnChuyenTiep";
            this.tsmnChuyenTiep.Size = new System.Drawing.Size(183, 24);
            this.tsmnChuyenTiep.Text = "Chuyển Tiếp Tin";
            this.tsmnChuyenTiep.Click += new System.EventHandler(this.tsmnChuyenTiep_Click);
            // 
            // lvTinNhan
            // 
            this.lvTinNhan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lvTinNhan.ContextMenuStrip = this.contextMenuStrip1;
            this.lvTinNhan.HideSelection = false;
            this.lvTinNhan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvTinNhan.LargeImageList = this.imgAnh;
            this.lvTinNhan.Location = new System.Drawing.Point(174, 99);
            this.lvTinNhan.Margin = new System.Windows.Forms.Padding(0);
            this.lvTinNhan.MultiSelect = false;
            this.lvTinNhan.Name = "lvTinNhan";
            this.lvTinNhan.Size = new System.Drawing.Size(728, 437);
            this.lvTinNhan.SmallImageList = this.imgAnh;
            this.lvTinNhan.StateImageList = this.imgAnh;
            this.lvTinNhan.TabIndex = 14;
            this.lvTinNhan.TileSize = new System.Drawing.Size(288, 64);
            this.lvTinNhan.UseCompatibleStateImageBehavior = false;
            this.lvTinNhan.View = System.Windows.Forms.View.Tile;
            this.lvTinNhan.SelectedIndexChanged += new System.EventHandler(this.lvTinNhan_SelectedIndexChanged);
            this.lvTinNhan.Click += new System.EventHandler(this.lvTinNhan_Click);
            // 
            // rtxGhi
            // 
            this.rtxGhi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtxGhi.Location = new System.Drawing.Point(175, 611);
            this.rtxGhi.Multiline = true;
            this.rtxGhi.Name = "rtxGhi";
            this.rtxGhi.Size = new System.Drawing.Size(595, 95);
            this.rtxGhi.TabIndex = 16;
            this.rtxGhi.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.txtTen);
            this.flowLayoutPanel1.Controls.Add(this.btnKetNoi);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(902, 58);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnKetNoi.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnKetNoi.Image = global::Client_TrinhPhucHieu.Properties.Resources.icons8_chain_start_48;
            this.btnKetNoi.Location = new System.Drawing.Point(177, 3);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(71, 54);
            this.btnKetNoi.TabIndex = 9;
            this.btnKetNoi.TabStop = false;
            this.btnKetNoi.UseVisualStyleBackColor = false;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnGui
            // 
            this.btnGui.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGui.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGui.Image = global::Client_TrinhPhucHieu.Properties.Resources.icons8_send_64;
            this.btnGui.Location = new System.Drawing.Point(773, 611);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(124, 95);
            this.btnGui.TabIndex = 3;
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // frmClient_Hieu
            // 
            this.AcceptButton = this.btnGui;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(902, 711);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.rtxGhi);
            this.Controls.Add(this.lvEmoji);
            this.Controls.Add(this.flpPhongChat);
            this.Controls.Add(this.lvTinNhan);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(10, 10);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 758);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 758);
            this.Name = "frmClient_Hieu";
            this.Text = "Client - Phúc Hiếu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_Hieu_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Hieu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flpPhongChat.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem troGiupToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterToolStripMenuItem;
        private System.Windows.Forms.ImageList imgAnh;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnEmoji;
        private System.Windows.Forms.ToolStripButton tsbtnGuiTep;
        private System.Windows.Forms.FlowLayoutPanel flpPhongChat;
        private System.Windows.Forms.RadioButton radTeam;
        private System.Windows.Forms.ListView lvEmoji;
        private System.Windows.Forms.ImageList imgEmoji;
        private System.Windows.Forms.ToolStripButton tsbtnHinhAnh;
        private System.Windows.Forms.ToolStripMenuItem tsmnXoaTin;
        private System.Windows.Forms.ToolStripMenuItem tsmnChuyenTin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xoaTinNhans;
        private System.Windows.Forms.ToolStripMenuItem tsmnChuyenTiep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvTinNhan;
        private System.Windows.Forms.TextBox rtxGhi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem trogiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

