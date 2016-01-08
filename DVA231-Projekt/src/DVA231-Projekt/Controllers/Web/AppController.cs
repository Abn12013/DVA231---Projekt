using DVA231_Projekt.Services;
using DVA231_Projekt.ViewModels;
using Microsoft.AspNet.Mvc;
using System;

namespace DVA231_Projekt.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService service)
        {
            _mailService = service;
        }

        //The request is called Index. No id parameter in here yet -> app/index/id
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if(string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem");
                }

                if(_mailService.SendMail(email, email,
                    $"Contact Page from {model.Name} ({model.Email})", model.Message))
                {
                    ModelState.Clear();
                }

                ViewBag.Message = "Mail Sent. Thanks!";

            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
