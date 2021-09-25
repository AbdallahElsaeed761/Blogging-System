using AutoMapper;
using BloggingSystem.BL.Dtos;
using BloggingSystem.BL.Interfaces;
using BloggingSystem.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Services
{
    public class RoleServices:Bases.BaseServices
    {
        public RoleServices(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public async Task CreateRoles()
        {
            await TheUnitOfWork.Role.CreateRoles();
        }
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }

        public RoleViewModel GetRoleById(string id)
        {
            if (id == null || id == "")
                throw new ArgumentNullException();
            return Mapper.Map<RoleViewModel>(TheUnitOfWork.Role.GetRoleByID(id));
        }

        public IdentityResult Update(RoleViewModel roleViewModel)
        {
            if (roleViewModel == null)
                throw new ArgumentNullException();

            var role = Mapper.Map<IdentityRole>(roleViewModel);
            return TheUnitOfWork.Role.UpdateRole(role);
        }
        public bool DeleteRole(string id)
        {
            if (id == null || id == "")
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Role.DeleteRole(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public List<RoleViewModel> GetAllRoles()
        {
            return Mapper.Map<List<RoleViewModel>>(TheUnitOfWork.Role.getAllRoles());
        }
        //public List<RegisterViewModel> getAllUsers(string id)
        //{
        //    List<applicationUser> users = new List<applicationUser>();
        //    var role = TheUnitOfWork.Role.getAllRoles().FirstOrDefault(r => r.Id == id);
        //    foreach (var userRole in role.Users)
        //    {
        //        var user = TheUnitOfWork.Account.GetAccountById(userRole.UserId);
        //        if (user.Adminlocked == "false")
        //            users.Add(user);
        //    }
        //    return Mapper.Map<List<RegisterViewModel>>(users);
        //}
    }
}
