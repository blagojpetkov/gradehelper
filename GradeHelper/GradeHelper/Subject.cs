using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHelper
{
    public class Subject
    {
        public List<Student> students { get; set; }
        public string professorName { get; set; }
        public Subject()
        {
            students = new List<Student>();
        }
    }
}
