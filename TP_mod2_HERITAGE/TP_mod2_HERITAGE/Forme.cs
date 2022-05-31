﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_mod2_HERITAGE
{
    public abstract class Forme
    {
        public abstract double Aire{ get; }
        public abstract double Perimetre { get; }
        public override string ToString()
        {
            return $"Aire = {Aire}" + Environment.NewLine + $"Périmètre = {Perimetre}" + Environment.NewLine;
        }
    }
}
