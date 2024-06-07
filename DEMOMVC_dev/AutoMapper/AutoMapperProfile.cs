using AutoMapper;
using DEMO_dev.Domain.Entities;
using DEMO_dev.ViewModels.Label;

namespace DEMO_dev.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            //CreateMap<>();
            CreateMap<LabelCreateEditVM, Label>();
        }
    }
}
