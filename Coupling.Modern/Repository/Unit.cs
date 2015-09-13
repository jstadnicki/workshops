using System.Linq;
using System.Threading.Tasks;
using Coupling.Modern.Controllers;
using Coupling.Modern.DataModels;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Coupling.Modern.Repository
{
    public class Unit : DbContext, IUnit
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>();
        }

        public DbSet<Car> CarsSet { get; set; }

        //public DbSet<Garage> Garages { get; set; }
        public IQueryable<Car> Cars => CarsSet;

        public IQueryable<Garage> Garages { get; private set; }

        public async Task<int> Save()
        {
           return await SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var i = await Cars.FirstAsync(m => m.Id == id);
            CarsSet.Remove(i);
        }

        public void Add(Car car)
        {
            CarsSet.Add(car);
        }
    }
}