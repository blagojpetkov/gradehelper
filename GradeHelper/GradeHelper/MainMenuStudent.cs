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
    public partial class MainMenuStudent : Form
    {
        public Subject subject { get; set; }
        public static int getGrade(double points)
        {
            if (points >= 90)
                return 10;
            if (points < 90 && points >= 80)
                return 9;
            if (points < 80 && points >= 70)
                return 8;
            if (points < 70 && points >= 60)
                return 7;
            if (points < 60 && points >= 50)
                return 6;
            else return 5;

        }
        public MainMenuStudent(Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
            init();
        }

        public void init()
        {

            if (subject.students.Count > 0)
            {
                Student s = subject.students[0];
                foreach (var part in subject.parts)
                {
                    dataGridView1.Columns.Add("columnname", part.name);
                }
                dataGridView1.Columns.Add("columnname", "Вкупно скалирани поени");
                dataGridView1.Columns.Add("columnname", "Оцена");
                foreach (Student student in subject.students)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    dataGridView1.Rows.Add(row);
                }
            }
            int x = 0;
            int y = 0;
            
            foreach (var s in subject.students)
            {
                bool passed = true;
                double value = 0;
                y = 0;
                dataGridView1.Rows[x].Cells[y++].Value = s.index;
                foreach (var part in subject.parts)
                {
                    if (s.parts[y-1] >= part.minimumPointsToPass)
                        dataGridView1.Rows[x].Cells[y].Value = s.parts[y-1];
                    else
                    {
                        dataGridView1.Rows[x].Cells[y].Value = s.parts[y-1] + " (недостигаат " + (part.minimumPointsToPass - s.parts[y-1]) + " поени)";
                        dataGridView1.Columns[y].Width += 50;
                        passed = false;
                    }
                    //formula
                    value += part.coefficient * s.parts[y-1] / part.maximum * 100;
                    //formula
                    y++;
                }
                dataGridView1.Rows[x].Cells[y].Value = value;



                if (passed)
                {
                    dataGridView1.Rows[x].Cells[y + 1].Value = getGrade(value);
                }
                else
                {
                    dataGridView1.Rows[x].Cells[y + 1].Value = "/";
                    dataGridView1.Rows[x].DefaultCellStyle.BackColor = Color.Red;
                }
                x++;
            }


        }

        }
    }
