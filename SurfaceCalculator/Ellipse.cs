using System;
using System.Collections.Generic;
using System.Text;

namespace SurfaceCalculator
{
    class Ellipse : Form
    {
        public override double Surface => ((Math.PI * A * B) / 4);
    }
}
