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
    public partial class ChooseSubject : Form
    {
        public List<Subject> subjects { get; set; }
        public Subject selectedSubject { get; set; }
        public ChooseSubject(List<Subject> subjects)
        {
            InitializeComponent();
            this.subjects = subjects;
            selectedSubject = null;
            foreach(Subject s in subjects)
            {
                comboBox1.Items.Add(s.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            foreach (Subject s in subjects)
            {
                    if (comboBox1.Text.Equals(s.name))
                        selectedSubject = s;
            }
            DialogResult = DialogResult.OK;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
