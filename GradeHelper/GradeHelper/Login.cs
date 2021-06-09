using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeHelper
{
    public partial class Login : Form
    {
        public string password { get; set; }
        public string name { get; set; }

        public Login(string password)
        {
            InitializeComponent();
            this.password = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == password)
            {
                this.name = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
            errorLabel.Text = "Внесовте погрешна лозинка";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
