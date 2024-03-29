﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public interface IInterventionsModifiedRepository
    {
        IEnumerable<InterventionsModified> GetAll();
        IEnumerable<InterventionsModified> GetCategory(long Id);
        bool addNewIntervention(InterventionsModified newIntervention);
        InterventionsModified getId(long id);
        bool delete(long id);
        bool edit(InterventionsModified interventionsModified);
    }
}
