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
        public List<Student> students { get; set; }
        public static int getGrade(double points)
        {
            if (points <= 100 && points >= 90)
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
        public MainMenuStudent(List<Student> students)
        {
            InitializeComponent();
            this.students = students;
            init();
        }

        public void init()
        {

            if (students.Count > 0)
            {
                Student s = students[0];
                int i = 0;
                foreach (var part in s.parts)
                {
                    dataGridView1.Columns.Add("columnname", (1 + i++ + " дел").ToString());
                }
                dataGridView1.Columns.Add("columnname", "Вкупно скалирани поени");
                dataGridView1.Columns.Add("columnname", "Оцена");
                foreach (Student student in students)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    dataGridView1.Rows.Add(row);
                }
            }
            int x = 0;
            int y = 0;
            
            foreach (var s in students)
            {
                double value = 0;
                y = 0;
                dataGridView1.Rows[x].Cells[y++].Value = s.index;
                foreach (var part in s.parts)
                {
                    if (part.points >= part.minimumPointsToPass)
                        dataGridView1.Rows[x].Cells[y].Value = part.points;
                    else
                    {
                        dataGridView1.Rows[x].Cells[y].Value = part.points + " (недостигаат " + (part.minimumPointsToPass - part.points) + " поени)";
                        dataGridView1.Columns[y].Width += 50;
                    }
                    value += part.value();
                    y++;
                }
                dataGridView1.Rows[x].Cells[y].Value = value;
                dataGridView1.Rows[x].Cells[y+1].Value = getGrade(value);
                x++;
            }


        }

        }
    }
