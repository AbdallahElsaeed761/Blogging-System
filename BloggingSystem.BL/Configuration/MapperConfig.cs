using AutoMapper;
using BloggingSystem.BL.Dtos;
using BloggingSystem.DAL;
using BloggingSystem.DAL.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;

namespace BloggingSystem.BL.Configuration
{
   public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Article, ArticleViewModel>()
             //.ForMember(vm => vm.DepartmentId, m => m.MapFrom(u => u.Department.DepartmentId))
             .ForMember(vm => vm.CategoryName, m => m.MapFrom(u => u.Category.Name)).ReverseMap()
             .ForMember(m => m.Category, m => m.Ignore());

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<applicationUser, LoginViewModel>().ReverseMap();
            CreateMap<applicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<IdentityUserRole, RoleViewModel>().ReverseMap();

        }
    }
}
