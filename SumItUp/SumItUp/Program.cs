using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumItUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            TelnetConnection tc = new TelnetConnection("jlab13.eal.dk", 11101);

            while(tc.IsConnected)
            {
                string input = tc.Read();
                Console.WriteLine(input);

                string[] split = input.Split(' ');

                int result = int.Parse(split[0]) + int.Parse(split[1]);
                Console.WriteLine("Result: " + result);

                tc.Write(result + "");
                Console.WriteLine("------------");
            }
        }
    }
}
