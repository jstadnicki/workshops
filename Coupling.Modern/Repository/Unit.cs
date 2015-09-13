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
            // Make Blog.Url required
            modelBuilder.Entity<Car>();
            //modelBuilder.Entity<Garage>();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //}
        public DbSet<Car> Cars { get; set; }

        //public DbSet<Garage> Garages { get; set; }
        //public IQueryable<Car> Cars => CarsSet;

        public IQueryable<Garage> Garages { get; private set; }

        public async Task<int> Save()
        {
           return await SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var i = await Cars.FirstAsync(m => m.Id == id);
            Cars.Remove(i);
        }

        public void Add(Car car)
        {
            Cars.Add(car);
        }
    }
}