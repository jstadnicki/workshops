namespace Coupling.Areas.Boss.Services.Garage
{
    using Coupling.Areas.Boss.Models.Garage;

    public interface IGarageListService
    {
        GarageListViewModel GetListGarageViewModel();
    }
}