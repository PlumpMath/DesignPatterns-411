using System;
using System.Collections.Generic;

namespace CreationalPatterns.RealWorldCodes.Prototype
{
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private readonly int _red;
        private readonly int _green;
        private readonly int _blue;

        public Color(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}",_red, _green, _blue);

            return MemberwiseClone() as ColorPrototype;
        }
    }

    class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
