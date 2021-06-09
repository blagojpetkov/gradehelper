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
    public partial class ChangeSubject : Form
    {

        public List<Subject> subjects { get; set; }
        public ChangeSubject(List<Subject> subjects)
        {
            InitializeComponent();
            this.subjects = subjects;
            foreach(Subject s in subjects)
            {
                comboBox1.Items.Add(s.name);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            Subject todo = null;
            foreach(Subject x in subjects.ToList())
            {
                if (x.name.Equals(comboBox1.Text))
                {
                    todo = x;
                }
            }

            if (todo == null) return;

            double udelVoOcena = 0;
            double minPoeni = 0;
            double maxPoeni = 0;
            todo.parts.Clear();
                for (int i = 0; i < todo.numParts; i++)
                {
                    if (!Double.TryParse(panel1.Controls[("tb" + i * 10 + 2).ToString()].Text, out udelVoOcena) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 3).ToString()].Text, out minPoeni) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 4).ToString()].Text, out maxPoeni))
                    {
                        return;
                    }
                    todo.parts.Add(new ExamPart(udelVoOcena, -100, panel1.Controls[("tb" + i * 10 + 1).ToString()].Text, minPoeni, maxPoeni));
                }

            for(int i = 0; i < todo.students.Count; i++)
            {
                for(int j = 0; j < todo.students[i].parts.Count; j++)
                {
                    if (!Double.TryParse(panel1.Controls[("tb" + j * 10 + 2).ToString()].Text, out udelVoOcena) || !Double.TryParse(panel1.Controls[("tb" + j * 10 + 3).ToString()].Text, out minPoeni) || !Double.TryParse(panel1.Controls[("tb" + j * 10 + 4).ToString()].Text, out maxPoeni))
                    {
                        return;
                    }
                    todo.students[i].parts[j].coefficient = udelVoOcena;
                    todo.students[i].parts[j].minimumPointsToPass = minPoeni;
                    todo.students[i].parts[j].maximum = maxPoeni;
                }
            }
                this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject todo = null;
            foreach (Subject x in subjects.ToList())
            {
                if (x.name.Equals(comboBox1.Text))
                {
                    todo = x;
                }
            }
            if (todo == null) return;

            int pointX = 25;
            int pointY = 10;
            panel1.Controls.Clear();
                for (int i = 0; i < todo.numParts; i++)
                {
                    Label label = new Label();
                    label.Text = (i + 1) + ".";
                    label.Location = new Point(pointX - 25, pointY + 4);
                    label.Width = 25;
                    panel1.Controls.Add(label);
                    TextBox a1 = new TextBox();
                    a1.Name = ("tb" + i * 10 + 1).ToString();
                    a1.Location = new Point(pointX, pointY);
                a1.Text = todo.parts[i].name;

                    TextBox a2 = new TextBox();
                    a2.Name = ("tb" + i * 10 + 2).ToString();
                    a2.Location = new Point(pointX + 150, pointY);
                a2.Text = todo.parts[i].coefficient.ToString();

                    TextBox a3 = new TextBox();
                    a3.Name = ("tb" + i * 10 + 3).ToString();
                    a3.Location = new Point(pointX + 300, pointY);
                a3.Text = todo.parts[i].minimumPointsToPass.ToString();

                    TextBox a4 = new TextBox();
                    a4.Name = ("tb" + i * 10 + 4).ToString();
                    a4.Location = new Point(pointX + 450, pointY);
                a4.Text = todo.parts[i].maximum.ToString();

                panel1.Controls.Add(a1);
                    panel1.Controls.Add(a2);
                    panel1.Controls.Add(a3);
                    panel1.Controls.Add(a4);
                    panel1.Show();
                    pointY += 40;
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            Subject todo = null;
            foreach (Subject x in subjects.ToList())
            {
                if (x.name.Equals(comboBox1.Text))
                {
                    todo = x;
                }
            }
            if (todo == null) return;
            if(MessageBox.Show("Дали сте сигурни дека сакате да го избришете предметот? Со него се бришат и сите резултати кои што ги имале студентите кај истиот.", "Предупредување", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                subjects.Remove(todo);
            }
            this.Close();
        }
    }
}
