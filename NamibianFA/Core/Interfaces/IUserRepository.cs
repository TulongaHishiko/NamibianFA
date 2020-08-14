using CenoredIMS.Domain.Abstract;
using CenoredIMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenoredIMS.Core.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Get();
        User GetByEmail(string email);
        Task<IdentityResult> Create(User user, string password, UserRoleEnum role);
        Task<IdentityResult> Delete(User user);
        Task<IdentityResult> Update(User user);
        UserManager<User> GetUserManager();
    }
}
