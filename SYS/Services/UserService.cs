using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;


namespace SYS.Services
{
    public class UserService : BaseService
    {
        public UserService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<User> GetUser()
        {
            return repositoryWrapper.UserRepository.FindAll().ToList();
        }

        public List<User> GetUserByCondition(Expression<Func<User, bool>> expression)
        {
            return repositoryWrapper.UserRepository.FindByCondition(expression).ToList();
        }

        public void AddUser(User user)
        {
            repositoryWrapper.UserRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            repositoryWrapper.UserRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            repositoryWrapper.UserRepository.Delete(user);
        }
    }
}

