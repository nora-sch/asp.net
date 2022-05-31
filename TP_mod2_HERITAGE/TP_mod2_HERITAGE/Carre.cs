using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_mod2_HERITAGE
{
    public class Carre : Forme
    {
        public int Longueur { get; set; }
        public Carre()
        {

        }
        public override double Aire => Longueur * Longueur;
        public override double Perimetre => Longueur * 4;
        public override string ToString()
        {
            return $"Carre de coté {Longueur}" + Environment.NewLine + base.ToString();
        }
 
    }
}
