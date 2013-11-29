using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.ProviderBase;
using System.Data.Common;
using System.Windows.Forms;

namespace SingletonConnect
{
    class Connect
    {
        private String dbName;

        protected String DbName
        {
            get { return dbName; }
            set { dbName = value; }
        }
        private DbConnection cmConnection;

        protected DbConnection CMConnection
        {
            get { return cmConnection; }
            set { cmConnection = value; }
        }
        private DbCommand cCommand;

        protected DbCommand CCommand
        {
            get { return cCommand; }
            set { cCommand = value; }
        }
        private DbDataAdapter cDataAdapter;

        protected DbDataAdapter CDataAdapter
        {
            get { return cDataAdapter; }
            set { cDataAdapter = value; }
        }
        private DbDataReader cDataReader;

        protected DbDataReader CDataReader
        {
            get { return cDataReader; }
            set { cDataReader = value; }
        }

        public Connect() { }

        public Connect(String DbName)
        {
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

        public DataTable Query(String sql)
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
