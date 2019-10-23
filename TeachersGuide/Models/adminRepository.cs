using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class adminRepository:IAdminRepository
    {
        private readonly AppDbContext _appDbContext;
        public adminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool verifyUser(Users user)
        {
            //Users FindThisUser = _appDbContext.Users.FirstOrDefault(d => d.Username == user.Username && d.Password == user.Password);
            
            //if( FindThisUser not null)
            if (user.Username == "admin" && user.Password == "admin")
                return true;
            else
                return false;
        }

    }
}
