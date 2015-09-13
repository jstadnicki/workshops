namespace Coupling.Modern.ViewModels
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(string name, string price, string carType, string color, int id)
        {
            Name = name;
            Price = price;
            CarType = carType;
            Color = color;
            Id = id;
        }

        public string Name { get; set; }
        public string Price { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
    }
}