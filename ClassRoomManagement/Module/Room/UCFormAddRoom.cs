using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassRoomBUS;

namespace CustomItem.Module
{
    public partial class UCFormAddRoom : UCBase
    {
        PhonghocBUS BUS;

        public UCFormAddRoom()
        {
            InitializeComponent();
            BUS = new PhonghocBUS();
            if (Global.ActiveID)
            {
                Model.Models.phonghoc o = BUS.getdata().Find(x => x.maphong.Equals((string)Global.ID));
                txtmaphong.Text = o.maphong;
                txttenphong.Text = o.tenphong;
                spdientich.Value = Convert.ToDecimal(o.dien_tich);
                spsiso.Value = Convert.ToDecimal(o.siso);
                pictureanh.Image = Images.DecodeImage(o.images);
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images Files|*.png;*.jpg;*.jpeg;*.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textEdit3.Text = open.FileName;
                pictureanh.Image = Images.LoadFromFile(open.FileName);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            
            Model.Models.phonghoc obj = new Model.Models.phonghoc
            {
                maphong = txtmaphong.Text.Equals("") ? null : txtmaphong.Text,
                tenphong = txttenphong.Text,
                siso = Convert.ToInt32(spsiso.Value) <= 0 ? -1 : Convert.ToInt32(spsiso.Value) ,
                dien_tich = Convert.ToDouble(spdientich.Value) <= 0 ? -1 : Convert.ToDouble(spdientich.Value),
                images = textEdit3.Text.Equals("") ? Images.EncodeImage(pictureanh.Image) : Images.EncodeImage(textEdit3.Text),
            };
            if (Global.ActiveID)
                BUS.Update(BUS.getdata().Find(x => x.maphong.Equals((string)Global.ID)), obj);
            else
                BUS.Insert(obj);
            DevExpress.XtraEditors.XtraMessageBox.Show(ClassRoomDAL.Log.message);
            
        }

       
       

        

        
        
        
    }
}
