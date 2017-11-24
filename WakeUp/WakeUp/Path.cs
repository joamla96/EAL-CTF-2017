using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUp
{
    class Path
    {
        public List<Point> route = new List<Point>();

        public int GetDistance()
        {
            int td = 0;
            foreach(Point a in route)
            {
                td += a.time;
            }

            return td;
        }
    }
}
