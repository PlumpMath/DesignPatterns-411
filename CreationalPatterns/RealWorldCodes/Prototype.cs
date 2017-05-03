using System;
using System.Collections.Generic;

namespace CreationalPatterns.RealWorldCodes
{
    abstract class ColorPrototype
    {
        protected readonly int Red;
        protected readonly int Green;
        protected readonly int Blue;

        protected ColorPrototype(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public virtual void ShowColor()
        {
            Console.WriteLine("Скопированный цвет: {0,3},{1,3},{2,3}", Red, Green, Blue);
        }
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        public Color(int red, int green, int blue) : base(red, green, blue) { }

        public override ColorPrototype Clone()
        {
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
