using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Accounting.Data.DataAccess;
using Pedro.Web.Areas.Accounting.Models.PayrollViewModels;
using Pedro.Web.Areas.Accounting.Services;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Areas.Accounting.ViewComponents
{
    public class AddPaycheckPaymentViewComponent : BaseViewComponent
    {
        public AddPaycheckPaymentViewComponent(
            IAccountingWorkData accountingWorkData, 
            IPayrollService payrollService, 
            IMapper mapper, 
            IEventsFactory eventsFactory) 
            : base(accountingWorkData, payrollService, mapper, eventsFactory)
        {
        }

        public IViewComponentResult Invoke(DateTime from, DateTime to, string employeeId, string paycheckId)
        {
            return View(AddPaymentViewModel.Create(from, to, employeeId, paycheckId));
        }
    }
}
