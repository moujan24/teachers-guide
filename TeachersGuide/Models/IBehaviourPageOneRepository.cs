﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public interface IBehaviourPageOneRepository
    {
        IEnumerable<BehaviourPageOne> GetAll();
    }
}
