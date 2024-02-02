﻿using CSV_api.Models;
using CSV_api.Services.Implementations;
using CSV_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSV_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public JsonResult Get(int id) 
        {
            return new JsonResult(_commentService.GetAll(id));
        }

        [HttpPut]
        public JsonResult Update(CommentDto comment)
        {
            bool success = true;
            var updateComment = _commentService.GetById(comment.CommentId);
            try
            {
                if (comment != null)
                {
                    updateComment = _commentService.Update(comment);
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

            return success ? new JsonResult($"Update successful {comment.CommentId}") : new JsonResult("Update was not successful");
        }

    }
}
