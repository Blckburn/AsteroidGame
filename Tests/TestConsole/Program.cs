using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer("Игрок 1", new DateTime(1983, 12, 5, 12, 23, 17));

            Gamer[] gamers = new Gamer[100];
            for (var i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer($"Gamer{i + 1}", DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));

                gamers[i] = g;
            }

            gamer.SayYourName();

            Console.WriteLine();
            foreach (var g in gamers)
                g.SayYourName();

            Console.WriteLine();

            //gamer.SetName("2123");
            //Console.WriteLine("Имя игрока {0} ", gamer.GetName());

            gamer.Name = "123";

            Console.WriteLine("Игрок {0}", gamer.Name);

            Console.ReadLine();
        }
    }
}
