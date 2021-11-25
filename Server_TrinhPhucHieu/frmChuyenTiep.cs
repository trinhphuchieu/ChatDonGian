using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_TrinhPhucHieu
{
    public partial class frmChuyenTiep : Form
    {

        private List<Socket> mayKhach;
        private List<String> ds;
        private object obj;
        private string diachi = "";
        public frmChuyenTiep(List<string> DanhSachUser,List<Socket> dsMK,object obj, string diachi)
        {
            InitializeComponent();
            this.obj = obj;
            this.diachi = diachi;
            this.ds = DanhSachUser;
            this.mayKhach = dsMK;
            string[] s = new string[DanhSachUser.Count];
            for(int i = 0; i < DanhSachUser.Count; i ++)
            {     
                s[i] = DanhSachUser[i];
            }    
            lbChuyen.Items.AddRange(s);
        }
        byte[] MaHoa(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            foreach (string s  in lbChuyen.SelectedItems)
            {
                int i = ds.IndexOf(s);
                if(i >= 0)
                {
                   
                    mayKhach[i].Send(MaHoa(obj));
                    if (diachi != "")
                    {
                        diachi = diachi + "!^^^^#";
                       mayKhach[i].Send(MaHoa(diachi));
                    }
                     
                }    
                
            }
            this.Close();
        }
     
        private void lbChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmChuyenTiep_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
