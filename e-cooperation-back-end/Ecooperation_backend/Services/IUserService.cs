using System.Collections.Generic;
using System.Threading.Tasks;
using Ecooperation_backend.Entities;

namespace Ecooperation_backend.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task Create(User user, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(long id);
        Task Update(User user, string password);
        Task Delete(long id);
    }
}