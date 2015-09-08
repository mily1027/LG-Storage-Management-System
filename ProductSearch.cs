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
    public partial class ProductSearch : Form
    {
        public ProductSearch()
        {
            InitializeComponent();
            SqlConnection conn = LG_connection.LgConnection();
            String query = "select * from product_tbl";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int found = 0;

            if (textProductIdBox.Text == "")
            {
                MessageBox.Show("Please Input Product Id");
                textProductIdBox.Focus();
            }
            else
            {
                SqlConnection con1 = LG_connection.LgConnection();
                String query1 = "select p_id from product_tbl";
                SqlCommand cmd = new SqlCommand(query1, con1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["p_id"].ToString() == textProductIdBox.Text)
                    {
                        found = 1;
                        
                        break;
                    }

                }

                con1.Close();
                if (found == 1)
                {

                    SqlConnection conn = LG_connection.LgConnection();
                    String query = "select * from product_tbl WHERE p_id='" + textProductIdBox.Text + "' ";
                    SqlDataAdapter ad = new SqlDataAdapter(query, conn);
                    DataTable ds = new DataTable();
                    ad.Fill(ds);
                    dataGridView1.DataSource = ds;

                }
                else
                {
                    MessageBox.Show("Did not match product Id");
                    textProductIdBox.Focus();
                }
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProductSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lGDBDataSet1.product_tbl' table. You can move, or remove it, as needed.
           // this.product_tblTableAdapter.Fill(this.lGDBDataSet1.product_tbl);
            // TODO: This line of code loads data into the 'lGDBDataSet.product_tbl' table. You can move, or remove it, as needed.
            //this.product_tblTableAdapter.Fill(this.lGDBDataSet.product_tbl);

        }

    }
}
