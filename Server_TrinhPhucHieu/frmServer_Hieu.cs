using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server_TrinhPhucHieu
{
    public partial class frmServer_Hieu : Form
    {
        public frmServer_Hieu()
        {
          
            InitializeComponent();
            chenEmoji();
            CheckForIllegalCrossThreadCalls = false; ;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
             
        }
        /// <summary>
        /// DAU - Trịnh Phúc Hiếu 18CT1 
        /// 
        /// </summary>
        /// 

        // Thược tính
        Dictionary<String,String> xoaTinNhan = new Dictionary<String, String>();  // dùng để xóa tin nhắn phía client với các client khác
        List<String> viTriTinNhanDau = new List<string>();
        // Nếu xóa tin nhắn client gửi đến  các client khác bắt buộc các client khác chưa có gửi tin nhắn riêng
        Socket mayChu;
        Socket mayKhach;
        List<Socket> mayKhach_ChapNhan; // danh sách client socket
        IPAddress diaChiIP;
        IPEndPoint diaChiEP;
        List<String> mayKhachKN = new List<string>(); // lấy tên client đến
        private int sL_KetNoi = 0;
        public RadioButton[] radNhom_Chat = new RadioButton[20]; // lưu lại nút tạo client
        private int id = -1; 
         bool check = true; // kiểm tra dừng


        /*Mã hóa dùng cho việc gửi tin Nhắn để nhận biết client gửi cho Server điều gì thực hiện-----------------------
       * !####@ dùng cho việc gửi lần đầu
       * !@@@@# dùng cho việc xóa
       * !$$$$# dùng cho việc thoát
       * !----# dùng cho việc gửi riêng tư
       * !^^^^# dùng cho việc gửi tên ảnh
       */
        private void batDau()
        {
            try
            {

                mayKhach_ChapNhan = new List<Socket>();
             
                while (true)
                {
                    mayChu.Listen(10);
                    mayKhach = mayChu.Accept();
                    byte[] nhan = new byte[1024*5000];
                    mayKhach.Receive(nhan);
                    object objA = GiaiMa(nhan);
                    String s = (String)GiaiMa(nhan);
                    userXoa(s); // lấy địa chị tin nhắn gửi lần đầu đến server
                    mayKhach_ChapNhan.Add(mayKhach);
                   
                    GuiLanDau(s);   /// khi Server chấp nhận Client thì cho nhận thông tin Client
                    TaoNutRad(s);   // Tạo Nút Thành Viên
                    // string s = Encoding.UTF8.GetString(nhan);
                    string[] line = s.Split('\n');
                    // chỗ sửa
                    ListViewGroup nhom = new ListViewGroup();
                    nhom.Header = line[0];
                    lvTinNhan.Groups.Add(nhom);   
              
                    string[] s11 = line[1].Split('!');
                    lvTinNhan.Items.Add(s11[0]);
                    lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];

                    //
                    Thread s1 = new Thread(Nhan_MayKhach);
                    s1.IsBackground = true;
                    s1.Start(mayKhach);
                }
            }
            catch
            {
                mayChu = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                diaChiEP = new IPEndPoint(diaChiIP, 12345);
            }
        }

        // tạo máy khách đăng ký
        private void TaoNutRad(String s)
        {
            string[] line = s.Split('\n'); 
            string[] s1 = line[1].Split(' ');
           
            // điều khiển luồng hiện tại
            this.Invoke((MethodInvoker)delegate
            {

                radNhom_Chat[sL_KetNoi] = new RadioButton()
                {
                    Width = 122,
                    Height = 30,
                };
                radNhom_Chat[sL_KetNoi].Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                radNhom_Chat[sL_KetNoi].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                radNhom_Chat[sL_KetNoi].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                radNhom_Chat[sL_KetNoi].Text = s1[0];
                flpPhongChat.Controls.Add(radNhom_Chat[sL_KetNoi]);
            });
            
            sL_KetNoi += 1;
            
        }
        private void radXuLyNhomChat(object sender, EventArgs e)
        {
          
        }
      



        // nhận id Xóa
        void nhanIDXoa(string s)
        {
            string[] s1  = s.Split('(');
           
            int i = lvTinNhan.Items.Count;
            if (!xoaTinNhan.ContainsKey(s1[s1.Length-1]))
            {
                xoaTinNhan.Add(s1[s1.Length - 1], (i).ToString());
            }
          
        }
        // xóa tin nhắn mọi phía
        private void XoaTN(string s)
        {
            
            string[] s1 = s.Split('#');
           
            string xoa = xoaTinNhan.ContainsKey(s1[s1.Length - 1]) == true ? xoaTinNhan[s1[s1.Length - 1]] : "";
            
            if (xoa == "")
            {
                return;
            }
           
            int idXoa = int.Parse(xoa) <= 1? int.Parse(xoa) : int.Parse(xoa)-1;
            
            Gui(idXoa+"");
            try
            {
                if (lvTinNhan.Items[idXoa] == null) return;
                if (lvTinNhan.Items[idXoa].ImageKey.Length > 0) lvTinNhan.Items[idXoa].ImageIndex = 0;
                lvTinNhan.Items[idXoa].Text = "Đã Xóa";
            }
            catch
            {

            }
        }
     


       
        
        // Nhận từ client gửi về roỳ gửi lại cho client khác trừ client nhận
        void TinRiengMayKhach(string s)
        {
            try
            {
               
                string[] lines = s.Split('\n');
                string[] guiCho = lines[0].Split('#');
               
                int idGui = int.Parse(guiCho[guiCho.Length - 1]);
               
                string mess = "";
                for (int i = 1; i < lines.Length; i++)
                {
                    mess += lines[i]+"\n";
                }
                byte[] gui = new byte[5000 * 1024];
                gui = MaHoa(mess);
                mayKhach_ChapNhan[idGui].Send(gui);
                HienThiTinNhanGuiRieng(mess,idGui);
            }
            catch
            {
                
            }
        }



        // tách để lấy id xóa
        
        private void userXoa(string s)
        {
            int i = lvTinNhan.Items.Count; 
            string[] s1 = s.Split(' ');
            if(!xoaTinNhan.ContainsKey(s1[0]+"-"+(i).ToString()))
            {
                viTriTinNhanDau.Add(s1[0] + "-" + (0).ToString()+":"+(i).ToString());
                xoaTinNhan.Add(s1[0]+"-"+(0).ToString(), (i).ToString());
            }

        }

        // tin nhắn gửi riêng cho client
        private void HienThiTinNhanGuiRieng(string s,int id)
        {
            string[] line = s.Split('\n');
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = line[0] + " gửi cho " + (mayKhachKN[id] != null ? mayKhachKN[id] : "Lỗi"); 
            lvTinNhan.Groups.Add(nhom);
            string mess = "";
            for (int i = 1; i < line.Length; i++)
            {
                mess += line[i];
            }
            lvTinNhan.Items.Add(mess);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }


        // tin nhắn gửi về
        private void HienThiTinNhanGuiVe(string s)
        {
           
            string[] line = s.Split('\n');
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = line[0];
            lvTinNhan.Groups.Add(nhom);
            string mess = "";
            for (int i = 1; i < line.Length; i++)
            {
                mess += line[i];
            }
            lvTinNhan.Items.Add(mess);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }


        

        // hiển thị tên ảnh qua group 
        void HienThiTenHinhAnh(string s)
        {
            foreach (Socket mk in mayKhach_ChapNhan)
            {
                if (mk != null)
                {
                    byte[] nhan = new byte[1024 * 5000];
                    nhan = MaHoa(s);
                    mk.Send(nhan);

                }
            }
            string[] line = s.Split('\n');
            string[] s1 = line[0].Split('!');
            nhanIDXoa(line[1]);
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = s1[0];
            lvTinNhan.Groups.Add(nhom);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }



        // hàm chuyển tên ảnh lại cho client
        void chuyenTiepTenAnh(string s)
        {
            string[] s1 = s.Split('!');
            string[] s2 = s.Split('(');
         
            byte[] gui = new byte[1024 * 5000];
            gui = MaHoa(s2[s2.Length - 1]+"!^^^^#");

            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = s2[s2.Length-1];
            lvTinNhan.Groups.Add(nhom);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
          
            foreach (string s3 in s1[0].Split(' '))
            {
                
                int i = mayKhachKN.IndexOf(s3);
                if (i >= 0)
                {
                    if (mayKhach_ChapNhan[i] != null) mayKhach_ChapNhan[i].Send(gui);
                }
            }
        }

        

        // hàm chuyển tiếp tin nhắn
        void chuyenTiep(string s)
        {
          
            string[]  s1 = s.Split('!');
            string[] s2 = s.Split('%');

            byte[] gui = new byte[1024 * 5000];
            gui = MaHoa(s2[s2.Length - 1]);
            HienThiTinNhanGuiVe(s2[s2.Length - 1]);
            foreach (string s3 in s1[0].Split(' '))
            {
                int i = mayKhachKN.IndexOf(s3);
                if(i >= 0)
                {
                    if (mayKhach_ChapNhan[i] != null) mayKhach_ChapNhan[i].Send(gui);
                }    
            }    
        }


        // xóa ảnh
        void xoaAnh(string s)
        {

            string[] s1 = s.Split('!');
            byte[] gui = new byte[1024 * 5000];
            gui = MaHoa(s1[s1.Length - 1]);
            string[] s4 = s1[0].Split(' ');
          
            foreach (string s3 in s4)
            {
                MessageBox.Show(s3);
                int i = mayKhachKN.IndexOf(s3);
               
                if (i >= 0)
                {
                    
                    if (mayKhach_ChapNhan[i] != null) mayKhach_ChapNhan[i].Send(gui);
                    
                }
            }

        }

        // hàm nhận giữ liệu client gửi 
        private void Nhan_MayKhach(object obj)
        {
            Socket mayKhach = obj as Socket;
            
            try
            {
                while (true)
                {
                    byte[] nhan = new byte[1024*5000];
                    mayKhach.Receive(nhan);
                    object objA = GiaiMa(nhan);
                  
                    if (objA.GetType().ToString() == "System.String")
                    {
                        string s = GiaiMa(nhan).ToString();


                        // tin chuyển tiếp 
                        if (s.Contains("!()()()%"))
                        {
                            chuyenTiep(s);
                            continue;
                        }

                        if (s.Contains("!$$$$("))
                        {
                            
                            chuyenTiepTenAnh(s);
                            continue;
                        }

                        // xoá anh
                        if (s.Contains("!----()))"))
                        {
                            
                            xoaAnh(s);
                            continue;
                        }

                        // nhận id xóa client
                        if (s.Contains("!----("))
                        {
                            nhanIDXoa(s);
                            continue;
                        }
                       
                        if (s.ToString().Contains("!@@@@#"))
                        {
                            
                            XoaTN(s);
                            continue;
                        }
                        // nhận id Xóa
                        
                       
                        //Hiển thị tin nhắn riêng
                        if (s.Contains("!----#"))
                        {
                          
                            TinRiengMayKhach(s);
                            continue;
                        }
                        // Hiển thị tên ảnh
                        if (s.Contains("!^^^^#"))
                        {
                            HienThiTenHinhAnh(s);
                            continue;
                        }
                        
                        HienThiTinNhanGuiVe((String)GiaiMa(nhan));
                    }
                    else if (objA.GetType().ToString() == "System.Drawing.Bitmap")
                    {
                        id++;
                        Image image = (Image)GiaiMa(nhan);
                        imgAnh.Images.Add(id + "", image);
                        ListViewItem item = new ListViewItem();
                        item.ImageKey = id + "";
                        lvTinNhan.Items.Add(item);
                    }

                    
                    foreach (Socket mk in mayKhach_ChapNhan)
                    {
                        if (mk != null && mayKhach != mk)
                        {
                            
                            mk.Send(nhan);
                            
                        }

                    }
                }
            }
            catch
            {
                // xóa máy khách
                // ẩn radio máy khách
                int so = mayKhach_ChapNhan.IndexOf(mayKhach);
                try
                { 

                radNhom_Chat[so].Checked = false;
                radNhom_Chat[so].Visible = false;
                }
                catch
                {

                }
                radNhom_Chat[so] = null;
            

                mayKhachKN[so] = "";
                
                radTeam.Checked = true;
               
                mayKhach_ChapNhan[so] = null;
                try
                {
                    foreach (Socket mk in mayKhach_ChapNhan)
                    {

                        if (mk != null)
                        {
                            byte[] tnOut = new byte[1024 * 5000];
                            tnOut = MaHoa("!$$$$#" + so);
                            mk.Send(tnOut);
                        }

                    }
                }
                catch
                {
                    mayKhach.Close();
                }
              
            }
        }
        
        // mã hóa 
        byte[] MaHoa(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms,obj);
            return ms.ToArray(); 
        }
        

        // giải mã
        public object GiaiMa(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }
        private void rtxKetNoi_TextChanged(object sender, EventArgs e)
        {
            
        }


        // đóng form
        private void frmServer_Hieu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (mayKhach_ChapNhan == null) return;
                byte[] gui = new byte[1024];
                gui = MaHoa(" Server đã Đóng kết nối vào ngày " + DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss"));

                foreach (Socket mk in mayKhach_ChapNhan)
                {
                    if (mk != null) mk.Send(gui);

                }
                foreach (Socket mk in mayKhach_ChapNhan)
                {
                    if (mk != null) mk.Close();
                }
            }
            catch
            {

            }
        }

        void guiRieng()
        {

        }


        // nút gửi 
        private void btnGui_Click(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
            

            if (this.txtGui.Text.Length <= 0) return;
            byte[] gui = new byte[1024 * 5000];
       


            // kiểm tra gửi tất cả hay server
            if (radTeam.Checked)
            {
                if (mayKhach_ChapNhan == null) return;
                foreach (Socket mk in mayKhach_ChapNhan)
                {

                    if (mk != null)
                    {
                        gui = MaHoa("Server Gửi vào ngày " + s + "\n" + txtGui.Text);
                        mk.Send(gui);
                    }
                }
            }
            else
            {
                for (int i = 0; i < radNhom_Chat.Length; i++)
                {
                    if (radNhom_Chat[i] != null)
                    {
                        if (radNhom_Chat[i].Checked)
                        {
                            if(mayKhach_ChapNhan[i] != null)
                            {

                                gui = MaHoa("Server Gửi vào ngày " + s + "\n" + txtGui.Text);
                                mayKhach_ChapNhan[i].Send(gui);
                            }     
                            break;              
                        }
                    }

                }
            }
            HienThiTinNhan(s,txtGui.Text);

            txtGui.Clear();
        }


        // hiển thị tin nhắn
        private void HienThiTinNhan(string s,string tinNhan)
        {
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = "Server gửi vào ngày " + s;
            lvTinNhan.Groups.Add(nhom);
            lvTinNhan.Items.Add(tinNhan);
            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
        }



        // GuiLanDau dùng cho việc gửi lại client danh sách client
        private void GuiLanDau(String s)
        {
            string s0 = "Server gửi vào ngày "+DateTime.Now.ToString("dd-MM-yyyy lúc HH:mm:ss"+ "\n");
          
            string[] s1 = s.Split(' ');
            mayKhachKN.Add(s1[0]);
          
            string guiDi = "";
            foreach(string m in mayKhachKN)
            {
                guiDi += m + " ";
            }
            
            foreach (Socket mk in mayKhach_ChapNhan)
            {
                if (mk != null)
                {
                    byte[] gui = new byte[1024 * 5000];
                    gui = MaHoa(s0 +guiDi+ "!####@");
                    mk.Send(gui);
                }
            }
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


        // kết nối server
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                MessageBox.Show("Vui lòng tắt bật lại");
                return;
            }
            try
            {
                mayChu = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                diaChiIP = IPAddress.Any;
                diaChiEP = new IPEndPoint(diaChiIP, 12345);

                mayChu.Bind(diaChiEP);
                Thread s = new Thread(batDau);
                s.IsBackground = true;
                s.Start();
                MessageBox.Show("Server Kết Nối Thành Công");
                check = false;
            }
            catch
            {

            }
            
        }




        private void lbNhomChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // xử lý nút gửi ảnh

        private void tsbtnHinhAnh_Click(object sender, EventArgs e)
        {
            if (mayKhach_ChapNhan== null) return;
            OpenFileDialog Mo_Anh = new OpenFileDialog();
            Mo_Anh.Title = "Chọn Ảnh";
            Mo_Anh.Filter = "Hinh Anh|*.bmp;*.jpg;*.gif;*.png;*.tif";
            try
            {
                if (Mo_Anh.ShowDialog() == DialogResult.OK)
                {

                    string fileName = Mo_Anh.FileName;

                    if (fileName == "") return;
                        byte[] nhan = new byte[1024 * 5000];
                        
                       
                        //Add ảnh vào Server
                        id++;
                        Image image = (Image)Image.FromFile(fileName);
                        imgAnh.Images.Add(id + "", image);
                        ListViewItem item = new ListViewItem();
                        item.ImageKey = id + "";
                        lvTinNhan.Items.Add(item);
                        string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
                        string guiTen = "Server Gửi vào ngày " + s;
                        ListViewGroup nhom = new ListViewGroup();
                        nhom.Header = guiTen;
                        lvTinNhan.Groups.Add(nhom);

                        lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];
                        

                        // kiểm tra gửi cho server hay cho client 
                        if (radTeam.Checked)
                        {
                            nhan = MaHoa(Image.FromFile(fileName));

                           
                            foreach (Socket mk in mayKhach_ChapNhan)
                            {
                                if (mk != null)
                                {

                                    mk.Send(nhan);
                                }
                            }
                            nhan = MaHoa(guiTen + "!^^^^#");
                            foreach (Socket mk in mayKhach_ChapNhan)
                            {
                                if (mk != null)
                                {

                                    mk.Send(nhan);

                                }
                            }
                        }
                        else
                        {
                            nhan = MaHoa(Image.FromFile(fileName));


                            for (int i = 0; i < radNhom_Chat.Length; i++)
                                {
                                    if (radNhom_Chat[i] != null)
                                    {
                                        if (radNhom_Chat[i].Checked)
                                        {
                                            if (mayKhach_ChapNhan[i] != null)
                                            {
                                            mayKhach_ChapNhan[i].Send(nhan);


                                            nhan = MaHoa(guiTen + "!^^^^#");
                                            mayKhach_ChapNhan[i].Send(nhan);
                                            }
                                            break;
                                        }
                                    }

                                }
                            
                        }
                    lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
                
                    
                }
            }
            catch
            {
               MessageBox.Show("Định Dạng Ảnh Không hợp lệ", "Lỗi Định Dạng");
            }
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

        private int id1 = 0;

        // gửi emoji
        private void lvEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mayKhach == null) return;

            if (lvEmoji.SelectedIndices.Count <= 0) return;
            if (lvEmoji.FocusedItem == null) return;
            id1 = lvEmoji.SelectedIndices[0];
            if (id1 < 0) return;
            byte[] nhan = new byte[1024 * 5000];

            id++;
            Image image = (Image)imgEmoji.Images[id1];
            imgAnh.Images.Add(id + "", image);
            ListViewItem item = new ListViewItem();
            item.ImageKey = id + "";
            lvTinNhan.Items.Add(item);
            

           
            string s = DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss");
            string guiTen = "Server Gửi vào ngày " + s;
            ListViewGroup nhom = new ListViewGroup();
            nhom.Header = guiTen;
            lvTinNhan.Groups.Add(nhom);

            lvTinNhan.Items[lvTinNhan.Items.Count - 1].Group = lvTinNhan.Groups[lvTinNhan.Groups.Count - 1];

            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);
            if (radTeam.Checked)
            {
                nhan = MaHoa((Image)imgEmoji.Images[id1]);


                foreach (Socket mk in mayKhach_ChapNhan)
                {
                    if (mk != null)
                    {

                        mk.Send(nhan);
                    }
                }
                nhan = MaHoa(guiTen + "!^^^^#");
                foreach (Socket mk in mayKhach_ChapNhan)
                {
                    if (mk != null)
                    {

                        mk.Send(nhan);

                    }
                }
            }
            else
            {
                nhan = MaHoa((Image)imgEmoji.Images[id1]);


                for (int i = 0; i < radNhom_Chat.Length; i++)
                {
                    if (radNhom_Chat[i] != null)
                    {
                        if (radNhom_Chat[i].Checked)
                        {
                            if (mayKhach_ChapNhan[i] != null)
                            {
                                mayKhach_ChapNhan[i].Send(nhan);


                                nhan = MaHoa(guiTen + "!^^^^#");
                                mayKhach_ChapNhan[i].Send(nhan);
                            }
                            break;
                        }
                    }

                }

            }
            lvTinNhan.EnsureVisible(lvTinNhan.Items.Count - 1);

        }
        private int chonItem = -1;
        private void lvTinNhan_Click(object sender, EventArgs e)
        {
            
           
            
        }
        

        // hàm gửi
        void Gui(String s)
        {
            byte[] gui = new byte[+1024 * 5000];
            try
            {
                int count = 0;
                foreach (Socket mk in mayKhach_ChapNhan)
                {
                    if (mk != null)
                    {
                        string[] so = viTriTinNhanDau[count].Split(':');
                        int ss = int.Parse(s) - int.Parse(so[so.Length - 1]);
                        gui = MaHoa("!@@@@#" + ss.ToString());
                        mk.Send(gui);
                    }
                    count += 1;
                }
            }
            catch
            {

            }
            
        }
        private void lvTinNhan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // gửi tệp
        private void tsbtnGuiTep_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tính Năng Gửi được nhưng có thể gây đứng Server bạn có muốn thử!", "THÔNG BÁO", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            if (mayKhach_ChapNhan == null) return;
            this.Invoke((MethodInvoker)delegate
            {
                OpenFileDialog Mo_Anh = new OpenFileDialog();
                Mo_Anh.Title = "Chọn Ảnh";
                Mo_Anh.Filter = "Tep Gui Dinh Dang |*.docx;*.rar;*.;*.txt;*.xls";
                try
                {
                    if (Mo_Anh.ShowDialog() == DialogResult.OK)
                    {

                        string path = Mo_Anh.FileName;
                        FileInfo file = new FileInfo(path);
                        string filename = path.Substring(path.LastIndexOf("\\") + 1); // tách tên file khỏi đường dẫn

                        byte[] data = new byte[200];
                        byte[] fsize = new byte[file.Length]; // tạo mảng chứa dữ liệu
                        FileStream fs = new FileStream(path, FileMode.Open); // đọc thông tin file đã nhập
                        fs.Read(fsize, 0, fsize.Length);
                        fs.Close();
                        byte[] gui = new byte[1024];

                        if (radTeam.Checked)
                        {
                            string s = "@!@!@!@~" + filename + "," + file.Length.ToString();
                            gui = MaHoa(s);
                            mayKhach.Send(gui);

                            while (true)
                            {
                                long n = file.Length / data.Length;  //tính số frame phải gửi
                                for (long i = 0; i < n; i++)
                                {

                                    mayKhach.Send(fsize, fsize.Length, 0);

                                }
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chỉ hổ trợ gửi File cho 1 người");
                        }

                    }

                }
                catch
                {


                }
            });
        }


           
       
        // nút hủy tin gửi
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (mayChu == null)
            {
                MessageBox.Show("Server chưa chạy Không thể dừng!");
            }
            else {
                DialogResult res = MessageBox.Show("Bạn muốn dừng Server!", "ThÔNG BÁO", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    byte[] gui = new byte[1024];
                    gui = MaHoa(" Server đã Đóng kết nối " + DateTime.Now.ToString("dd-MM-yyyy Lúc HH:mm:ss"));
                    mayKhach.Send(gui);
                    foreach (Socket mk in mayKhach_ChapNhan)
                    {
                        if (mk != null) mk.Send(gui);

                    }
                    foreach (Socket mk in mayKhach_ChapNhan)
                    {
                        if (mk != null) mk.Close();
                    }
                    mayChu.Close();
                    MessageBox.Show("Dừng Server Thành Công");
                }
                
            }
       
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmServer_Hieu_Load(object sender, EventArgs e)
        {

        }

        private void cHAOBANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nChat \nGửi \nXóa\nChuyểnTiếp\nGửi Tệp\nGửiEmoji và Ảnh");
        }



        // Nút chuyển tiếp
        private void tsmnChuyenTin_Click(object sender, EventArgs e)
        {
            string diaChiAnh = "";
            object Mes;
            //từ 1 cái object Mes để lấy tin nhắn 
            // 1 cái là lấy ngày giờ gửi 
            // 1 cái là lấy kiểu tin gửi
            try
            {
                // items == "" tức là gửi hình
                if (lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].Text != "")
                {
                    
                    Mes = (string)("Server chuyển tiếp tin " + lvTinNhan.Groups[lvTinNhan.SelectedIndices[0]].Header.ToString() + " \n" + lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].Text);
                }
                else
                {
                    diaChiAnh = (string)("Server chuyển tiếp tin " + lvTinNhan.Groups[lvTinNhan.SelectedIndices[0]].Header.ToString());
                    Mes = (Image)imgAnh.Images[lvTinNhan.Items[lvTinNhan.SelectedIndices[0]].ImageKey];

                }
                frmChuyenTiep s = new frmChuyenTiep(mayKhachKN, mayKhach_ChapNhan, Mes, diaChiAnh);
                s.Show(this);
                
            }
            catch
            {

            }

            
        }

        private void tsmnChuyenTiep_Click(object sender, EventArgs e)
        {
            tsmnChuyenTin.PerformClick();
        }

        private void xoaTinNhans_Click(object sender, EventArgs e)
        {
            try
            {
                chonItem = lvTinNhan.SelectedIndices[0]; // lấy thứ tự item
                if (chonItem < 0) return;

                if (lvTinNhan.Items[chonItem].ImageKey.Length > 0) lvTinNhan.Items[chonItem].ImageIndex = 0;
                lvTinNhan.Items[chonItem].Text = "Đã Xóa";
              
            }
            catch
            {

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmnXoaTin_Click(object sender, EventArgs e)
        {
            xoaTinNhans.PerformClick();
        }
    }
}
