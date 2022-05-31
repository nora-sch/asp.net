using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenerique
{
    public class Fruit : Nourriture
    {
        public DateTime DateCuilette { get; set; }
        public bool EstPerime()
        {
            return (DateTime.Now - DateCuilette).Days > 10;
        }
    }
}
