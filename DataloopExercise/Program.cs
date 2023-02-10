using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataloopExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new WebCrawler();
            crawler.Crawl("https://wallpapers.com/", 0);
            Console.ReadLine();
        }
    }
}
