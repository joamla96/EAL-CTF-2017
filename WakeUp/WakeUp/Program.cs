using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakeUp
{
    class Program
    {
        // Startpoint
        private static List<Point> paths = new List<Point>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            TelnetConnection tc = new TelnetConnection("jlab13.eal.dk", 11102);

            string inputx = tc.Read();

            string[] firstInput = inputx.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string input in firstInput)
            {
                string[] split = input.Split(' ');

                if (split.Length == 3)
                {
                    Point newTrack = new Point()
                    {
                        start = int.Parse(split[0]),
                        end = int.Parse(split[1]),
                        time = int.Parse(split[2])

                    };

                    paths.Add(newTrack);
                }
                else if (split.Length == 2)
                {
                    int from = int.Parse(split[0]);
                    int to = int.Parse(split[1]);

                    int distance = CalculateDistance(from, to);
                    tc.Write(distance.ToString());
                }
                else
                {
                    Console.WriteLine(input);
                    Console.ReadLine();
                }
            }

            string inputy = tc.Read();
            Console.WriteLine("Next: " + inputy);
        }

        private int CalculateDistance(int from, int to)
        {
            
            List<Path> Paths = new List<Path>();

            foreach(Point a in paths)
            {
                if(a.start == from)
                {
                    Path newpath = new Path();
                    newpath.route.Add(a);

                }
            }


            throw new NotImplementedException();
        }
    }
}
