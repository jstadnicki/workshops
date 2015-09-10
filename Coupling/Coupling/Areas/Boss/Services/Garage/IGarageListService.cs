namespace Coupling.Areas.Boss.Services.Garage
{
    using Models.Garage;

    public interface IGarageListService
    {
        GarageListViewModel GetGarageListViewModel();
    }
}