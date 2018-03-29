using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.WebUI.Models.ViewModelValidators
{
    class TrainingViewModelValidator : AbstractValidator<TrainingViewModel>
    {
        public TrainingViewModelValidator()
        {
            RuleFor(m => m.Name)
                .NotNull().WithMessage("Please specify the name of workout")
                .Length(1, 50).WithMessage("Name should contain from 1 to 50 characters");
        }
    }
}