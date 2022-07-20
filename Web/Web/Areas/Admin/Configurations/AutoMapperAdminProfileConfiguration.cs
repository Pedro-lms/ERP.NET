using AutoMapper;
using Pedro.Companies.Core.Entities;
using Pedro.Web.Areas.Admin.Models.ControlPanelViewModels;

namespace Pedro.Web.Areas.Admin.Configurations
{
    public class AutoMapperAdminProfileConfiguration : Profile
    {
        public AutoMapperAdminProfileConfiguration()
        {
            CreateMap<ApplicationUser, ShortUserViewModel>();
        }
    }
}
