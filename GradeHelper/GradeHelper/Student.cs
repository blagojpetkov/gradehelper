using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHelper
{
    [Serializable]
    public class Student
    {
        public List<double> parts { get; set; }
        public string index { get; set; }
        public Student(string index)
        {
            this.index = index;
            parts = new List<double>();
        }
    }
}
