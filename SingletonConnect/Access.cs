using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.OleDb;

using System.Windows.Forms;
namespace SingletonConnect
{
    class Access:Connect
    {

        public Access(string Url, string database):base(database)
        {
            // TODO: Complete member initialization

            url = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + (from s in XElement.Load(@"../../Url.xml").Descendants("dir") where s.Attribute("type").Value.Equals("Access") select s.Value).First().ToString();
            
            CMConnection = new OleDbConnection(url);
            CCommand = new OleDbCommand();
            CDataAdapter = new OleDbDataAdapter();
        }

    }
}
