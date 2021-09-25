using AutoMapper;
using BloggingSystem.BL.Dtos;
using BloggingSystem.BL.Interfaces;
using BloggingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Services
{
   public class ArticleServices : Bases.BaseServices
    {
        public ArticleServices(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }

        #region CURD

        public List<ArticleViewModel> GetAllArticle()
        {

            return Mapper.Map<List<ArticleViewModel>>(TheUnitOfWork.Article.GetAllArticle());
        }
        public ArticleViewModel GetArticle(int id)
        {
            return Mapper.Map<ArticleViewModel>(TheUnitOfWork.Article.GetById(id));
        }



        public Article SaveNewArticle(ArticleViewModel articleViewModel)
        {
            if (articleViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var article = Mapper.Map<Article>(articleViewModel);
            if (TheUnitOfWork.Article.Insert(article))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return article;
        }


        public bool UpdateArticle(ArticleViewModel articleViewModel)
        {
            var article = Mapper.Map<Article>(articleViewModel);
            TheUnitOfWork.Article.Update(article);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteArticle(int id)
        {
            bool result = false;

            TheUnitOfWork.Article.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckArticleExists(ArticleViewModel articleViewModel)
        {
            Article article = Mapper.Map<Article>(articleViewModel);
            return TheUnitOfWork.Article.CheckArticleExists(article);
        }
        #endregion


        //public int CountEntityForSpecficCategory(string deptmentName)
        //{
        //    return TheUnitOfWork.Article.CountEntityForSpeCifeCategory(deptmentName);
        //}
        public List<ArticleViewModel> GetArticleForSpecficCategory(string CategoryName)
        {
            if (CategoryName == null || CategoryName == "")
                throw new ArgumentNullException();

            return GetAllArticle().Where(p => p.CategoryName == CategoryName).ToList();
        }
    }
}
