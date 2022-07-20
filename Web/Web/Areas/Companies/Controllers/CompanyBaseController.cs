using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pedro.Companies.Data.DataAccess;

namespace Pedro.Web.Areas.Companies.Controllers
{
    [Area(Constants.Areas.Companies)]
    [Authorize]
    public class CompanyBaseController : Controller
    {
        public CompanyBaseController(ICompanyWorkData companyWorkData, IMapper mapper)
        {
            this.CompanyWorkData = companyWorkData;
            this.Mapper = mapper;
        }

        public ICompanyWorkData CompanyWorkData { get; set; }

        public IMapper Mapper { get; set; }
    }
}