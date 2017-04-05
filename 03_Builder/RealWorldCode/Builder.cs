using System;
using System.Collections.Generic;

namespace Builder.RealWorldCode
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
            Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "500 cc";
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
            Vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "2500 cc";
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
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            Vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "50 cc";
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
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}
