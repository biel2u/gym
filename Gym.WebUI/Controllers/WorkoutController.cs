using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using Gym.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace Gym.WebUI.Controllers
{
    [Authorize]
    [RequireHttps]
    public class WorkoutController : Controller
    {
        private ITrainingRepository _training;
        public int PageSize = 6;

        public WorkoutController(ITrainingRepository training)
        {
            _training = training;
        }

        public ViewResult Index(int page = 1)
        {
            WorkoutListViewModel model = new WorkoutListViewModel
            {
                Trainings = _training.Trainings.Where(m => m.UserID == User.Identity.GetUserId())
                .OrderBy(m => m.TrainingID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _training.Trainings.Count()
                }
            };
            return View(model);            
        }
           
        public ViewResult Create()
        {
            return View("Create", new TrainingViewModel());
        }

        public ViewResult Edit(int trainingID)
        {
            Training training = _training.Trainings.FirstOrDefault(m => m.TrainingID == trainingID);
            TrainingViewModel trainingVM = Mapper.Map<Training, TrainingViewModel>(training);
            return View("Create", trainingVM);
        }

        [HttpPost]
        public ActionResult Save(TrainingViewModel trainingVM)
        {
            if (ModelState.IsValid)
            {
                Training training = Mapper.Map<TrainingViewModel, Training>(trainingVM);
                _training.SaveWorkout(training);
                TempData["message"] = string.Format("Workout {0} saved", trainingVM.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", trainingVM);
            }
        }

        [HttpPost]
        public ActionResult Delete(int trainingID)
        {
            Training deleteTraining = _training.DeleteWorkout(trainingID);
            if(deleteTraining != null)
            {
                TempData["message"] = string.Format("Deleted {0}", deleteTraining.Name);
            }
            return RedirectToAction("Index");
        }
    }
}