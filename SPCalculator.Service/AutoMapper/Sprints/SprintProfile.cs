using AutoMapper;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Sprints;

namespace SPCalculator.Service.AutoMapper.Sprints
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<SprintModel, Sprint>().ReverseMap(); // SprintModel ile Sprint arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintAddModel, Sprint>().ReverseMap(); // SprintAddModel ile Sprint arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintUpdateModel, Sprint>().ReverseMap(); // SprintUpdateModel ile Sprint arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintUpdateModel, SprintModel>().ReverseMap(); // SprintModel ile SprintUpdateModel arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintAddModel, SprintModel>().ReverseMap(); // SprintModel ile SprintAddModel arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintUpdateModel, SprintAddModel>().ReverseMap(); // SprintAddModel ile SprintUpdateModel arasında çift yönlü bir map oluşturuldu
            CreateMap<SprintDetailsModel, Sprint>().ReverseMap(); // SprintDetailsModel ile Sprint arasında çift yönlü bir map oluşturuldu
        }
    }
}
