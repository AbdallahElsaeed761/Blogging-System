using BloggingSystem.BL.Interfaces;
using BloggingSystem.BL.Repository;
using BloggingSystem.DAL;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext EC_DbContext { get; set; }
        public UnitOfWork()
        {
            EC_DbContext = new applicationDbContext();
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public ArticleRepostiry article; //=> throw new NotImplementedException();
        public ArticleRepostiry Article
        {
            get
            {
                if (article == null)
                    article = new ArticleRepostiry(EC_DbContext);
                return article;
            }
        }

       
        public CommentRepository comment;// => throw new NotImplementedException();
        public CommentRepository Comment
        {
            get
            {
                if (comment == null)
                    comment = new CommentRepository(EC_DbContext);
                return comment;
            }
        }

        public CategoryRepository category;//=> throw new NotImplementedException();
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }

        public AccountRepository account;// => throw new NotImplementedException();
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext);
                return account;
            }
        }

        public RoleRepository role;// => throw new NotImplementedException();
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }
        #region Common Properties



        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion
       
    }
}
