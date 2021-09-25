using BloggingSystem.BL.StaticClass;
using BloggingSystem.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Repository
{
   public class RoleRepository : Bases.BaseRepository<IdentityRole>
    {
        ApplicationRoleManager manager;
        public RoleRepository(DbContext dbcontext) : base(dbcontext)

        {
            manager = new ApplicationRoleManager();
        }
        public IdentityRole GetRoleByID(string id)
        {
            return GetFirstOrDefault(r => r.Id == id);
        }
        public async Task CreateRoles()
        {

            if (!await manager.RoleExistsAsync(UserRoles.Admin))
                await manager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await manager.RoleExistsAsync(UserRoles.Moderator))
                await manager.CreateAsync(new IdentityRole(UserRoles.Moderator));
            if (!await manager.RoleExistsAsync(UserRoles.Visitor))
                await manager.CreateAsync(new IdentityRole(UserRoles.Visitor));
            

        }

        public IdentityResult Create(string role)
        {

            return manager.CreateAsync(new IdentityRole(role)).Result;

        }
        public IdentityResult UpdateRole(IdentityRole role)
        {
            var identityRole = manager.FindById(role.Id);
            identityRole.Name = role.Name;
            return manager.Update(identityRole);
        }
        public void DeleteRole(string id)
        {
            var identityRole = manager.FindById(id);

            manager.Delete(identityRole);
        }
        public List<IdentityRole> getAllRoles()
        {
            return GetAll().Include(r => r.Users).ToList();
        }
    }
    
}
