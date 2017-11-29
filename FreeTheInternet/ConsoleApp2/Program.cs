using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        string url = @"http://jlab13.eal.dk:11105/poll?field=No";

        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        void Run()
        {
            List<Thread> threads = new List<Thread>();
            for (int i=0; i< 3;i++)
            {
                Thread x = new Thread(CallWebsite);
                x.Start();
                threads.Add(x);
            }
            Console.ReadLine();
        }

        void CallWebsite()
        {
            while (true)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
        }
    }
}
