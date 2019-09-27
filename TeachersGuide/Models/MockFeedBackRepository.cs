using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockFeedBackRepository : IFeedBackRepository
    {
        private List<FeedBack> _feedBacks;
        public MockFeedBackRepository()
        {

        }
        public IEnumerable<FeedBack> GetAll()
        {
            return _feedBacks.ToList();
        }

        public void Submit(FeedBack feedBack)
        {
            _feedBacks.Add(feedBack);
        }
    }
}
