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
   public class CommentRepository:Bases.BaseRepository<Comment>
    {
        private  DbContext dbContext;

        public CommentRepository(DbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        #region CRUB

        public List<Comment> GetAllComment()
        {
            return GetAll().ToList();
        }

        public bool InsertComment(Comment comment)
        {
            return Insert(comment);
        }
        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
        public void DeleteComment(int id)
        {
            Delete(id);
        }

        public bool CheckCommenteExists(Comment comment)
        {
            return GetAny(l => l.Id == comment.Id);
        }
        public Comment GetOCommentById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
