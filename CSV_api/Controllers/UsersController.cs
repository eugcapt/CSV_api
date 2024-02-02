using CSV_api.Models;
using CSV_api.Services.Implementations;
using CSV_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace CSV_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_userService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_userService.GetById(id));
        }

        [HttpGet]
        [Route("GetProjectUsers/{id}")]
        public JsonResult GetUsers(int id)
        {
            return new JsonResult(_userService.GetProjectUsers(id));
        }

        [HttpGet]
        [Route("GetUserDescription/{id}")]
        public JsonResult GetUserDescription(int id)
        {
            return new JsonResult(_userService.GetUserDescription(id));
        }

        [HttpPut]
        public JsonResult Update(User user)
        {
            bool success = true;
            var updateUser = _userService.GetById(user.UserId);
            try
            {
                if (user != null)
                {
                    updateUser = _userService.Update(user);
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

            return success ? new JsonResult($"Update successful {updateUser.UserId}") : new JsonResult("Update was not successful");
        }


        [HttpPost]
        public JsonResult Create(User user)
        {
            _userService.Create(user);
            return new JsonResult("OK");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var user = _userService.GetById(id);

            try
            {
                if (user != null)
                {
                    _userService.Delete(id);
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
