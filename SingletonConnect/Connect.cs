using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.ProviderBase;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Entity;
namespace SingletonConnect
{
    public class Connect
    {
       protected String url;

       public String Url
       {

            get { return url; }
            
       }


       protected String dbName;
       
       public String DbName
       {
            get { return dbName; }
            set { dbName = value; }
       }
       protected DbConnection cmConnection;

       public DbConnection CMConnection
        {
            get { return cmConnection; }
            set { cmConnection = value; }
        }
       protected DbCommand cCommand;

       public DbCommand CCommand
        {
            get { return cCommand; }
            set { cCommand = value; }
        }
       protected DbDataAdapter cDataAdapter;

       public DbDataAdapter CDataAdapter
        {
            get { return cDataAdapter; }
            set { cDataAdapter = value; }
        }
       protected DbDataReader cDataReader;

       public DbDataReader CDataReader
        {
            get { return cDataReader; }
            set { cDataReader = value; }
        }


       public Connect()
       {
           
       }
        public Connect(String DbName)
        {
            this.DbName = DbName;
        }

        public Connect(String url,String DbName)
        {
            this.url = url;
            this.DbName = DbName;
        }
        
        public void Open()
        {
            if (CMConnection.State == ConnectionState.Closed)
                CMConnection.Open();
        }

        public void Close()
        {
            if (CMConnection.State == ConnectionState.Open)
                CMConnection.Close();
        }

        public DataTable QueryTable(String sql)
        {
            DataTable table = new DataTable();
            Open();
            try
            {
                CCommand.CommandText = sql;
                CCommand.Connection = CMConnection;
                CDataAdapter.SelectCommand = CCommand;
                CDataAdapter.Fill(table);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
            return table;
        }

    }
        
}
