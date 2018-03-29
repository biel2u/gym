using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.WebUI.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        private ITrainingRepository _training;

        public HomeController(ITrainingRepository training)
        {
            _training = training;
        }
   
        public ActionResult Index()
        {
            return View();
        }
    }
}