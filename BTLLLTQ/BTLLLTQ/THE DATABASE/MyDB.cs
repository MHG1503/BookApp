using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTLLLTQ.THE_DATABASE
{
    internal class MyDB
    {
        private String str = @"Data Source=LAPTOP-FN29B6OC\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";
        private SqlConnection con = null;

        public void openConnection()
        {
            try
            {
                con = new SqlConnection(str);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
             }

            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
         
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
