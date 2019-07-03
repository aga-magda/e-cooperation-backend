using Ecooperation_backend.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecooperation_backend.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(long id);
        Task<Project> Create(Project project);
        Task<Project> Update(Project project);
        Task<Project> Delete(long id);
    }
}
