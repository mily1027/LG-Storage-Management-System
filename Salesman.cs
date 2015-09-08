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
    public partial class Salesman : Form
    {
        public Boolean save = false;
        public Salesman()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = S_Name.Text;
            string id = S_ID.Text;
            string address = S_Adress.Text;
            string rank = S_Rank.Text;
            string age = S_Age.Text;
            string mobile = S_MobileNo.Text;
            string whour = S_Workhour.Text;

            if (name != "" && id != "" && address != "" && rank != "" && age != "" && mobile != "" && whour != "")
            {
                string query = "INSERT into Employee_tbl values('" + name + "','" + id + "','" + address + "','" + rank + "','" + age + "','" + mobile + "','" + whour + "')";
                if (MessageBox.Show("Would you like to save this Information?", "Save Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveDataIntoTable(query);

                    if (save)
                    {
                        S_Name.Text = "";
                        S_ID.Text = "";
                        S_Adress.Text = "";
                        S_Rank.Text = "";
                        S_Age.Text = "";
                        S_MobileNo.Text = "";
                        S_Workhour.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error Occoure");
                    }
                }
            }
            else
            {
                MessageBox.Show("Something missing");
            }
        }
        public void SaveDataIntoTable(string query)
        {
            try
            {
                SqlConnection connection = LG_connection.LgConnection();
                SqlCommand commend = new SqlCommand(query, connection);
                commend.ExecuteNonQuery();
                connection.Close();
                save = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                save = false;
            }
        }
    }
}
