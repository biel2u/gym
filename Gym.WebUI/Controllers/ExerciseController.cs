using AutoMapper;
using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using Gym.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.WebUI.Controllers
{
    [Authorize]
    [RequireHttps]
    public class ExerciseController : Controller
    {
        public IExerciseRepository _exercise;

        public ExerciseController (IExerciseRepository exercise)
        {
            _exercise = exercise;
        }
        public ViewResult Show(int trainingID)
        {
            Session["ID"] = trainingID;
            return View(_exercise.Exercises.ToList().Where(m => m.TrainingID == trainingID));
        }
        public ViewResult Create()
        {
            ExerciseViewModel exerciseVM = new ExerciseViewModel();
            if((int?)Session["ID"] == null)
            {
                throw new HttpException(404, "Exercise not found.");
            }
            exerciseVM.TrainingID = (int)Session["ID"];
            return View("Create", exerciseVM);
        }

        public ViewResult Edit(int exerciseID)
        {
            Exercise exercise = _exercise.Exercises.FirstOrDefault(m => m.ExerciseID == exerciseID);
            ExerciseViewModel exerciseVM = Mapper.Map<Exercise, ExerciseViewModel>(exercise);
            return View("Create", exerciseVM);
        }

        [HttpPost]
        public ActionResult Save(ExerciseViewModel exerciseVM)
        {
            if (ModelState.IsValid)
            {
                Exercise exercise = Mapper.Map<ExerciseViewModel, Exercise>(exerciseVM);
                _exercise.SaveExercise(exercise);
                TempData["message"] = string.Format("Exercise {0} saved", exerciseVM.Name);
                return RedirectToAction("Show", new { trainingID = exercise.TrainingID });
            }
            else
            {
                return View("Create", exerciseVM);
            }
        }

        [HttpPost]
        public ActionResult Delete(int exerciseID)
        {
            Exercise deleteExercise = _exercise.DeleteExercise(exerciseID);
            if (deleteExercise != null)
            {
                TempData["message"] = string.Format("Deleted {0}", deleteExercise.Name);
            }
            return RedirectToAction("Show", new { trainingID = (int)Session["ID"] });
        }
    }
}