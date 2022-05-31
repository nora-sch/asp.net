using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_mod2_HERITAGE
{
    public class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }
           public Rectangle()
        {

        }
        public override double Aire => Largeur * Longueur;
           public override double Perimetre => (Largeur + Longueur) * 2;
        public override string ToString()
        {
            return $"Rectangle de longueur ={ Longueur} et largeur = { Largeur }" + Environment.NewLine + base.ToString();
        }     
      }
}
