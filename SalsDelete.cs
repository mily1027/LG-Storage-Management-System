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
    public partial class SalsDelete : Form
    {
        public SalsDelete()
        {
            InitializeComponent();
            SqlConnection conn = LG_connection.LgConnection();
            String query = "select * from Employee_tbl";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int found = 0;
            if (DeleteSlmnIdBox.Text == "")
            {
                MessageBox.Show("Please Input Salesman Id");
                DeleteSlmnIdBox.Focus();
            }
            else
            {
                SqlConnection con1 = LG_connection.LgConnection();
                String query1 = "select s_id from Employee_tbl";
                SqlCommand cmd = new SqlCommand(query1, con1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["s_id"].ToString() == DeleteSlmnIdBox.Text)
                    {
                        found = 1;
                        break;
                    }

                }

                con1.Close();
                if (found == 1)
                {

                    SqlConnection con = LG_connection.LgConnection();
                    String query = "delete from Employee_tbl where s_id = '" + DeleteSlmnIdBox.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    if (MessageBox.Show("Would you like to Delete this Information??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd1.ExecuteNonQuery();
                        this.Hide();
                        SalsDelete sd = new SalsDelete();
                        sd.Show();
                    }
                    else
                    {
                        DeleteSlmnIdBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Id");
                    DeleteSlmnIdBox.Focus();
                }
            }
        }
    }
}
