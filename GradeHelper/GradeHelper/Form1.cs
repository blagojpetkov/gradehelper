using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeHelper
{
    public partial class Form1 : Form
    {
        public List<Student> students{ get; set; }
        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //professor
            Login form = new Login("1234");
            if(form.ShowDialog()==DialogResult.OK)
            {
                MainMenuProfessor form1 = new MainMenuProfessor(students);
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
                MainMenuAssistant form1 = new MainMenuAssistant(students);
                form1.ShowDialog();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox4_Click(null, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainMenuStudent form = new MainMenuStudent(students);
            form.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, students);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    students = (List<Student>)formatter.Deserialize(fs);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            students = new List<Student>();
        }

        private void упатствоЗаКористењеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManual dialog = new UserManual();
            dialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
