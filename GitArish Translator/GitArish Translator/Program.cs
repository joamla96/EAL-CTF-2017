using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitArish_Translator
{
    class Program
    {
        private Dictionary<char, char> translations = new Dictionary<char, char>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            int runs = 0;

            string Gip0 = "ejp mysljylc kd kxveddknmc re jsicpdrysi";
            string Gip1 = "rbcpc ypc rtcsra dkh wyfrepkym veddknkmkrkcd";
            string Gip2 = "de kr kd eoya kw aej tysr re ujdr lkgc jv";

            string Eng0 = "our language is impossible to understand";
            string Eng1 = "there are twenty six factorial possibilities";
            string Eng2 = "so it is okay if you want to just give up";

            string Gip3 = "zq";
            string Eng3 = "qz";

            LoadTranslation(Gip0, Eng0);
            LoadTranslation(Gip1, Eng1);
            LoadTranslation(Gip2, Eng2);
            LoadTranslation(Gip3, Eng3);

            TelnetConnection tc = new TelnetConnection("jlab13.eal.dk", 11103);
            while(tc.IsConnected)
            {
                runs++;
                Console.WriteLine("Translation: " + runs);
                string input = tc.Read();
                Console.WriteLine(input);

                string translated = Translate(input);
                Console.WriteLine(translated);
                tc.WriteLine(translated);

                Console.WriteLine("------------------------\n");
            }
        }

        private string Translate(string gip)
        {
            string result = string.Empty;
            foreach(char c in gip)
            {

                if (Char.IsLetter(c))
                {
                    result += translations[c];
                } else
                {
                    result += c;
                }
                
            }
            return result;
        }

        private void LoadTranslation(string Gip, string Eng)
        {
            int index = 0;
            foreach (char c in Gip)
            {
                if (!translations.ContainsKey(c))
                {
                    translations.Add(c, Eng[index]);
                }
                index++;
            }
        }
    }
}
