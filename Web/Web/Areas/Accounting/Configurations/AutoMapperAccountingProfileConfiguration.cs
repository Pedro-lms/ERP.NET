using AutoMapper;
using Accounting.Core.Entities;
using Accounting.Core.Entities.ValueObjects;
using Pedro.Web.Areas.Accounting.Models.HomeViewModels;
using Pedro.Web.Areas.Accounting.Models.SharedViewModels;

namespace Pedro.Web.Areas.Accounting.Configurations
{
    public class AutoMapperAccountingProfileConfiguration : Profile
    {
        public AutoMapperAccountingProfileConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<Paycheck, PaycheckViewModel>()
                .ForMember(x => x.Payments, opt => opt.ResolveUsing<PaychekPaymentsResolver>())
                .ForMember(x => x.Period, opt => opt.ResolveUsing<PeriodResolver<Paycheck, PaycheckViewModel>>());
        }
    }
}
