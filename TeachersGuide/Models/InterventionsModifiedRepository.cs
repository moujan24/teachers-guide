using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class InterventionsModifiedRepository:IInterventionsModifiedRepository
    {
        private readonly AppDbContext _appDbContext;
        public InterventionsModifiedRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<InterventionsModified> GetAll()
        {
            return _appDbContext.InterventionsModified;
        }
    }
}
