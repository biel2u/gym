using Gym.WebUI.Models.ViewModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gym.WebUI.Models
{
    [FluentValidation.Attributes.Validator(typeof(ExerciseValidator))]
    public class ExerciseViewModel
    {
        public int ExerciseID { get; set; }

        [ForeignKey("Training")]
        public int TrainingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int RestTime { get; set; }
    }
}