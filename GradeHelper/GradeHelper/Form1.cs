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
        public List<Subject> subjects { get; set; }
        public User currentUser { get; set; }
        public Form1()
        {
            InitializeComponent();
            subjects = new List<Subject>();
            currentUser = null;
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //professor
            if (currentUser != null && currentUser.password=="1234")
            {
                MainMenuProfessor form1 = new MainMenuProfessor(subjects);
                form1.ShowDialog();
                return;
            }

            Login form = new Login("1234");
            if(form.ShowDialog()==DialogResult.OK)
            {
                currentUser = new User(form.name, form.password);
                label5.Text = "Добредојде, " + currentUser.name;
                MainMenuProfessor form1 = new MainMenuProfessor(subjects);
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

            if (currentUser != null)
            {
                MainMenuAssistant form1 = new MainMenuAssistant(subjects);
                form1.ShowDialog();
                return;
            }


            Login form = new Login("123");
            if (form.ShowDialog() == DialogResult.OK)
            {
                currentUser = new User(form.name, form.password);
                label5.Text = "Добредојде, " + currentUser.name;
                MainMenuAssistant form1 = new MainMenuAssistant(subjects);
                form1.ShowDialog();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox4_Click(null, null);
        }








        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //student
            ChooseSubject form = new ChooseSubject(subjects);
            if(form.ShowDialog() == DialogResult.OK)
            {
                MainMenuStudent dialog = new MainMenuStudent(form.selectedSubject.students);
                dialog.Text = form.selectedSubject.name;
                dialog.ShowDialog();
            }
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
                    formatter.Serialize(fs, subjects);
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
                    subjects = (List<Subject>)formatter.Deserialize(fs);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subjects = new List<Subject>();
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

        private void button1_Click(object sender, EventArgs e)
        {
            NewSubject dialog = new NewSubject(subjects);
            dialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentUser = null;
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentUser != null && currentUser.password == "1234")
            {
                ChangeSubject change = new ChangeSubject(subjects);
                change.ShowDialog();
                return;
            }

            Login form = new Login("1234");
            if (form.ShowDialog() == DialogResult.OK)
            {
                currentUser = new User(form.name, form.password);
                label5.Text = "Добредојде, " + currentUser.name;
                ChangeSubject change = new ChangeSubject(subjects);
                change.ShowDialog();
            }
        }
    }
}
