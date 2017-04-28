using System;
using System.Collections.Generic;

namespace StructuralPatterns.RealWorldCodes
{
    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class CharacterFactory
    {
        private readonly Dictionary<char, Character> _characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (_characters.ContainsKey(key))
                character = _characters[key];
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                    //...
                    case 'Z':
                        character = new CharacterZ();
                        break;
                }
                _characters.Add(key, character);
            }
            return character;
        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    abstract class Character
    {
        protected char Symbol;
        protected int Width;
        protected int Height;
        protected int Ascent;
        protected int Descent;
        protected int PointSize;

        public abstract void Display(int pointSize);
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterA : Character
    {
        // Constructor
        public CharacterA()
        {
            Symbol = 'A';
            Height = 100;
            Width = 120;
            Ascent = 70;
            Descent = 0;
        }

        public override void Display(int pointSize)
        {
            PointSize = pointSize;
            Console.WriteLine(Symbol + " (pointsize " + PointSize + ")");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterB : Character
    {
        // Constructor
        public CharacterB()
        {
            Symbol = 'B';
            Height = 100;
            Width = 140;
            Ascent = 72;
            Descent = 0;
        }

        public override void Display(int pointSize)
        {
            PointSize = pointSize;
            Console.WriteLine(Symbol + " (pointsize " + PointSize + ")");
        }

    }


    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterZ : Character
    {
        // Constructor
        public CharacterZ()
        {
            Symbol = 'Z';
            Height = 100;
            Width = 100;
            Ascent = 68;
            Descent = 0;
        }

        public override void Display(int pointSize)
        {
            PointSize = pointSize;
            Console.WriteLine(Symbol + " (pointsize " + PointSize + ")");
        }
    }
}
