using DVA231_Projekt.Models;
using DVA231_Projekt.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DVA231_Projekt.Controllers.Api
{
    [Route("api/textposts")]
    public class TextpostController : Controller
    {
        private IProjectRepository _repository;

        public TextpostController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAllTextPosts();

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody] TextpostViewModel newTextpost)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.Created;
                return Json(true);
            }
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json("Failed");
        }
    }
}
