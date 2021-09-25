

using BloggingSystem.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Repository
{
   public class AccountRepository:Bases.BaseRepository<applicationUser>
    {
        private readonly UserManager<applicationUser> manager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(db);
        }
        public AccountRepository(DbContext db, UserManager<applicationUser> manager, RoleManager<IdentityRole> roleManager) : base(db)
        {
            //manager = new ApplicationUserManager(db);
            this.manager = manager;
            this.roleManager = roleManager;

        }

        public applicationUser GetAccountById(string id)
        {
            return GetFirstOrDefault(a => a.Id == id);
        }
        public List<applicationUser> GetAllAccounts()
        {
            return GetAll().ToList();
        }
        public applicationUser FindById(string id)
        {
            applicationUser result = manager.FindById(id);
            return result;
        }
        public applicationUser FindByName(string userName)
        {
            applicationUser result = manager.FindByName(userName);
            return result;
        }

        public applicationUser Find(string username, string password)
        {
            applicationUser result = manager.Find(username, password);
            return result;
        }
        //public async Task<IEnumerable<string>> GetUserRoles(applicationUser user)
        //{
        //    var userRoles = await manager.GetRolesAsync(user);
        //    return userRoles;
        //}
        public IdentityResult Register(applicationUser user)
        {
            user.Id = Guid.NewGuid().ToString();
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;

        }

        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;

        }

        public bool updatePassword(applicationUser user)
        {
            user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            IdentityResult result = manager.Update(user);
            return true;
        }

        public bool UpdateAccount(applicationUser user)
        {
            IdentityResult result = manager.Update(user);
            return true;
        }
    }
}
