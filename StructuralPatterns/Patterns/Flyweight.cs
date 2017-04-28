﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Patterns
{
    class FlyweightFactory
    {
        private readonly Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            _flyweights.Add("X", new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)_flyweights[key];
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " +
              extrinsicstate);
        }
    }
}
