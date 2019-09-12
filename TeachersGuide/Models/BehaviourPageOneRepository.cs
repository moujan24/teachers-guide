using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class BehaviourPageOneRepository : IBehaviourPageOneRepository
    {
        private readonly AppDbContext _appDbContext;
        public BehaviourPageOneRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<BehaviourPageOne> GetAll()
        {
            return _appDbContext.BehaviourPageOne;
        }
    }
}
