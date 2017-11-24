using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUp
{
    public class Point
    {
        public int start { get; set; }
        public int end { get; set; }
        public int time { get; set; }

        public override string ToString()
        {
            string i = "Start: " + start;
             i += " End: " + end;
             i += " Time: " + time;

            return i;
        }
    }
}
