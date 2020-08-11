using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SurfaceCalculator
{
    public abstract class Form
    {

        public double A { get; set; }
        public double B { get; set; }
        public string Name
        {
            get
            {
                return GetType().Name;
            }
        }
        public abstract double Surface{ get; }
    }
}
