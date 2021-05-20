using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Repositories;

namespace SYS.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper repositoryWrapper;

        public BaseService(IRepositoryWrapper iRepositoryWrapper)
        {
            repositoryWrapper = iRepositoryWrapper;
        }

        public void Save()
        {
            repositoryWrapper.Save();
        }
    }
}
