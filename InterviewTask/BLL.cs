using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
    public class BLL
    {

        public static double GetDistance(Mast m1, Mast m2)
        {
            double Dx = m1.x - m2.x;
            double Dy = m1.y - m2.y;
            return Math.Sqrt((Dx*Dx) + (Dy*Dy));
        }

    }
}
