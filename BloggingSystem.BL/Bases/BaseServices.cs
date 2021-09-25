using AutoMapper;
using BloggingSystem.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.BL.Bases
{
  public  class BaseServices : IDisposable
    {

        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper; //MapperConfig.Mapper;

        #endregion

        #region CTR
        public BaseServices(IUnitOfWork theUnitOfWork, IMapper mapper)
        {
            TheUnitOfWork = theUnitOfWork;
            Mapper = mapper;
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
