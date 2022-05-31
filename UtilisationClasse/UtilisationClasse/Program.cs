using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilisationClasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point pointA = new Point();
            pointA.X = 1;
            pointA.Y = 1;

            Console.WriteLine($"Point A, X={pointA.X}, Y={pointA.Y}");
            Point pointB = new Point { X = 2, Y = 2 };
            Console.WriteLine($"Point B, X={pointB.X}, Y={pointB.Y}");
            pointA.Ajouter(pointB);
            Console.WriteLine($"Point A après modification, X={pointA.X}, Y={pointA.Y}");
            Console.ReadKey();
        }
    }
}
