using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    
    public class AccountDAL:IDAL<Account>
    {

        public List<Account> getdata()
        {
            var result = from s in DataConnect.Context.data.Accounts select s;
            return result.ToList();
        }

        public int Insert(Account obj)
        {
            int result;
            DataConnect.Context.data.Accounts.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(Account obj)
        {
            int result;
            DataConnect.Context.data.Accounts.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(Account oldobj, Account newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.Accounts where s.maid.Equals(oldobj.maid) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;

        }


        
    }
}
