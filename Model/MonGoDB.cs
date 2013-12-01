using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
namespace Model
{
    public class MonGoDB : NOSQL
    {
        public MongoDB.Driver.MongoCollection db { get; set; }
        public string database { get; set; }

        public MongoDB.Driver.MongoClient client{get;set;}

        public string host { get; set; }

        public int port { get; set; }


        public MonGoDB()
        {
            this.client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
        }

        private void SelectDB(string database)
        {
            this.db = this.client.GetServer().GetDatabase(database).GetCollection(database);
        }
        public override IEnumerable<T> getdata<T>()
        {
            SelectDB((new T()).getclassname());
            IEnumerable<T> data = from s in this.db.AsQueryable<T>() select s;
            return data;
          
        }
        public override int Insert<T>(T obj)
        {
            
            this.db.Insert<T>(obj);
            return 1;
        }

        public override int Delete<T>(T obj)
        {

            this.db.Remove(Query.EQ(this.OnKey(obj),this.OnValue(obj).ToString()));
            return 1;
        }


        public override int Update<T>(T oldobj, T newobj)
        {
            var query = new QueryDocument(this.OnKey(oldobj), this.OnValue(oldobj).ToString());
            this.db.Update(query, MongoDB.Driver.Builders.Update.Replace(newobj));
            return 1;
        }
        



        //public override void Insert(object obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
