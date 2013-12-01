
namespace ClassRoomDAL
{
    using System;
    using System.Threading.Tasks;
    using Model;
    using Model.Models;
    public class DataConnect
    {
        static DataConnect Common = DataConnect.getinstanceofCommonConnect();
        static classroommanagementContext context ;

        public static classroommanagementContext Context
        {
            get { return DataConnect.context; }
        }

       
        private DataConnect() {
            context = new classroommanagementContext("SQL");

        }

        public static DataConnect getinstanceofCommonConnect(){
            if(Common==null){
                Common = new DataConnect();
            }
            return Common;
        }
    }
}
