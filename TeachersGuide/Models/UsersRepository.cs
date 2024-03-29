﻿using Microsoft.EntityFrameworkCore;
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
            if (_appDbContext.admin.FirstOrDefault(d => d.username == user.Username && d.password == user.Password) != null)
                return true;
            else
                return false;
        }

    }
}
