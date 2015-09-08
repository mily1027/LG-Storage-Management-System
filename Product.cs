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
    public partial class Product : Form
    {
        public Boolean save = false;
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = P_Name.Text;
            string id = P_ID.Text;
            string size = P_Size.Text;
            string model = P_Model.Text;
            string price = P_Price.Text;
            string type = P_Type.Text;
            string quality = P_Quality.Text;
            string bid = P_BrID.Text;

            if (name != "" && id != "" && size != "" && model != "" && price != "" && type != "" && quality != "" && bid != "")
            {
                string query = "INSERT into product_tbl values('" + name + "','" + id + "','" + size + "','" + model + "','" + price + "','" + type + "','" + quality + "','"+bid+"')";
                if (MessageBox.Show("Would you like to save this Information?", "Save Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveDataIntoTable(query);

                    if (save)
                    {
                        P_Name.Text = "";
                        P_ID.Text = "";
                        P_Size.Text = "";
                        P_Model.Text = "";
                        P_Price.Text = "";
                        P_Type.Text = "";
                        P_Quality.Text = "";
                        P_BrID.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void P_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

            int countpid = 0;
            if (P_Type.Text == "Air-Condition" || P_Type.Text == "LCD-TV")
            {
                SqlConnection con1 = LG_connection.LgConnection();
                String query2 = "select p_id from product_tbl";
                SqlCommand cmd = new SqlCommand(query2, con1);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string pid = reader["P_id"].ToString();
                    int.TryParse(pid, out countpid);
                    P_ID.Text = "" + (countpid + 1);
                }

            }
        }
    }
}
