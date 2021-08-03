using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
   public class Mast

    {
        //Co ordinates for the mast
        public int x { get; set; }
        public int y{ get; set; }


       public Mast (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

       public string print()
        {
            return String.Format("({0},{1})", this.x, this.y);

        }
    }
}
