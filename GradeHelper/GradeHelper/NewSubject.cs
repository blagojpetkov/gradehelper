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
    public partial class NewSubject : Form
    {
        public List<Subject> subjects { get; set; }
        public NewSubject(List<Subject> subjects)
        {
            InitializeComponent();
            this.subjects = subjects;
        }

        private void button3_Click(object sender, EventArgs e)
        {
                int txtno;
                bool success = int.TryParse(textBox3.Text, out txtno);

                int pointX = 25;
                int pointY = 10;
                panel1.Controls.Clear();
                if (success)
                    for (int i = 0; i < txtno; i++)
                    {
                        Label label = new Label();
                        label.Text = (i + 1) + ".";
                        label.Location = new Point(pointX - 25, pointY + 4);
                        label.Width = 25;
                        panel1.Controls.Add(label);
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

        private void button1_Click(object sender, EventArgs e)
        {
            int numParts = 0;
            if(int.TryParse(textBox3.Text, out numParts)) {
                Subject subject = new Subject();
                subject.name = tbname.Text;
                subject.numParts = numParts;

                double udelVoOcena = 0;
                double minPoeni = 0;
                double maxPoeni = 0;

                for (int i = 0; i < numParts; i++)
                {
                    if (tbname.Text == "" || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 2).ToString()].Text, out udelVoOcena) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 3).ToString()].Text, out minPoeni) || !Double.TryParse(panel1.Controls[("tb" + i * 10 + 4).ToString()].Text, out maxPoeni))
                    {
                        return;
                    }
                    subject.parts.Add(new ExamPart(udelVoOcena, -100, panel1.Controls[("tb" + i * 10 + 1).ToString()].Text, minPoeni, maxPoeni));
                }
                subjects.Add(subject);
                this.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
