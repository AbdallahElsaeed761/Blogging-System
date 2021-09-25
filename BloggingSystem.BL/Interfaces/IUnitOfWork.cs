using BloggingSystem.BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Method
        int Commit();
        #endregion

        ArticleRepostiry Article { get; }
        CommentRepository Comment { get; }
        CategoryRepository Category { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }



    }
}
