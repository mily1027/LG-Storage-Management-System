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
    public partial class SalsUpdate : Form
    {
        public Boolean a = false;
        public SalsUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s_name.Text != "" && s_id.Text != "" && s_address.Text != "" && s_rank.Text != "" && s_age.Text != "" && s_mobile.Text != "" && s_whour.Text != "")
            {
                string query = "UPDATE Employee_tbl SET s_name='" + s_name.Text + "', s_id ='" + s_id.Text + "', s_address ='" + s_address.Text + "', s_rank ='" + s_rank.Text + "', s_age ='" + s_age.Text + "', s_mobile ='" + s_mobile.Text + "', s_whour = '" + s_whour.Text + "' where s_id = '" + s_id.Text + "'";


                if (MessageBox.Show("Would you like to Update this Information?", "Update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    a = SaveInformation(query);
                    if (a)
                    {
                        s_name.Text = "";
                        s_id.Text = "";
                        s_address.Text = "";
                        s_rank.Text = "";
                        s_age.Text = "";
                        s_mobile.Text = "";
                        s_whour.Text = "";
                        SalsSearch se = new SalsSearch();
                        this.Hide();
                        se.Show();
                    }
                }
                else
                {
                }


            }
            else
                MessageBox.Show("Something Missing");
        }
        Boolean SaveInformation(string query)
        {
            try
            {
                SqlConnection Conn = LG_connection.LgConnection();
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
