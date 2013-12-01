using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CustomItem.Module.Form;
using DevExpress.XtraSplashScreen;
namespace CustomItem.Module
{
    public partial class UCBase : XtraUserControl
    {
        
        protected virtual void ONCREATE() { }
        
        public UCBase()
        {
            InitializeComponent();
            
        }

        protected void UCOnLoad(Action loading){
            UCStart();
            loading();
            UCEnd();
        }

        protected virtual void UCStart(Point Position){
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), false, false, SplashFormStartPosition.Default, Position);
        }

        protected virtual void UCStart()
        {
            UCStart(new Point(this.Width / 2 , this.Height / 2));
        }

        protected virtual void UCEnd()
        {
            SplashScreenManager.CloseForm(false);
        }

        //protected virtual void AddControl<T>(Control control) where T: Control , new()
        //{
        //    T c = new T();
        //    c.Dock = DockStyle.Fill;
        //    control.Controls.Add(c);
        //}

        protected virtual T AddControl<T>(Control control,bool Return) where T : Control, new()
        {
            MemoryManagement.FlushMemory();
            control.Controls.Clear();
            T c = new T();
            c.Dock = DockStyle.Fill;
            control.Controls.Add(c);
            return c;
        }

        protected virtual void AddControl<T>(Control control) where T : Control, new()
        {
            MemoryManagement.FlushMemory();
            control.Controls.Clear();
            T c = new T();
            c.Dock = DockStyle.Fill;
            control.Controls.Add(c);
        }
    }
}
