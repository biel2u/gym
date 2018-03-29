using Gym.Domain.Entities;
using Gym.WebUI.Models.ViewModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym.WebUI.Models
{
    [FluentValidation.Attributes.Validator(typeof(TrainingViewModelValidator))]
    public class TrainingViewModel
    {
        public int TrainingID { get; set; }

        public string Name { get; set; }
        public string Day { get; set; }
        public Categories Category { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }

    public enum Categories
    {
        Endurance,
        Strenght,
        Balance,
        Flexibility
    }
}