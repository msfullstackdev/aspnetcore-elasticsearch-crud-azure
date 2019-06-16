using CS.DomainEntity.Contracts.IInfrastructre;
using CS.DomainEntity.Contracts.IRepository;
using CS.DomainEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Infrastructure
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> _userRepo = null;
        public UserServices(IGenericRepository<User> repository)
        {
            _userRepo = repository;
        }

        public void AddorUpdate(User user)
        {
            _userRepo.AddOrUpdate(user.Id, user);
        }


        public IEnumerable<User> GetAll()
        {
            var res = _userRepo.GetAll();

            return res;
        }

        public User GetById(string id)
        {
            var res = _userRepo.GetById(id);

            return res;
        }


        public void Delete(string id)
        {
            _userRepo.Delete(id);
        }
    }
}
