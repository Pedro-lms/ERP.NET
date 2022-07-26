﻿using System.Collections.Generic;
using Pedro.Web.Areas.Accounting.Models.HomeViewModels;

namespace Pedro.Web.Areas.Accounting.Models.SharedViewModels
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public IEnumerable<PaycheckViewModel> Paycheks { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
