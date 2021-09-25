using BloggingSystem.DAL.Models;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Repository
{
   public class CategoryRepository:Bases.BaseRepository<Category>
    {
        private  DbContext dbContext;

        public CategoryRepository(DbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        #region CRUB

        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public bool CheckCategoryExists(Category category)
        {
            return GetAny(l => l.Id == category.Id);
        }
        public Category GetOCategoryById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
       
    }
}
