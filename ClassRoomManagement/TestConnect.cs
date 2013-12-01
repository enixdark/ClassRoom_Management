using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SingletonConnect;
namespace ClassRoomManagement
{
    public partial class TestConnect : Form
    {
        public TestConnect()
        {
            InitializeComponent();
        }

        private void br_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                txtbrowser.Text = s;
            }
        }

        private void TestConnect_Load(object sender, EventArgs e)
        {
            //DBConnect.DB = DBConnect.InstanceofDBConnect("MySQL", "test", "", "");
            //DBConnect.Conn.CMConnection.Open();
            //MessageBox.Show(DBConnect.Conn.CMConnection.State.ToString());
            
        }

        private void dbcbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(dbcbbox.SelectedItem.ToString().Trim().Equals("Access")){
                label4.Visible = true;
                txtbrowser.Visible = true;
                br.Visible = true;
                XElement root = XElement.Load(@"../../Url.xml");
                List<String> dirs = (from d in root.Elements("dir") select d.Value).ToList<String>();
                txtbrowser.Text = dirs[0].ToString();
                
            }
            else{
                label4.Visible = false;
                txtbrowser.Visible = false;
                br.Visible = false;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            XElement root = XElement.Load(@"../../Url.xml");
            var l = (from s in root.Descendants("dir") where s.Attribute("type").Value.Equals("Access") select s);
            //l.ToList().ForEach(x => Debug.WriteLine(x.Value));
            l.ElementAt(0).SetValue(txtbrowser.Text);
            root.Save(@"../../Url.xml");

            DBConnect.DB = DBConnect.InstanceofDBConnect("Access", "test", "", "");
            DBConnect.Conn.CMConnection.Open();
            MessageBox.Show(DBConnect.Conn.CMConnection.State.ToString());
            
        }

        
    }
}
