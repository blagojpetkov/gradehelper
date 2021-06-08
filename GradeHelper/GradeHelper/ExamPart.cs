using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeHelper
{
    public class ExamPart
    {
        public double coefficient { get; set; }
        public double points { get; set; }
        public string name { get; set; }
        public double minimumPointsToPass { get; set; }
        public double maximum { get; set; }

        public ExamPart(double coefficient, double points, string name, double minimumPointsToPass, double maximum)
        {
            this.coefficient = coefficient;
            this.points = points;
            this.name = name;
            this.minimumPointsToPass = minimumPointsToPass;
            this.maximum = maximum;
        }

        public double value()
        {
            return coefficient * points/maximum*100;
        }
    }
}
