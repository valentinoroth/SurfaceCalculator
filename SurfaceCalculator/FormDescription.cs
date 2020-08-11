using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SurfaceCalculator
{
    public class FormDescription
    {
        public string Name { get; set; }
        public ImageSource Image { get; set; }

        public override string ToString() => Name;
        
        private ImageSource LoadImage(string name)
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Images", name + ".gif");
            return new BitmapImage(new Uri(path));
        }

        public FormDescription(string name)
        {
            this.Name = name;
            this.Image = LoadImage(Name);
        }
    }
}
