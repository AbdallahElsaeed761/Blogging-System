using BloggingSystem.BL.Bases;
using BloggingSystem.DAL.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Repository
{
   public class ArticleRepostiry:BaseRepository<Article>
    {
        private  DbContext dbContext;
         public ArticleRepostiry(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

       
        #region CRUB

        public List<Article> GetAllArticle()
        {
            return GetAll().ToList();
        }

        public bool InsertArticle(Article article)
        {
            return Insert(article);
        }
        public void UpdateArticle(Article article)
        {
            Update(article);
        }
        public void DeleteArticle(int id)
        {
            Delete(id);
        }

        public bool CheckArticleExists(Article article)
        {
            return GetAny(l => l.Id == article.Id);
        }
        public Article GetOArticleById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
       
    }
}
