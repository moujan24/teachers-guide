using Microsoft.EntityFrameworkCore;
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

        public bool addNewItem(BehaviourPageOne behaviourPageOne)
        {
            _appDbContext.BehaviourPageOne.Add(behaviourPageOne);
            try
            {
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool delete(long Id)
        {
            BehaviourPageOne bPO = _appDbContext.BehaviourPageOne.First(d => d.Id == Id);
            IEnumerable<BehaviorPageTow> bPT = _appDbContext.BehaviorPageTow.Where(d => d.BPOId == bPO.Id).ToList();
            foreach(var item in bPT)
            {
                IEnumerable<InterventionsModified> iM = _appDbContext.InterventionsModified.Where(d => d.BPTid == item.Id).ToList();
                foreach (var item1 in iM)
                {
                    _appDbContext.InterventionsModified.Remove(item1);
                    _appDbContext.SaveChanges();
                }
                _appDbContext.BehaviorPageTow.Remove(item);
                _appDbContext.SaveChanges();
            }
            _appDbContext.BehaviourPageOne.Remove(bPO);
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

        public bool edit(BehaviourPageOne behaviourPageOne)
        {
            _appDbContext.Entry(behaviourPageOne).State = EntityState.Modified;
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

        public IEnumerable<BehaviourPageOne> GetAll()
        {
            return _appDbContext.BehaviourPageOne;
        }

        public BehaviourPageOne GetById(long Id)
        {
            return _appDbContext.BehaviourPageOne.FirstOrDefault(d=>d.Id==Id);
        }
    }
}
