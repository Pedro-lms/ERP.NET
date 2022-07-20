using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Accounting.Data.DataAccess;
using Pedro.Web.Areas.Accounting.Services;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Areas.Accounting.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        public BaseViewComponent(
                IAccountingWorkData accountingWorkData,
                IPayrollService payrollService,
                IMapper mapper,
                IEventsFactory eventsFactory)
        {
            this.AccountingWorkData = accountingWorkData;
            this.PayrollService = payrollService;
            this.Mapper = mapper;
            this.EventsFactory = eventsFactory;
        }

        public IAccountingWorkData AccountingWorkData { get; set; }

        public IPayrollService PayrollService { get; set; }

        public IMapper Mapper { get; set; }

        public IEventsFactory EventsFactory { get; set; }
    }
}
