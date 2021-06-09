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
        public List<Subject> subjects { get; set; }
        public Subject selectedSubject { get; set; }

        public MainMenuAssistant(List<Subject> subjects)
        {
            InitializeComponent();
            selectedSubject = null;
            this.subjects = subjects;
            foreach (Subject s in subjects)
            {
                comboBox1.Items.Add(s.name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Subject s in subjects)
            {
                if (s.name.Equals(comboBox1.Text))
                {
                    selectedSubject = s;
                    break;
                }
            }
            if (selectedSubject == null) return;
            int pointX = 25;
            int pointY = 70;
            panel1.Controls.Clear();
            for (int i = 0; i < selectedSubject.numParts; i++)
            {
                Label label = new Label();
                label.Text = selectedSubject.parts[i].name;
                label.Location = new Point(pointX, pointY);
                label.Width = 200;
                panel1.Controls.Add(label);
                TextBox a1 = new TextBox();
                a1.Name = ("tb" + i * 10 + 1).ToString();
                a1.Location = new Point(pointX + 250, pointY - 4);
                //if there is a student with the index, fill in the textboxes
                if (textBox1.Text != "")
                {
                    foreach (Student s in selectedSubject.students)
                    {
                        if (s.index == textBox1.Text)
                        {
                            a1.Text = s.parts[i].points.ToString();
                        }
                    }

                }

                panel1.Controls.Add(a1);
                panel1.Show();
                pointY += 40;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedSubject == null)
            {
                MessageBox.Show("Потребно е да селектирате предмет за кој што сакате да додадете студент");
                return;
            }
            double poeniOdDel = 0;
            Student s = new Student(textBox1.Text);
            for (int i = 0; i < selectedSubject.numParts; i++)
            {
                if (textBox1.Text == "" || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 1).ToString()].Text, out poeniOdDel))
                {
                    return;
                }
                s.parts.Add(new ExamPart(selectedSubject.parts[i].coefficient, poeniOdDel, selectedSubject.parts[i].name, selectedSubject.parts[i].minimumPointsToPass, selectedSubject.parts[i].maximum));
            }


            //block adding a student with same index
            foreach (Student student in selectedSubject.students.ToList())
            {
                if (student.index == s.index)
                {
                    MessageBox.Show("Студент со тој индекс веќе постои во листата на студенти. Доколку сакате да го измените мора да бидете во улога Професор", "Известување", MessageBoxButtons.OK);
                    return;
                }
            }
            selectedSubject.students.Add(s);
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
