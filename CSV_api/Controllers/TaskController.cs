using CSV_api.Models;
using CSV_api.Services.Implementations;
using CSV_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSV_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Route("/{Projectid}")]
        [HttpGet]
        public JsonResult GetAll(int Projectid)
        {
            return new JsonResult(_taskService.GetAll(Projectid));
        }

        [Route("/ByCode/{StatusCode}")]
        [HttpGet]
        public JsonResult GetAllByCode(byte StatusCode)
        {
            return new JsonResult(_taskService.GetTasksByCode(StatusCode));
        }

        [Route("/ById/{id}")]
        [HttpGet]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_taskService.GetOneTasksById(id));
        }

        [Route("/Create")]
        [HttpPost]
        public JsonResult Create(Models.Task task)
        {
            _taskService.Create(task);
            return new JsonResult("OK");
        }

        [HttpPost]
        [Route("/Update")]
        public JsonResult Update([FromBody] TaskDto task)
        {
            bool success = true;
            var updateUser = _taskService.GetOneTasksById(task.TaskId);
            try
            {
                if (task != null)
                {
                    updateUser = _taskService.Update(task);
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

            return new JsonResult(System.Text.Json.JsonSerializer.Serialize(task));
        }

        [HttpDelete]
        [Route("/Delete")]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var user = _taskService.GetOneTasksById(id);

            try
            {
                if (user != null)
                {
                    _taskService.Delete(id);
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

    }
}
