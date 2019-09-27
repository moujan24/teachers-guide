using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedBackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<FeedBack> GetAll()
        {
            return _appDbContext.FeedBack;
        }

        public void Submit(FeedBack feedBack)
        {
            _appDbContext.FeedBack.Add(feedBack);
            _appDbContext.SaveChanges();
        }
    }
}
