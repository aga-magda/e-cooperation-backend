using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecooperation_backend.Entities;
using Ecooperation_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecooperation_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IAuthorizationService _authorizationService;

        public ProjectsController
        (
            IProjectService projectService,
            IAuthorizationService authorizationService)
        {
            _projectService = projectService;
            _authorizationService = authorizationService;
        }

        // GET: /projects
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAll()
        {
            return await _projectService.GetAll();
        }

        // GET: /projects/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetById(long id)
        {
            try
            {
                var project = await _projectService.GetById(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: /projects
        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project project)
        {
            try
            {
                await _projectService.Create(project);
                return CreatedAtAction(nameof(GetById), new { project.Id }, project);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: /projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Project project)
        {
            if (id != project.Id)
                return BadRequest();

            var projectDb = await _projectService.GetById(project.Id);
            if (projectDb.Creator == null)
                return new ForbidResult();

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, projectDb.Creator, "SameAuthorPolicy");

            if (authorizationResult.Succeeded)
            {
                try
                {
                    await _projectService.Update(project);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }

        // DELETE: /projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var projectDb = await _projectService.GetById(id);
            if (projectDb.Creator == null)
                return new ForbidResult();

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, projectDb.Creator, "SameAuthorPolicy");

            if (authorizationResult.Succeeded)
            {
                await _projectService.Delete(id);
                return Ok();
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}