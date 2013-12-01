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
    public partial class UCAdmin : UCBase
    {
        public UCAdmin()
        {
            InitializeComponent();
            this.Load += UCAdmin_Load;
        }

        void UCAdmin_Load(object sender, EventArgs e)
        {

            UCOnLoad(ONCREATE);
        }

        protected override void ONCREATE()
        {

            var l = (new AccountBUS()).getdata();
            UcAdmintable2.DataSource = l;
            var l2 = (new NhomBUS()).getdata();
            Ucadmintable1.DataSource = l2;
            
            gridView2.RowClick += (o, e) =>
            {
                string keys = gridView2.GetRowCellValue(e.RowHandle,"manhom").ToString();
                var d = l.Where(x => x.manhom.Equals(keys)).ToList();
                UcAdmintable2.DataSource = d;
                UcAdmintable2.RefreshDataSource();
            };

            gridView1.RowClick += (o, e) =>
            {
                Ucadmintxtusername.Text = gridView1.GetRowCellValue(e.RowHandle, "maid").ToString();
                Ucadmintxtpassword.Text = gridView1.GetRowCellValue(e.RowHandle, "pass").ToString();
                Ucadmincomboboxgroup.SelectedItem = gridView1.GetRowCellValue(e.RowHandle, "manhom").ToString();
            };
            add.Click += add_Click;
            update.Click += update_Click;
            delete.Click += delete_Click;
            save.Click += save_Click;
            refresh.Click +=refresh_Click;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void save_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void delete_Click(object sender, EventArgs e)
        {
            
            (new AccountBUS()).Delete( new Model.Models.Account {
                
            });
        }

        void update_Click(object sender, EventArgs e)
        {
            Global.ActiveID = true;
        }

        void add_Click(object sender, EventArgs e)
        {
            Global.ActiveID = false;
        }

    }
}
