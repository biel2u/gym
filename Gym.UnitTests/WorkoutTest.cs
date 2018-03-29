using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using Gym.WebUI.Controllers;
using Gym.WebUI.App_Start;
using Gym.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gym.UnitTests
{
    [TestClass]
    public class WorkoutTest
    {
        [ClassInitialize]
        public static void Init(TestContext test)
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());
        }

        [TestMethod]
        public void Can_Delete_Selected_Workout()
        {
            // Arrange
            Training training = new Training { TrainingID = 2, Name = "Test" };
            Mock<ITrainingRepository> mock = new Mock<ITrainingRepository>();
            mock.Setup(m => m.Trainings).Returns(new Training[]
            {
                new Training {TrainingID = 1, Name = "First"},
                training,
                new Training {TrainingID = 3, Name = "Third"},
            });
            WorkoutController target = new WorkoutController(mock.Object);
            // Act
            target.Delete(training.TrainingID);
            // Assert
            mock.Verify(m => m.DeleteWorkout(training.TrainingID));
        }

        [TestMethod]
        public void Edit_Nonexistent_Workout_Return_Null()
        {
            // Arrange
            Mock<ITrainingRepository> mock = new Mock<ITrainingRepository>();
            mock.Setup(m => m.Trainings).Returns(new Training[]
            {
                new Training {TrainingID = 1, Name = "First"},
                new Training {TrainingID = 3, Name = "Third"},
            });
            WorkoutController target = new WorkoutController(mock.Object);
            // Act
            Training result = (Training)target.Edit(2).ViewData.Model;
            // Assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void Cannot_Save_Invalid_ModelState_Workout()
        {
            // Arrange
            Mock<ITrainingRepository> mock = new Mock<ITrainingRepository>();
            WorkoutController target = new WorkoutController(mock.Object);
            TrainingViewModel training = new TrainingViewModel { Name = "Test" };
            target.ModelState.AddModelError("error", "error");
            // Act
            ActionResult result = target.Save(training);
            // Assert
            mock.Verify(m => m.SaveWorkout(It.IsAny<Training>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
