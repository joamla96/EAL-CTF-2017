using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibleCodeExtractor
{
    class Program
    {
        public string Text = System.IO.File.ReadAllText("./text.txt");
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            bool shouldRun = true;
            int startpoint = 0;
            int spacing = 1;

            string Text = System.IO.File.ReadAllText("./text.txt");

            string word = string.Empty;
            
            while(shouldRun)
            {
                string Aword = FindInString(startpoint, spacing);
                Console.WriteLine(Aword);

                if(Aword.Length == 9)
                {
                    Console.WriteLine("Found: " + Aword);
                    Console.ReadLine();
                } 

                startpoint++;

                if(startpoint > (Text.Length - 1))
                {
                    spacing++;
                    startpoint = 1;
                }

                if(spacing > (Text.Length -1))
                {
                    shouldRun = false;
                    Console.WriteLine("End of Program");
                    Console.ReadLine();
                }
            }
        }

        public string FindInString(int StartPoint, int Spacing)
        {
            string word = string.Empty;
            int point = StartPoint;

            for (int i = 0; i < 4; i++)
            {
                word += Text[point];
                point = point + Spacing;
                if (point > (Text.Length - 1))
                {
                    int overBy = point - Text.Length;
                    point = overBy;
                }
            }

            if (word == "EAL{")
            {
                for (int j = 0; j < 3; j++)
                {
                    word += Text[point];
                    point = point + Spacing;
                    if (point > (Text.Length - 1))
                    {
                        int overBy = point - Text.Length;
                        point = overBy;
                    }
                }
            }

            return word;
        }
    }
}
