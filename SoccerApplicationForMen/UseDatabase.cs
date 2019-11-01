using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SoccerApplicationForMen
{
    public class UseDatabase
    {
        public string connString = @"Integrated Security=SSPI; 
                                    Initial Catalog=FootballDB; 
                                    Data Source=localhost";
        SqlConnection conn;

        public void ConnectToDB()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }

        public void DisconnectDB()
        {
            conn.Close();
        }

        public SqlDataReader ReadData(string query)
        {
            SqlCommand comm = new SqlCommand(query, conn);
            return comm.ExecuteReader();
        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception sql)
            {
                MessageBox.Show("An error occurred while performing operation...\n" + sql.Message);
                return false;
            }
        }
    }
}
