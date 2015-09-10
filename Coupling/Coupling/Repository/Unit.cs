namespace Coupling.Controllers
{
    using System.Data.Entity;
    using System.Linq;

    using Coupling.DataModels;

    public class Unit : DbContext, IUnit
    {
        public Unit()
            : base("DefaultConnection")
        {

        }

        public DbSet<Car> CarsSet { get; set; }

        public IQueryable<Car> Cars
        {
            get
            {
                return CarsSet;
            }

        }

        public IQueryable<Garage> Garages { get; private set; }

        public void Save()
        {
            this.SaveChanges();
        }

        public void Remove(int id)
        {
            CarsSet.Remove(CarsSet.Find(id));
        }

        public void Add(Car car)
        {
            CarsSet.Add(car);
        }
    }
}