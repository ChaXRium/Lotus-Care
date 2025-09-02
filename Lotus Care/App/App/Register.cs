using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            // Enable DPI scaling for this form
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
