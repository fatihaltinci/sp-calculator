using AutoMapper;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Functions;
using SPCalculator.Entity.Models.Sprints;

namespace SPCalculator.Service.AutoMapper.Sprints
{
    public class FunctionProfile : Profile
    {
        public FunctionProfile()
        {
            CreateMap<FunctionModel, Function>().ReverseMap(); // FunctionModel ile Function arasında çift yönlü bir map oluşturuldu
            CreateMap<FunctionAddModel, Function>().ReverseMap(); // FunctionAddModel ile Function arasında çift yönlü bir map oluşturuldu
            CreateMap<FunctionUpdateModel, Function>().ReverseMap(); // FunctionUpdateModel ile Function arasında çift yönlü bir map oluşturuldu
            CreateMap<FunctionUpdateModel, FunctionModel>().ReverseMap(); // FunctionModel ile FunctionUpdateModel arasında çift yönlü bir map oluşturuldu
            CreateMap<FunctionAddModel, FunctionModel>().ReverseMap(); // FunctionModel ile FunctionAddModel arasında çift yönlü bir map oluşturuldu
        }
    }
}
