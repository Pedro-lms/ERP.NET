﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pedro.Scheduler.Data.DataAccess;
using Pedro.Web.Events.Interfaces;

namespace Pedro.Web.Areas.Scheduler.Controllers
{
    [Area(Constants.Areas.Scheduler)]
    [Authorize]
    public class SchedulerBaseController : Controller
    {
        public SchedulerBaseController(ISchedulerWorkData schedulerWorkData, IMapper mapper, IEventsFactory eventsFactory)
        {
            this.SchedulerWorkData = schedulerWorkData;
            this.Mapper = mapper;
            this.EventsFactory = eventsFactory;
        }

        public ISchedulerWorkData SchedulerWorkData { get; set; }

        public IMapper Mapper { get; set; }

        public IEventsFactory EventsFactory { get; set; }
    }
}
