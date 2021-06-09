using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHelper
{
    public class Subject
    {
        public int numParts { get; set; }
        public string name { get; set; }
        public List<ExamPart> parts { get; set; }
        public List<Student> students { get; set; }
        public Subject()
        {
            parts = new List<ExamPart>();
            students = new List<Student>();
        }
        
    }
}
