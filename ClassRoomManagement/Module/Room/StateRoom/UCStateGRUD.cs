using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using ClassRoomBUS;
using CustomItem;
using ClassRoomManagement.Module;
namespace CustomItem.Module
{
    public partial class UCStateGRUD : UCBase
    {
        TrangthaiphongBUS TTBUS;
        Model.Models.trangthaiphong newstate,oldstate;
        string ca = "";
        //AppointmentFormOutlook2007Style f = new AppointmentFormOutlook2007Style();
        public UCStateGRUD()
        {
            InitializeComponent();
            TTBUS = new TrangthaiphongBUS();
            
        }

        protected override void ONCREATE()
        {
            var l = TTBUS.getdata();
            AppointmentMappingInfo appointmentMappings = schedulerStorage1.Appointments.Mappings;
            
            schedulerStorage1.Appointments.DataSource = l;
            schedulerStorage1.Appointments.Labels[0].Color = Color.DarkMagenta;
            schedulerStorage1.Appointments.Statuses[0].Color = Color.DarkMagenta;
            appointmentMappings.AppointmentId = "maphong";
            appointmentMappings.Subject = "maphong";
            appointmentMappings.Start = "thoigianbatdau";
            appointmentMappings.End = "thoigianketthuc";
            
            if (schedulerStorage1.Appointments.Count > 0)
                schedulerControl1.Start = schedulerStorage1.Appointments[0].Start;
            //schedulerControl1.schedulerStorage1.AppointmentsInserted += Storage_AppointmentsInsert;
            //schedulerStorage1.AppointmentsChanged += Storage_AppointmentsUpdate;
            //schedulerStorage1.AppointmentsDeleted += Storage_AppointmentsDelete;
            schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsChanged);
            schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsInserted);
            schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(schedulerStorage_AppointmentsDeleted);
        }

        
        
        private void schedulerStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {


            foreach (Appointment app in e.Objects)
            {
                System.Diagnostics.Debug.WriteLine(app.End.ToString());
                newstate = new Model.Models.trangthaiphong { maphong = app.Subject , thoigianbatdau = app.Start , thoigianketthuc = app.End };
                TTBUS.Delete(newstate);
            }
            
        }

        private void schedulerStorage_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            foreach (Appointment app in e.Objects)
            {
                
                    newstate = new Model.Models.trangthaiphong { maphong = app.Subject, thoigianbatdau = app.Start, thoigianketthuc = app.End, maca = app.Location, hientrang = "Free" };
                    TTBUS.Insert(newstate);
                
                
            }
            
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            foreach (Appointment app in e.Objects)
            {

                newstate = new Model.Models.trangthaiphong { maphong = app.Subject, thoigianbatdau = app.Start, thoigianketthuc = app.End, maca = app.Location, hientrang = "Free" };
                TTBUS.Update(oldstate,newstate);
            }
        }

        

        private void schedulerControl1_AllowAppointmentEdit(object sender, AppointmentOperationEventArgs e)
        {

        }

        private void UCStateGRUD_Load(object sender, EventArgs e)
        {
            UCOnLoad(ONCREATE);
        }

        private void schedulerControl1_EditAppointmentFormShowing_1(object sender, AppointmentFormEventArgs e)
        {
            oldstate = new Model.Models.trangthaiphong { maphong = e.Appointment.Subject, thoigianbatdau = e.Appointment.Start, thoigianketthuc = e.Appointment.End };
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));

            AppointmentFormOutlook2007Style form = new AppointmentFormOutlook2007Style(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                //Global.main.GoTo<AppointmentFormOutlook2007Style>(form, null, null);
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {

                
                form.Dispose();
            }

        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
