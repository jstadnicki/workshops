namespace Coupling.Controllers
{
    using System.Linq;

    using Coupling.DataModels;

    public interface IUnit
    {
        IQueryable<Car> Cars { get; }
        void Save();
        void Remove(int id);

        void Add(Car car);
    }
}