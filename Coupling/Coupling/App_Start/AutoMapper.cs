namespace Coupling
{
    using System.Collections.Generic;

    using AutoMapper;

    using Coupling.Areas.Boss.Models.Garage;
    using Coupling.DataModels;

    public class ApplicationAutoMapper
    {
        public static void Configure()
        {
            Mapper.CreateMap<List<Garage>, GarageListViewModel>();
            Mapper.CreateMap<Garage, GarageViewModel>();
            Mapper.CreateMap<GarageAddModel, Garage>();
        } 
    }
}