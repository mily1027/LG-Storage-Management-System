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

namespace LG_StorageFinal
{
    public partial class LG_Storage : Form
    {
        public LG_Storage()
        {
            InitializeComponent();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesman sm = new Salesman();
            sm.Show();
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product pr = new Product();
            pr.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchUpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductSearch ps = new ProductSearch();
            ps.Show();
        }

        private void searchUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalsSearch ss = new SalsSearch();
            ss.Show();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalsDelete sd = new SalsDelete();
            sd.Show();
        }
    }
}

