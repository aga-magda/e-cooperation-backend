using Ecooperation_backend.Entities;
using Ecooperation_backend.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecooperation_backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects
                .Include(c => c.Creator)
                .Include(t => t.Tags)
                .Include(p => p.Participants)
                .ToListAsync();
        }

        public async Task<Project> GetById(long id)
        {
            var project = await _context.Projects
                .Include(c => c.Creator)
                .Include(t => t.Tags)
                .Include(p => p.Participants)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (project == null)
                throw new ArgumentNullException("Nie znaleziono projektu o podanym ID");

            _context.Entry(project).State = EntityState.Detached;
            return project;
        }

        public async Task<Project> Create(Project project)
        {
            var creatorId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            User creator = await _context.Users.SingleOrDefaultAsync(user => user.Id.ToString() == creatorId);

            project.Creator = creator;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Delete(long id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                throw new ArgumentNullException();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }
    }
}