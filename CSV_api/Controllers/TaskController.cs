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

        [Route("{id}")]
        [HttpGet]
        public JsonResult GetAll(int id) 
        {
            return new JsonResult(_taskService.GetAll(id));
        }

        [Route("byCode/{id}")]
        [HttpGet]
        public JsonResult GetAllByCode(byte StatusCode)
        {
            return new JsonResult(_taskService.GetTasksByCode(StatusCode));
        }

       // [HttpPost]
       // public JsonResult Create(Models.Task task)
       // {
       //     _taskService.Create(task);
       //     return new JsonResult("OK");
       // }



        [HttpPost]
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
