using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockUsersRepository : IUsersRepository
    {
        public MockUsersRepository()
        {

        }

        public bool verifyUser(Users user)
        {
            return true;
        }
    }
}
