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
using DevExpress.XtraNavBar;

namespace CustomItem.Module
{
    public partial class UCTimetable_Add : UCBase
    {

        IBUS<object> BUS;
        NganhBUS NGBUS;
        LopBUS LBUS;
        GiangvienBUS GBUS;
        CahocBUS CaBUS;
        public UCTimetable_Add()
        {
            InitializeComponent();
            CaBUS = new CahocBUS();
            NGBUS = new NganhBUS();
            LBUS = new LopBUS();
            GBUS = new GiangvienBUS();
            
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        


        private void navBarControl1_Resize(object sender, EventArgs e)
        {
            panelControl1.Size = new Size(navBarControl1.Width + 1, navBarControl1.Height + 1);
        }


        protected override void ONCREATE()
        {
            
            LBUS.getdata().ForEach(i =>
            {
                NavBarItem item = new NavBarItem(i.malop);
                item.LinkClicked += (o, e) => { lbmalop.Text = e.Link.Caption; };
                malop.ItemLinks.Add(item);
            });
            NGBUS.getdata().ForEach(i =>
            {
                NavBarItem item = new NavBarItem(i.manganh);
                item.LinkClicked += (o, e) => { lbmanganh.Text = e.Link.Caption; };
                manganh.ItemLinks.Add(item);
            });
            GBUS.getdata().ForEach(i =>
            {
                NavBarItem item = new NavBarItem(i.magv);
                item.LinkClicked += (o, e) => { lbmagv.Text = e.Link.Caption; };
                magiangvien.ItemLinks.Add(item);
            });
            CaBUS.getdata().ForEach(i =>
            {
                NavBarItem item = new NavBarItem(i.maca);
                item.LinkClicked += (o, e) => { lbmaca.Text = e.Link.Caption; };
                magiangvien.ItemLinks.Add(item);
            });
            (new HocphanBUS()).getdata().ForEach(i =>
            {
                NavBarItem item = new NavBarItem(i.mahp);
                item.LinkClicked += (o, e) => { lbmahp.Text = e.Link.Caption; };
                mahocphan.ItemLinks.Add(item);
            });

        }

        private void UCTimetable_Add_Load(object sender, EventArgs e)
        {
            UCOnLoad(ONCREATE);

            this.labelControl1.Text = Global.Information;
            if (Global.ActiveID)
            {
                Model.Models.thoikhoabieu obj = (new ThoikhoabieuBUS()).getdata().Find(x => x.ID == (int)Global.ID);
                lbmagv.Text = obj.magv;
                lbmalop.Text = obj.malop;
                lbmanganh.Text = obj.manganh;
                lbmalop.Text = obj.malop;
                lbmaca.Text = obj.maca;
            }
        }
        

        
    }
}
