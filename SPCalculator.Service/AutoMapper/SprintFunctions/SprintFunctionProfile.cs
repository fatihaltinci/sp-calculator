using AutoMapper;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Sprints;

namespace SPCalculator.Service.AutoMapper.SprintFunctions
{
    public class SprintFunctionProfile : Profile
    {
        public SprintFunctionProfile()
        {
            CreateMap<SprintFunction, Sprint>().ReverseMap();
            CreateMap<SprintFunction, SprintAddModel>().ReverseMap();
        }


    }
}
