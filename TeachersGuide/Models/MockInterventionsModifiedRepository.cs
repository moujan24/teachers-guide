using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockInterventionsModifiedRepository : IInterventionsModifiedRepository
    {
        private List<InterventionsModified> _interventionsModified;
        public MockInterventionsModifiedRepository()
        {

        }
        public IEnumerable<InterventionsModified> GetAll()
        {
            return _interventionsModified.ToList();
        }
    }
}
