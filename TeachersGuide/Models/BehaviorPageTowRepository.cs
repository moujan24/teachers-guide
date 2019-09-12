using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class BehaviorPageTowRepository:IBehaviorPageTowRepository
    {
        private readonly AppDbContext _appDbContext;
        public BehaviorPageTowRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id)
        {
            return _appDbContext.BehaviorPageTow.Where(d=>d.BPOId==Id);
        }
    }
}
