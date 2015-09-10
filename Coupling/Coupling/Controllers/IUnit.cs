namespace Coupling.Controllers
{
    using System.Linq;

    using Coupling.DataModels;

    public interface IUnit
    {
        IQueryable<Car> Cars { get; }
        IQueryable<Garage> Garages { get; }
        void Save();
        void Remove(int id);

        void Add(Car car);
    }
}