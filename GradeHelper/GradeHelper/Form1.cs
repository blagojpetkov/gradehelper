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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //professor
            Login form = new Login("1234");
            if(form.ShowDialog()==DialogResult.OK)
            {
                MainMenuProfessor form1 = new MainMenuProfessor();
                form1.ShowDialog();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(null, null);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //assistant
            Login form = new Login("123");
            if (form.ShowDialog() == DialogResult.OK)
            {
                MainMenuAssistant form1 = new MainMenuAssistant();
                form1.ShowDialog();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox4_Click(null, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainMenuStudent form = new MainMenuStudent();
            form.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(null, null);
        }
    }
}
