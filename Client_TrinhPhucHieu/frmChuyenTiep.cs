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

namespace Client_TrinhPhucHieu
{
    public partial class frmChuyenTiep : Form
    {

        private Socket mayKhach;
        private object obj;
        private string diaChiAnh="";
        public frmChuyenTiep(List<string> DanhSachUser, Socket mayKhach,object s1,string dcA)
        {
            InitializeComponent();


            this.obj = s1;
            this.mayKhach = mayKhach;
            diaChiAnh = dcA; 
            string[] s = new string[DanhSachUser.Count];
            for(int i = 0; i < DanhSachUser.Count; i ++)
            {     
                s[i] = DanhSachUser[i];
            }    
            lbChuyen.Items.AddRange(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string guicho = "";
            string guicho2 = "";
            Dictionary<string, string> hash = new Dictionary<string, string>();
            foreach (string s  in lbChuyen.SelectedItems)
            {
                guicho = guicho + s + " ";
                hash.Add(s, ""); 
            }
            
            guicho = guicho.Trim();
            
            byte[] gui = new byte[1024 * 5000];
         
           // if (guicho == "") return;
            if (diaChiAnh == "")
            {
                

                guicho = guicho + "!()()()%" + Convert.ToString(obj);
                gui = MaHoa(guicho);
                mayKhach.Send(gui);
            }
            else
            {
              
                foreach(string s in lbChuyen.Items)
                {
                    if(!hash.ContainsKey(s))
                    {
                        guicho2 = guicho2+ s + " ";
                    }    
                }
               


                gui = MaHoa(obj);
                mayKhach.Send(gui);

              



                guicho = guicho + "!$$$$(" + diaChiAnh;
                gui = MaHoa(guicho);
                mayKhach.Send(gui);



                gui = MaHoa(guicho2+"!----()))");
              
                mayKhach.Send(gui);

            }




            this.Close();
        }
        byte[] MaHoa(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
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
