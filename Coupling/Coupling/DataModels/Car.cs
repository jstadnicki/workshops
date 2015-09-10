namespace Coupling.DataModels
{
    using System.Collections.Generic;

    using Coupling.Common;

    public class Car
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public CarType CarType { get; set; }
    }


    public class Garage
    {
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Vehicle
    {
    }

    public class GarageOwner
    {
        public List<Garage> Garages { get; set; }
    }
}