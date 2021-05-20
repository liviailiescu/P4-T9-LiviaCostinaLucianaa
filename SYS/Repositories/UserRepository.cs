using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Models;

namespace SYS.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(contextclass contextClass)
            : base(contextClass)
        {
        }
    
    }
}
