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
   public class CommentServices: Bases.BaseServices
    {
        public CommentServices(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
    {

    }

    #region CURD

    public List<CommentViewModel> GetAllComment()
    {

        return Mapper.Map<List<CommentViewModel>>(TheUnitOfWork.Comment.GetAllComment());
    }
    public CommentViewModel GetComment(int id)
    {
        return Mapper.Map<CommentViewModel>(TheUnitOfWork.Comment.GetById(id));
    }



    public Comment SaveNewComment(CommentViewModel commentViewModel)
    {
        if (commentViewModel == null)

            throw new ArgumentNullException();

        bool result = false;
        var comment = Mapper.Map<Comment>(commentViewModel);
        if (TheUnitOfWork.Comment.Insert(comment))
        {
            result = TheUnitOfWork.Commit() > new int();
        }
        return comment;
    }


    public bool UpdateComment(CommentViewModel commentViewModel)
    {
        var comment = Mapper.Map<Comment>(commentViewModel);
        TheUnitOfWork.Comment.Update(comment);
        TheUnitOfWork.Commit();

        return true;
    }


    public bool DeleteComment(int id)
    {
        bool result = false;

        TheUnitOfWork.Comment.Delete(id);
        result = TheUnitOfWork.Commit() > new int();

        return result;
    }

    public bool CheckCommentExists(CommentViewModel commentViewModel)
    {
        Comment comment = Mapper.Map<Comment>(commentViewModel);
        return TheUnitOfWork.Comment.CheckCommenteExists(comment);
    }
    #endregion


    //public int CountEntityForSpecficCategory(string deptmentName)
    //{
    //    return TheUnitOfWork.Article.CountEntityForSpeCifeCategory(deptmentName);
    //}
   
}
}
