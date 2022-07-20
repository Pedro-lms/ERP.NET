using System;
using System.Collections.Generic;
using Pedro.Scheduler.Core.Entities;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Events
{
    public class PaycheckCreatedOrUpdated : IDomainEvent
    {
        public PaycheckCreatedOrUpdated(Paycheck paycheck)
        {
            this.Paycheck = paycheck;
            this.DateOccurred = DateTime.Now;
        }

        public PaycheckCreatedOrUpdated(IEnumerable<Paycheck> paychecks)
        {
            this.Paychecks = paychecks;
            this.DateOccurred = DateTime.Now;
        }        

        public DateTime DateOccurred { get; private set; }

        public Paycheck Paycheck { get; set; }

        public IEnumerable<Paycheck> Paychecks { get; set; }
    }
}
