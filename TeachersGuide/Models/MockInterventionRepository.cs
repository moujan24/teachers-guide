using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockInterventionRepository : IInterventionsRepository
    {
        private List<Interventions> _interventions;
        public MockInterventionRepository()
        {

        }
        public IEnumerable<Interventions> GetInterventions(int Id)
        {
            return _interventions.ToList();
        }
    }
}
