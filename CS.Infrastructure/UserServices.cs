using CS.DomainEntity.Contracts.IInfrastructre;
using CS.DomainEntity.Contracts.IRepository;
using CS.DomainEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Infrastructure
{
    public class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> _userRepo = null;
        public UserServices(IGenericRepository<User> repository)
        {
            _userRepo = repository;
        }

        public async Task AddorUpdateAsync(User user)
        {
            if (string.IsNullOrEmpty( user.Id))
            user.Id = Guid.NewGuid().ToString("D");

          await  _userRepo.AddOrUpdateAsync(user.Id, user);
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var res =await _userRepo.GetAllAsync();

            return res;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var res =await _userRepo.GetByIdAsync(id);

            return res;
        }


        public async Task DeleteAsync(string id)
        {
            await _userRepo.DeleteAsync(id);
        }
    }
}
