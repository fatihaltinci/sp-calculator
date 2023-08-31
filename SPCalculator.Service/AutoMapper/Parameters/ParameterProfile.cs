using AutoMapper;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Functions;
using SPCalculator.Entity.Models.Parameters;

namespace SPCalculator.Service.AutoMapper.Sprints
{
    public class ParameterProfile : Profile
    {
        public ParameterProfile()
        {
            CreateMap<ParameterModel, Parameter>().ReverseMap(); // SprintModel ile Sprint arasında çift yönlü bir map oluşturuldu
            CreateMap<ParameterAddModel, Parameter>().ReverseMap(); // FunctionAddModel ile Function arasında çift yönlü bir map oluşturuldu
            CreateMap<ParameterUpdateModel, Parameter>().ReverseMap(); // FunctionUpdateModel ile Function arasında çift yönlü bir map oluşturuldu
            CreateMap<ParameterUpdateModel, ParameterModel>().ReverseMap(); // FunctionModel ile FunctionUpdateModel arasında çift yönlü bir map oluşturuldu
            CreateMap<ParameterAddModel, Parameter>().ReverseMap(); // FunctionModel ile FunctionAddModel arasında çift yönlü bir map oluşturuldu
        }
    }
}
