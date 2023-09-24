using BTLLLTQ.FORMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLLTQ
{
    public partial class Login : Form
    {
        private Dashboard dashboard = null;
        public Login(Dashboard dashboard)
        {
            this.dashboard = dashboard as Dashboard;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            THE_DATABASE.MyDB db = new THE_DATABASE.MyDB();

            db.openConnection();
            string userName = textBox_userName.Text;
            string password = textBox_password.Text;

            DataTable table = new DataTable(); ;

            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE username=@usn AND password=@pass", db.getConnection());
            command.Connection = db.getConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            

            adapter.SelectCommand = command;
            command.Parameters.Add("@usn", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            adapter.Fill(table); // Thực hiện Fill

            if (table.Rows.Count > 0 )
            {
                dashboard.Show();
                this.Close();
            }
            else
            {
                if (userName.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username to Login","Empty Username",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            db.closeConnection();
        }
    }
}
