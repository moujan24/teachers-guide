using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class UsersRepository:IUsersRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool verifyUser(Users user)
        {
            IEnumerable<Users> dbent= _appDbContext.Users.Where(d => d.Username == "Admin");
            
            return true;
        }
        //public bool addNewItem(BehaviorPageTow behaviorPageTow)
        //{
        //    _appDbContext.BehaviorPageTow.Add(behaviorPageTow);
        //    _appDbContext.SaveChanges();
        //    return true;
        //}

   
        //public IEnumerable<BehaviorPageTow> GetAllBehaviorPageTows()
        //{
        //    return _appDbContext.BehaviorPageTow.ToList();
        //}

        //public IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id)
        //{
        //    return _appDbContext.BehaviorPageTow.Where(d=>d.BPOId==Id);
        //}

    }
}
