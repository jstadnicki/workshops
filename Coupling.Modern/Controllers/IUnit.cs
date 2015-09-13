using System.Linq;
using System.Threading.Tasks;
using Coupling.Modern.DataModels;
using Microsoft.Data.Entity;

namespace Coupling.Modern.Controllers
{
    public interface IUnit
    {
        DbSet<Car> Cars { get; }
        IQueryable<Garage> Garages { get; }
        Task<int> Save();
        Task Remove(int id);

        void Add(Car car);
    }
}