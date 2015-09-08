# LG-Storage-Management-System
LG Showroom Employee Database Management System using Visual Studio 2010

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LG_StorageFinal
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = userNameBox.Text;
            string pword = passwordBox.Text;
            string query = "SELECT * from tbl_login where userName = '" + username + "'and psw ='" + pword + "'";
            Boolean check = search(query);
            if (check)
            {
                LG_Storage lg = new LG_Storage();
                this.Hide();
                lg.Show();
            }
            else if (username == "" || pword == "")
            {
                MessageBox.Show("User Name or password is invalid.");

            }
            else if (!check)
            {
                MessageBox.Show("Please input correct User Name / Password.");
            }
        }
        Boolean search(string a)
        {
            int sh = 0;
            SqlConnection conn = LG_connection.LgConnection();
            SqlCommand cmd = new SqlCommand(a, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            sh = dt.Rows.Count;
            if (sh != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sup = new SignUp();
            this.Hide();
            sup.Show();
        }
    }
}
