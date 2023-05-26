using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shaddai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conexion
    
     {
            private string server = "localhost";
            private string database = "shadday";
            private string user = "root";
            private string password = "";
            private string cadenaConexion;

            public Conexion()
            {
                cadenaConexion = "Database= " + database + "; DataSource= " + server + "; User Id = " + user + "; Password = " + password;

            }
            public MySqlConnection GetConnection()
            {
                MySqlConnection connection = new MySqlConnection(cadenaConexion);
                return connection;
            }
    }
   
}