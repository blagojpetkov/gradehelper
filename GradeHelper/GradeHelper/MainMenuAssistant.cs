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
    public partial class MainMenuAssistant : Form
    {
        public List<Student> students { get; set; }
        public MainMenuAssistant()
        {
            InitializeComponent();
        }

        public MainMenuAssistant(List<Student> students)
        {
            InitializeComponent();
            this.students = students;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double poeniOdDel = 0;
            double udelVoOcena = 0;
            double minPoeni = 0;
            double maxPoeni = 0;
            Student s = new Student(textBox1.Text);
            int txtno = 0;
            int.TryParse(textBox3.Text, out txtno);
            for (int i = 0; i < txtno; i++)
            {
                if (!Double.TryParse(panel1.Controls[("tb" + i * 10 + 1).ToString()].Text, out poeniOdDel) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 2).ToString()].Text, out udelVoOcena) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 3).ToString()].Text, out minPoeni) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 4).ToString()].Text, out maxPoeni))
                {
                    return;
                }
                s.parts.Add(new ExamPart(udelVoOcena, poeniOdDel, "part", minPoeni, maxPoeni));
            }
            students.Add(s);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int txtno;
            bool success = int.TryParse(textBox3.Text, out txtno);

            int pointX = 15;
            int pointY = 30;
            panel1.Controls.Clear();
            if (success)
                for (int i = 0; i < txtno; i++)
                {
                    TextBox a1 = new TextBox();
                    a1.Name = ("tb" + i * 10 + 1).ToString();
                    a1.Location = new Point(pointX, pointY);

                    TextBox a2 = new TextBox();
                    a2.Name = ("tb" + i * 10 + 2).ToString();
                    a2.Location = new Point(pointX + 150, pointY);

                    TextBox a3 = new TextBox();
                    a3.Name = ("tb" + i * 10 + 3).ToString();
                    a3.Location = new Point(pointX + 300, pointY);

                    TextBox a4 = new TextBox();
                    a4.Name = ("tb" + i * 10 + 4).ToString();
                    a4.Location = new Point(pointX + 450, pointY);

                    panel1.Controls.Add(a1);
                    panel1.Controls.Add(a2);
                    panel1.Controls.Add(a3);
                    panel1.Controls.Add(a4);
                    panel1.Show();
                    pointY += 40;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
