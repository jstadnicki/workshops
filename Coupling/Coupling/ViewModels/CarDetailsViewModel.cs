namespace Coupling.Controllers
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(string name, string price, string carType, string color, int id)
        {
            this.Name = name;
            this.Price = price;
            this.CarType = carType;
            this.Color = color;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Price { get; set; }
        public string CarType { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
    }
}