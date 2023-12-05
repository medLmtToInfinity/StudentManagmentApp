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

namespace StudentManagmentApp
{
    public partial class Login : Form
    {
        public LinkToSqlDataContext dbContext;
        public Login()
        {
            InitializeComponent();
            dbContext = new LinkToSqlDataContext(new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            var user = from u in dbContext.Users
                       where u.login == login & u.password == password
                       select u;

            if (user.Count() != 0)
            {
                var connectedUser = user.ToList().ElementAt(0);
                if (connectedUser.admin == true)
                {
                    Form1 AdminForm = new Form1();
                    AdminForm.Show();
                }
                else
                {
                    Enseignant EnseignatForm = new Enseignant();
                    EnseignatForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Incorrect informations");

            }
        }

    }
}