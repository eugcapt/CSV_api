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
        [Route("/Project")]
        public JsonResult Get()
        {
            return new JsonResult(_projectService.GetAll());
        }

        [HttpGet]
        [Route("/Project/Description/{id}")]
        public JsonResult GetDescription(int id)
        {
            return new JsonResult(_projectService.GetProjectDescription(id));
        }

        [HttpGet]
        [Route("/Project/Users/{id}")]
        public JsonResult GetAllUsers(int id)
        {
            return new JsonResult(_projectService.GetAllUsers(id));
        }

        [HttpPost]
        [Route("/Project/Create")]
        public JsonResult Create(Project project)
        {
            _projectService.Create(project);
            return new JsonResult("OK");
        }

        [HttpDelete]
        [Route("/Project/Delete")]
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
        [Route("/Project/Update/Description")]
        public JsonResult UpdateDescription(int id, string description, ProjectDescriptionDto project)
        {
            return new JsonResult(_projectService.UpdateProjectDescription(id, description, project));
        }

        [HttpPost]
        [Route("/Project/Update/Users/{userId},{projectId}")]
        public JsonResult AddUserToProject(int userId, int projectId)
        {
            return new JsonResult(_projectService.AddUserToProject(userId, projectId));
        }
    }
}
