using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDic
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            string[] mas = new string[] {"drizzle","shower","rain","downpour","flood","hail","sleet","snow","drizzle","snowflike", "hot","warm","cool","cold","freezing",
            "cloudy", "gloomy","foggy","overcast", "clean", "brieeze", "blustery","windy","gale","hurricane", "forecast", "drought", "lighting", "thunder", "raibow"};
            while (true)
            {
                Console.WriteLine($"{mas[random.Next(0,mas.Length)]}");
                Console.ReadKey();
            }
        }
    }
}
