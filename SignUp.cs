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
    public partial class SignUp : Form
    {
        public Boolean confirm = false;
        public SignUp()
        {
            InitializeComponent();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn lg = new LogIn();
            this.Hide();
            lg.Show();
        }

        private void saveInfo_Click(object sender, EventArgs e)
        {
            String user_name = textUserName.Text;
            String pass = textPassword.Text;
            String cpass = textConPass.Text;

            if (user_name != "" && pass != "" && cpass != "" && pass == cpass)
            {
                String query = "INSERT INTO tbl_login VALUES('" + user_name + "','" + pass + "')";
                SaveInformation(query);
                if (confirm)
                {
                    MessageBox.Show("SignUp Complete Successfully.");
                    this.Hide();
                    LogIn log = new LogIn();
                    log.Show();
                }
                else
                {
                    MessageBox.Show("Something missing");
                }
            }
            else
            {
                MessageBox.Show("Please Input Password Carefully.");
            }
        }
        public void SaveInformation(string query)
        {
            try
            {
                SqlConnection Conn = LG_connection.LgConnection();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
                confirm = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
