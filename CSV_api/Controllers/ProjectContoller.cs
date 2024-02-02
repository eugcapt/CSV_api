using CSV_api.Models;
using CSV_api.Services.Implementations;
using CSV_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSV_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_projectService.GetAll());
        }

        [HttpGet]
        [Route("description/{id}")]
        public JsonResult GetDescription(int id)
        {
            return new JsonResult(_projectService.GetProjectDescription(id));
        }

        [HttpGet]
        [Route("users/{id}")]
        public JsonResult GetAllUsers(int id)
        {
            return new JsonResult(_projectService.GetAllUsers(id));
        }

        [HttpPost]
        public JsonResult Create(Project project)
        {
            _projectService.Create(project);
            return new JsonResult("OK");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var user = _projectService.GetById(id);

            try
            {
                if (user != null)
                {
                    _projectService.Delete(id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }

        [HttpPost]
        [Route("description")]
        public JsonResult UpdateDescription(int id, string description, ProjectDescriptionDto project)
        {
            return new JsonResult(_projectService.UpdateProjectDescription(id, description, project));
        }

        [HttpPost]
        [Route("users")]
        public JsonResult AddUserToProject(int userId, int projectId, UserUpdateProjectDto user)
        {
            return new JsonResult(_projectService.AddUserToProject(userId, projectId, user));
        }
    }
}
