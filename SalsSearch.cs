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
    public partial class SalsSearch : Form
    {
        public SalsSearch()
        {
            InitializeComponent();
            SqlConnection conn = LG_connection.LgConnection();
            String query = "select * from Employee_tbl";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void SearchSalesmnButton_Click(object sender, EventArgs e)
        {
            int found = 0;

            if (textSalesmnIdBox.Text == "")
            {
                MessageBox.Show("Please Input Salesman Id");
                textSalesmnIdBox.Focus();
            }
            else
            {
                SqlConnection con1 = LG_connection.LgConnection();
                String query1 = "select s_id from Employee_tbl";
                SqlCommand cmd = new SqlCommand(query1, con1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["s_id"].ToString() == textSalesmnIdBox.Text)
                    {
                        found = 1;

                        break;
                    }

                }

                con1.Close();
                if (found == 1)
                {

                    SqlConnection conn = LG_connection.LgConnection();
                    String query = "select * from Employee_tbl WHERE s_id='" + textSalesmnIdBox.Text + "' ";
                    SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                    DataTable ds = new DataTable();
                    ad.Fill(ds);
                    dataGridView1.DataSource = ds;

                }
                else
                {
                    MessageBox.Show("Did not match product Id");
                    textSalesmnIdBox.Focus();
                }
            }
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {

            int a = 0;
            if (textSalesmnIdBox.Text == "")
            {
                MessageBox.Show("Please Input Product Id");
                textSalesmnIdBox.Focus();
            }
            else
            {
                SqlConnection con1 = LG_connection.LgConnection();
                String query1 = "select * from Employee_tbl";
                SqlCommand cmd = new SqlCommand(query1, con1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["s_id"].ToString() == textSalesmnIdBox.Text)
                    {
                        string name = reader["s_name"].ToString().Trim();
                        int id = Convert.ToInt32(reader["s_id"].ToString());
                        string address = reader["s_address"].ToString();
                        string rank = reader["s_rank"].ToString();
                        string age = reader["s_age"].ToString();
                        string mobile = reader["s_mobile"].ToString();
                        string whoure = reader["s_whour"].ToString();
                        SalsUpdate up = new SalsUpdate();
                        up.s_name.Text = "" + name;
                        up.s_id.Text = "" + id;
                        up.s_address.Text = "" + address;
                        up.s_rank.Text = "" + rank;
                        up.s_age.Text = "" + age;
                        up.s_mobile.Text = "" + mobile;
                        up.s_whour.Text = "" + whoure;
                        this.Hide();
                        up.Show();
                        a++;

                    }

                }
                con1.Close();
                if (a == 0)
                {
                    MessageBox.Show("Info Not Found");
                    textSalesmnIdBox.Focus();

                }
            }
        }
    }
}
