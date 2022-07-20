﻿using System.Collections.Generic;

namespace Pedro.Projects.Core.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public bool IsFired { get; private set; }

        public virtual ICollection<Project> Projects { get; private set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName; 
        }
    }
}
