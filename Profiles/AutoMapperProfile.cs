using AutoMapper;

using VisitorManagementStudent2022.Models;
using VisitorManagementStudent2022.ViewModels;

namespace VisitorManagementStudent2022.Profiles
{
    public class AutoMapperProfile : Profile
    {


        public AutoMapperProfile()
        {

            CreateMap<Visitors, VisitorsVM>().ReverseMap();
            CreateMap<StaffNames, StaffNamesVM>().ReverseMap();


        }





    }
}
