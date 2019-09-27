using Microsoft.EntityFrameworkCore;
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

        public bool addNewItem(BehaviorPageTow behaviorPageTow)
        {
            _appDbContext.BehaviorPageTow.Add(behaviorPageTow);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool delete(long Id)
        {
            
            BehaviorPageTow bPT = _appDbContext.BehaviorPageTow.FirstOrDefault(d => d.Id == Id);
            IEnumerable<InterventionsModified> iM = _appDbContext.InterventionsModified.Where(d => d.BPTid == bPT.Id).ToList();
                foreach (var item1 in iM)
                {
                    _appDbContext.InterventionsModified.Remove(item1);
                    _appDbContext.SaveChanges();
                }
                _appDbContext.BehaviorPageTow.Remove(bPT);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(long id)
        {
            _appDbContext.BehaviorPageTow.First(d => d.Id == id).Count++;
            _appDbContext.SaveChanges();
            return true;
        }

        public bool EditBPT(BehaviorPageTow bPT)
        {
            _appDbContext.Entry(bPT).State = EntityState.Modified;
            try
            {
                _appDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<BehaviorPageTow> GetAllBehaviorPageTows()
        {
            return _appDbContext.BehaviorPageTow.ToList();
        }

        public IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id)
        {
            return _appDbContext.BehaviorPageTow.Where(d=>d.BPOId==Id);
        }

        public BehaviorPageTow GetById(long Id)
        {
            return _appDbContext.BehaviorPageTow.FirstOrDefault(d => d.Id == Id);
        }
    }
}
