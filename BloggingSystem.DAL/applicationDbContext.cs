
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using BloggingSystem.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.DAL
{
    public class applicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public virtual List<Article> Articles { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
    public class ApplicationUserStore : UserStore<applicationUser>
    {

        public ApplicationUserStore() : base(new applicationDbContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    public class ApplicationUserManager : UserManager<applicationUser>
    {
        public ApplicationUserManager(Microsoft.EntityFrameworkCore.DbContext db) : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager() :
            base(new RoleStore<IdentityRole>(new applicationDbContext()))
        {

        }
        public ApplicationRoleManager(DbContext db) :
            base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class applicationDbContext:IdentityDbContext<applicationUser>
    {
        //public applicationDbContext(DbContextOptions<applicationDbContext> options):base (options)
        //{

        //}
        //public applicationDbContext()
        //{

        //}
        public applicationDbContext() :
         // base("Data Source =DESKTOP-GF4P384\\ABDALLAHSQL; Initial Catalog = BloggingSystem; Integrated Security = True")
         base("name=CS")
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-GF4P384\\ABDALLAHSQL;Initial Catalog=BloggingSystem;Integrated Security=True"
        //        , options => options.EnableRetryOnFailure());

        //}
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        //public virtual DbSet<ApplicationUserIdentity> ApplicationUserIdentities { get; set; }

    }
}
