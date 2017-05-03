using System;
using System.Collections.Generic;

namespace CreationalPatterns.RealWorldCodes
{
    class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; protected set; }
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            Vehicle = new Vehicle("Мотоцикл");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Рама мотоцикла";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "5.0 л";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "0";
        }
    }

    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            Vehicle = new Vehicle("Автомобиль");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Рама автомобиля";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "2.5 л";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "4";
        }
    }

    class Vehicle
    {
        private readonly string _vehicleType;
        private readonly Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Тип транспортного средства: {0}", _vehicleType);
            Console.WriteLine(" Рама : {0}", _parts["frame"]);
            Console.WriteLine(" Двигатель : {0}", _parts["engine"]);
            Console.WriteLine(" Колеса: {0}", _parts["wheels"]);
            Console.WriteLine(" Двери : {0}", _parts["doors"]);
        }
    }
}
