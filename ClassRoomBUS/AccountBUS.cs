using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class AccountBUS:IBUS<Account>
    {
        AccountDAL DAL;
        public AccountBUS()
        {
            DAL = new AccountDAL();
        }

        public List<Account> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(Account obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(Account obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(Account oldobj, Account newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
