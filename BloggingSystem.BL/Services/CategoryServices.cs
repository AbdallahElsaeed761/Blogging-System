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
    public class CategoryServices:Bases.BaseServices
    {
        
            public CategoryServices(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
            {

            }

            #region CURD

            public List<CategoryViewModel> GetAllCategory()
            {

                return Mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.Category.GetAllCategory());
            }
            public CategoryViewModel GetCategory(int id)
            {
                return Mapper.Map<CategoryViewModel>(TheUnitOfWork.Category.GetById(id));
            }



            public Category SaveNewCategory(CategoryViewModel categoryViewModel)
            {
                if (categoryViewModel == null)

                    throw new ArgumentNullException();

                bool result = false;
                var category = Mapper.Map<Category>(categoryViewModel);
                if (TheUnitOfWork.Category.Insert(category))
                {
                    result = TheUnitOfWork.Commit() > new int();
                }
                return category;
            }


            public bool UpdateCategory(CategoryViewModel categoryViewModel)
            {
                var category = Mapper.Map<Category>(categoryViewModel);
                TheUnitOfWork.Category.Update(category);
                TheUnitOfWork.Commit();

                return true;
            }


            public bool DeleteCategory(int id)
            {
                bool result = false;

                TheUnitOfWork.Category.Delete(id);
                result = TheUnitOfWork.Commit() > new int();

                return result;
            }

            public bool CheckCategoryExists(CategoryViewModel categoryViewModel)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);
                return TheUnitOfWork.Category.CheckCategoryExists(category);
            }
            #endregion


            //public int CountEntityForSpecficCategory(string deptmentName)
            //{
            //    return TheUnitOfWork.Article.CountEntityForSpeCifeCategory(deptmentName);
            //}

        }
    }

