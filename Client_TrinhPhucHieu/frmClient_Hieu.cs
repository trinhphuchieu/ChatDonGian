using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_TrinhPhucHieu
{
    public partial class frmClient_Hieu : Form
    {
        public frmClient_Hieu()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            chenEmoji();
        }
        /// <summary>
        /// DAU - TRINH PHUC HIEU - 18CT1
        /// </summary>
        
        /*Mã hóa dùng cho việc gửi dữ liệu
        * !####@ dùng cho việc gửi lần đầu
        * !@@@@# dùng cho việc xóa
        * !$$$$# dùng cho việc thoát
        * !----# dùng cho việc chát riêng
        * !^^^^# dùng để hiển thị tên người gửi ảnh
        * !----( dùng cho id xóa
        */
       
        // thuộc tính 
        Socket mayKhach;
        IPEndPoint diaChiEP;
        private List<RadioButton> rad_ThanhVien = new List<RadioButton>();
        private int sL_KetNoi = 0;
        private int id = -1;
        List<String> DanhSachUser = new List<string>();
        private int countTinRieng = 0;
        private int id1 = 0;
        private int chonItem = -1;
        private void ketNoi()
        {
            if(txtTen.Text =="")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Đăng Nhập");
                return;
            }
            else
            {
                if(txtTen.Text.Contains(" "))
                {
                    MessageBox.Show("Tên Đăng Nhập Không được chứa ký tự cách");
                    txtTen.Text = "";
                    return;
                }
                string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                foreach (var item in specialChar)
                {
                    if (txtTen.Text.Contains(item))
                    {
                        MessageBox.Show("Tên Đăng Nhập Không được chứa ký tự đặc biết");
                        txtTen.Text = "";
                        return;
                    }
                }
            }
            btnKetNoi.Enabled = false;
            txtTen.Enabled = false;
            mayKhach = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.diaChiEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            try
            {
                mayKhach.Connect(this.diaChiEP);
            }
            catch
            {
                txtTen.Text = "";
                MessageBox.Show("Máy Chủ Chưa Kết nối vui lòng thử lại");
            }
            Thread nhan = new Thread(Nhan_MayChu);
            nhan.IsBackground = true;
            nhan.Start();
        }
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            ketNoi();
        }


        public object GiaiMa(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }


        // tạo radio button danh sách client gửi
        private void TaoNutRad(String s)
        {
           
            RadioButton rad = new RadioButton()
            {
                Width = 164,
                Height = 35,
            };
            rad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            rad.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            rad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      

            rad.Text = s;
            // radNhom_Chat[sL_KetNoi] = rad;
            rad.Click += radXuLyNhomChat;
            rad_ThanhVien.Add(rad);
            //radNhom_Chat[sL_KetNoi].Text = s;
            // điều khiển luồng hiện tại
            this.Invoke((MethodInvoker)delegate
            {
                //flpPhongChat.Controls.Add(radNhom_Chat[sL_KetNoi]);
                if(rad_ThanhVien[sL_KetNoi].Text != txtTen.Text) flpPhongChat.Controls.Add(rad_ThanhVien[sL_KetNoi]);

            });
            
            // radNhom_Chat[sL_KetNoi].Click += radXuLyNhomChat;
            sL_KetNoi += 1;
        }

        private void radXuLyNhomChat(object sender, EventArgs e)
        {

        }


        // nhận từ phía máy chủ
        // 
       
        void nhanLanDau(string s)
        {
            
            try
            {
                string[] line = s.Split('\n');
                string[] s1 = line[1].Split('!');

                string[] s2 = s1[0].Trim().Split(' ');

                ListViewGroup nhom = new ListViewGroup();
                nhom.Header = line[0];
                lvTinNhan.Groups.Add(nhom);
                lvTinNhan.Items.Add(s2[s2.Length - 1] + " đã tham gia chat !");
                lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];

                lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);


                if (rad_ThanhVien == null)
                {
                    foreach (string sn in s2)
                    {
                        
                        DanhSachUser.Add(sn);
                        
                        TaoNutRad(sn);
                    }
                    return;
                }
                for (int i = sL_KetNoi; sL_KetNoi < s2.Length; i++)
                {
                    DanhSachUser.Add(s2[i]);
                    TaoNutRad(s2[i]);
                }

            }
            catch
            {

            }
              
            

        }

        // hàm xóa tn liên sv
        private void XoaTN(string s)
        {

            string[] s1 = s.Split('#');


            int xoa = int.Parse(s1[s1.Length - 1]);
           
            if(lvTinNhan.Items.Count < xoa)
            {
                return;
            }

            try
            {
                if(countTinRieng > xoa)
                {
                    xoa = xoa + countTinRieng;

                }
                else
                {
                    xoa = xoa - countTinRieng;
                } 
                if (lvTinNhan.Items[xoa] == null) return;
                if (lvTinNhan.Items[xoa].ImageKey.Length > 0) lvTinNhan.Items[xoa].ImageIndex = 0;
                lvTinNhan.Items[xoa].Text = "Đã Xóa";
            }
            catch
            {

            }
        }
        void Xoa_NguoiChat(string s)
        {
            
            string[] s1 = s.Split('#');
            int so = int.Parse(s1[s1.Length - 1]);
            DanhSachUser[so] = "";
            rad_ThanhVien[so].Dispose();
            //radNhom_Chat[so].Visible = false;
            radTeam.Checked = true;
        }
        void GuiRieng()
        {
            string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
            for (int i = 0; i < rad_ThanhVien.Count; i++)
            {
                if (rad_ThanhVien[i] != null)
                {
                    if (rad_ThanhVien[i].Checked)
                    {
                       
                        Gui("!----#" + i + "\n" + txtTen.Text + " Gửi vào ngày " + s + "\n"+ rtxGhi.Text);
                        break;
                    }
                }

            }
            
        }

        void GuiRiengTinAnh()
        {
            string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
            string guicho2 = "";
            bool kt = true;

            for (int i = 0; i < rad_ThanhVien.Count; i++)
            {
                if (rad_ThanhVien[i] != null)
                {
                    if (rad_ThanhVien[i].Text == txtTen.Text) continue;
                    if (rad_ThanhVien[i].Checked)
                    {
                        if(kt)
                        {
                            Gui(rad_ThanhVien[i].Text + "!$$$$(" + "\n" + txtTen.Text + " Gửi vào ngày " + s + "\n");
                            kt = false;
                        }    
                    }
                    else
                    {
                         guicho2 = guicho2 + rad_ThanhVien[i].Text+  " "; 
                    }
                }
            }
           
            Gui(guicho2.Trim() + "!----()))");
            
        }

        void xoaAnh()
        {
            lvTinNhan.Items.RemoveAt(0);
        }
        void HienThiTenHinhAnh(string s)
        {
            
            string[] s1 = s.Split('!');
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = s1[0];
            
            lvTinNhan.Groups.Add(nhom);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
        }
        private void Nhan_MayChu()
        {

            try
            {
                
                Gui(txtTen.Text+" Gửi vào ngày "+DateTime.Now.ToString("dd-MM-yyyy lúc HH:mm:ss")+ "\n" + txtTen.Text + " Đã kết nối!####@");
                byte[] nhan1 = new byte[1024 * 5000];

                while (true)
                {
                    byte[] nhan = new byte[1024 * 5000];
                    mayKhach.Receive(nhan);
                    object obj = GiaiMa(nhan);

                    // dữ liệu nhận
                    if (obj.GetType().ToString() == "System.String")
                    {
                        string s = GiaiMa(nhan).ToString();

                        // nhận lần đầu dùng để cập nhật danh sách Client kết nối
                        if (s.Contains("!####@"))
                        {
                            nhanLanDau(s);
                            continue;
                            /*
                            if (s.ToString().Contains(txtTen.Text))
                            {
                                !^^^^#
                            }
                            */
                        }
                        // Lưu File server gửi tới
                        if (s.Contains("@!@!@!@~"))
                        {
                            
                            LuuFile(s);
                            continue;
                           
                            }

                        // xóa ảnh nếu gửi riêng ảnh từ client - client
                        if (s.Contains("----()))"))
                        {
                            
                            xoaAnh();
                            continue;
                        }

                       
                        // xóa user
                        if (s.Contains("!$$$$#"))
                        {
                            Xoa_NguoiChat(s);
                            continue;
                        }

                        // nhận riêng
                        if (s.Contains("!----#"))
                        {
                            HienThiTinNhanGuiVe(s);
                            continue;
                        }
                        // Hiển Thị tên ảnh người gửi
                        if (GiaiMa(nhan).ToString().Contains("!^^^^#"))
                        {
                            
                            HienThiTenHinhAnh(GiaiMa(nhan).ToString());
                            continue;
                        }

                        // x0á tn liên server
                        if (s.ToString().Contains("!@@@@#"))
                        {

                            XoaTN(s);
                            continue;
                        }
                        HienThiTinNhanGuiVe((String)GiaiMa(nhan));

                    }
                    else if (obj.GetType().ToString() == "System.Drawing.Bitmap")
                    {
                        id++;
                        Image image = (Image)GiaiMa(nhan);
                        imgAnh.Images.Add(id + "", image);
                        ListViewItem item = new ListViewItem();
                        item.ImageKey = id + "";
                        lvTinNhan.Items.Add(item);
                    }

                }
            }
            catch
            {

            }
        }

        

        // Lưu File Server Gửi Tới
        void LuuFile(object s)
        {

            this.Invoke((MethodInvoker)delegate
            {
               
                string[] s12 = s.ToString().Split(',');
                int size;
                byte[] data = new byte[1024];
                SaveFileDialog luu = new SaveFileDialog();
                luu.Title = " Lưu File";
                luu.FileName = s12[0];
                luu.Filter = "Định Dạng |*.docx;*.rar;*.;*.txt;*.xls";
                long length = long.Parse(s12[1]);
                byte[] buffer = new byte[1024];
                byte[] fsize = new byte[length]; //khai bao mang byte de chua du lieu
                long n = length / buffer.Length;  // tính số frame sẽ được gửi qua

                while (true)
                {
                    size = mayKhach.Receive(data);
                    for (int i = 0; i < n; i++)
                    {
                        size = mayKhach.Receive(fsize, fsize.Length, SocketFlags.None);
                    }
                    luu.ShowDialog();
                    
                    
                    FileStream fs = new FileStream(luu.FileName, FileMode.Create);  // luu file s[0] vao duong dan s[1] 
                    fs.Write(fsize, 0, fsize.Length);
                     fs.Close();
                    
                    break;
                }
                
            });





        }
        // mã hóa tin nhắn
        byte[] MaHoa(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }


        // gửi tin bên client
        void Gui(String s)
        {
            if (mayKhach == null) return;
            byte[] gui = new byte[1024 * 5000];
            gui = MaHoa(s);
            try
            {
                mayKhach.Send(gui);
            }
            catch
            {

            }
        }

        // nút gửi
        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                string s = DateTime.Now.ToString("dd-MM-yyyy lúc HH:mm:ss");
                if (this.rtxGhi.Text.Length > 0)
                {
                    // kiểm tra gửi riêng cho client hay mọi người
                    if (radTeam.Checked)
                    {


                        Gui(txtTen.Text + " Gửi vào ngày " + s + "\n" + this.rtxGhi.Text);


                    }
                    else
                    {
                        GuiRieng();
                        countTinRieng++;
                    }

                    GuiIDXoa();


                    HienThiTinNhan(s);
                    
                    rtxGhi.Clear();
                }
            }
            catch
            {

            }

        }

        // lấy id gửi để xóa tin của mình liên server
        void GuiIDXoa()
        {
            try
            {
                if (mayKhach != null)
                {
                    byte[] gui = new byte[1024 * 5000];
                    gui = MaHoa("!----(" + txtTen.Text + "-" + lvTinNhan.Items.Count.ToString());
                    mayKhach.Send(gui);
                }
            }
            catch
            {

            }
            
        }

        // trả về địa chỉ gửi
        String diaChiGui()
        {
            string s = DateTime.Now.ToString("dd-MM-yyyy lúc HH:mm:ss");
             return txtTen.Text + " Gửi vào ngày " + s+"\n";
        }

        // hiện tin nhắn
        private void HienThiTinNhan(string s)
        {
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = txtTen.Text + " Gửi vào ngày " + s;
            lvTinNhan.Groups.Add(nhom);
            lvTinNhan.Items.Add(this.rtxGhi.Text);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }


        // hiện tin gửi về 
        private void HienThiTinNhanGuiVe(string s)
        {
            string[] line = s.Split('\n');
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header =  line[0];
            lvTinNhan.Groups.Add(nhom);
            string mess = "";
            for(int i = 1; i < line.Length;i++)
            {
                mess += line[i];
            }    
            lvTinNhan.Items.Add(mess);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }

        // chèn emoji
        private void chenEmoji()
        {
            string path = Environment.CurrentDirectory.ToString() + @"\Emoij"; // lấy đường dẫn

            string[] files = Directory.GetFiles(path); // lấy tên file là ảnh

            foreach (String f in files)
            {
                Image img = Image.FromFile(f);  // từ cái file đó chuyển qua định dạng ảnh
                imgEmoji.Images.Add(img); // bỏ vào img list
            }
            this.lvEmoji.View = View.LargeIcon;
            this.imgEmoji.ImageSize = new Size(60, 60);

            this.lvEmoji.LargeImageList = this.imgEmoji;
            for (int i = 0; i < this.imgEmoji.Images.Count; i++)
            {
                this.lvEmoji.Items.Add(" ", i);
            }

        }
        private void rtxTinNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmClient_Hieu_Load(object sender, EventArgs e)
        {

        }

        private void frmClient_Hieu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mayKhach != null)
            {
                try
                {
                    Gui(txtTen.Text +" Gửi vào ngày "+DateTime.Now.ToString("dd-MM-yyyy lúc HH:mm:ss") +"\n"+txtTen.Text + " Đã thoát kết nối" );
                }
                catch
                {

                }
                mayKhach.Close();
            }
        }

        private void radTeam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool ktLV = true;
        private void tsbtnEmoji_Click(object sender, EventArgs e)
        {
            if (ktLV)
            {
                lvEmoji.Visible = true;
                ktLV = false;
            }
            else
            {
                lvEmoji.Visible = false;
                ktLV = true;
            }
        }

        private void lvEmoji_MouseLeave(object sender, EventArgs e)
        {
            lvEmoji.Visible = false;
            ktLV = true;
        }

        //nút hình ảnh
        private void tsbtnHinhAnh_Click(object sender, EventArgs e)
        {
            if (mayKhach == null) return;
            OpenFileDialog Mo_Anh = new OpenFileDialog();
            Mo_Anh.Title = "Chọn Ảnh";
            Mo_Anh.Filter = "Hinh Anh|*.bmp;*.jpg;*.gif;*.png;*.tif";
            try
            {
                if (Mo_Anh.ShowDialog() == DialogResult.OK)
                {

                    string fileName = Mo_Anh.FileName;
                    if (fileName.EndsWith(".tif") || fileName.EndsWith(".png") || fileName.EndsWith(".bmp") || fileName.EndsWith(".gif")
                        || fileName.EndsWith(".jpg"))
                    {
                        byte[] nhan = new byte[1024 * 5000];
                        nhan = MaHoa(Image.FromFile(fileName));
                        mayKhach.Send(nhan);
                        string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
                        string guiTen = txtTen.Text + " Gửi vào ngày " + s;
                        // gửi ảnh lên server

                        // hiển thị ảnh
                        id++;
                        Image image = Image.FromFile(fileName);
                        imgAnh.Images.Add(id + "", image);
                        ListViewItem item = new ListViewItem();
                        item.ImageKey = id + "";
                        lvTinNhan.Items.Add(item);

                        // gửi riêng client hay chung
                        if (radTeam.Checked)
                        {
                            nhan = MaHoa(guiTen + "!^^^^#" + "\n" + "(" + txtTen.Text + "-" + (lvTinNhan.Items.Count - 1 >= 1 ? lvTinNhan.Items.Count - 1 : lvTinNhan.Items.Count).ToString());
                            mayKhach.Send(nhan);
                        }
                        else
                        {
                            
                            GuiRiengTinAnh();
                            HienThiTenHinhAnh(guiTen + "!^^^^#" + "\n" + "(" + txtTen.Text + "-" + (lvTinNhan.Items.Count - 1 >= 1 ? lvTinNhan.Items.Count - 1 : lvTinNhan.Items.Count).ToString());
                            countTinRieng++;
                            
                        }

                        lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
                    }
                    

                }
               

            }
            catch
            {

            }
        }
      
        // gửi id xóa ảnh
        void GuiIDXoaAnh()
        {
            byte[] gui = new byte[1024 * 5000];
            gui = MaHoa("!----(" + txtTen.Text + "-" + (lvTinNhan.Items.Count-1  >=1 ? lvTinNhan.Items.Count - 1: lvTinNhan.Items.Count).ToString());;
            mayKhach.Send(gui);
        }

        // gửi tệp 
        private void tsbtnGuiTep_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chỉ hổ trợ gửi bên phía Server");
            if (mayKhach == null) return;
            OpenFileDialog Mo_Anh = new OpenFileDialog();
            Mo_Anh.Title = "Chọn Ảnh";
            Mo_Anh.Filter = "Tep|*.rar,";
            try
            {
                if (Mo_Anh.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Mo_Anh.FileName;
                    byte[] nhan = new byte[1024 * 5000];
                    nhan = MaHoa(Image.FromFile(fileName));

                    //

                }
            }
            catch
            {

            }
        }
        
        private void lvEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mayKhach == null) return;

            if (lvEmoji.SelectedIndices.Count <= 0) return;
            if (lvEmoji.FocusedItem == null) return;
            id1 = lvEmoji.SelectedIndices[0];
            if (id1 < 0) return;
            byte[] nhan = new byte[1024 * 5000];
            // gửi
            nhan = MaHoa(imgEmoji.Images[id1]);
            mayKhach.Send(nhan);

            // hiển thị 
            id++;
            Image image = (Image)imgEmoji.Images[id1];
            imgAnh.Images.Add(id + "", image);
            ListViewItem item = new ListViewItem();
            item.ImageKey = id + "";
            lvTinNhan.Items.Add(item);
            string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
            string guiTen = txtTen.Text + " Gửi vào ngày " + s;
          

            if (radTeam.Checked)
            {
                nhan = MaHoa(guiTen + "!^^^^#" + "\n" + "(" + txtTen.Text + "-" + (lvTinNhan.Items.Count - 1 >= 1 ? lvTinNhan.Items.Count - 1 : lvTinNhan.Items.Count).ToString());
                mayKhach.Send(nhan);
            }
            else
            {

                GuiRiengTinAnh();
                HienThiTenHinhAnh(guiTen + "!^^^^#" + "\n" + "(" + txtTen.Text + "-" + (lvTinNhan.Items.Count - 1 >= 1 ? lvTinNhan.Items.Count - 1 : lvTinNhan.Items.Count).ToString());
                countTinRieng++;
            }
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }


        // lấy tin xóa
        private void lvTinNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       

        private void lvTinNhan_Click(object sender, EventArgs e)
        {
            if (lvTinNhan.FocusedItem == null) return;
        
            
            if (lvTinNhan.SelectedIndices.Count < 0) return;

            try
            {
                chonItem = lvTinNhan.SelectedIndices[0];
            }
            catch
            {

            }
        }

        private void tsbtnNhanTep_Click(object sender, EventArgs e)
        {

        }



        // xóa tin
       
        private void tsmnXoaTin_Click(object sender, EventArgs e)
        {
            
            if (chonItem < 0) return;
            if (lvTinNhan.Items[chonItem].ImageKey.Length > 0) lvTinNhan.Items[chonItem].ImageIndex = 0;
            lvTinNhan.Items[chonItem].Text = "Đã Xóa";
            
            Gui("!@@@@#" + txtTen.Text+"-"+chonItem.ToString());
        }

        private void xóaTinNhắnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsmnXoaTin.PerformClick();
        }

        private void tsmnChuyenTin_Click(object sender, EventArgs e)
        {
            tsmnChuyenTiep.PerformClick();
        }


        // CHuyển tiếp tin nhắn
        private void tsmnChuyenTiep_Click(object sender, EventArgs e)
        {
            if (lvTinNhan.FocusedItem == null) return;
            if (lvTinNhan.SelectedIndices.Count < 0) return;
            object Mes;

            string diaChiAnh = "";
            try
            {
                if (lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].Text != "")
                {
                    Mes = (string)(txtTen.Text + " chuyển tiếp tin " + lvTinNhan.Groups[lvTinNhan.SelectedIndices[0]].Header.ToString() + " \n" + lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].Text);
                }
                else
                {
                    diaChiAnh = (string)(txtTen.Text + " chuyển tiếp tin " + lvTinNhan.Groups[lvTinNhan.SelectedIndices[0]].Header.ToString());
                    Mes = (Image)imgAnh.Images[lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].ImageKey];

                }
                if (mayKhach == null) return;
                frmChuyenTiep s = new frmChuyenTiep(DanhSachUser, mayKhach, Mes, diaChiAnh);
                s.Show(this);
            }
            catch { 
            }
            
            
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void troGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tr_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nTên UserName không được trùng \nChat \nGửi \nXóa\nChuyểnTiếp\nGửi Tệp\nGửiEmoji và Ảnh");
        }

        private void tsmnThuHoi_Click(object sender, EventArgs e)
        {

        }
    }
}
