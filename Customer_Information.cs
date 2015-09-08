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

namespace LG_Storage
{
    public partial class Customer_Information : Form
    {
        
        SqlConnection con;
        SqlCommand cmd=new SqlCommand();
        private void connect()
        {
            String s = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\pc\\Documents\\LG_Electronic_Shop_Management.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            con = new SqlConnection(s);
            con.Open();
        }
        private void disConnect()
        {
            con.Close();
        }
        public Customer_Information()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();

            String s1 = "insert into tbl_Customer values('" + comboBox2.Text + "','" + txtBxID.Text + "','" + txtBxCusNm.Text + "','" + txtBxADD.Text + "','" + txtBxPhn.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(s1);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            disConnect();
          
            MessageBox.Show("Saved successfully!");
        }

        private void txtBxCusNm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBxADD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBxPhn_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
