﻿using FluentValidation;
using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Validators
{
    class ExerciseValidator : AbstractValidator<Exercise>
    {
        public ExerciseValidator()
        {
            RuleFor(m => m.Name)
                .NotNull().WithMessage("Please specify the name of exercise")
                .Length(1, 50).WithMessage("Name should contain from 1 to 50 characters");
            RuleFor(m => m.Series)
                .NotNull().WithMessage("Please specify the number of series")
                .GreaterThan(0).WithMessage("Wrong value!");
            RuleFor(m => m.Repetitions)
                .NotNull().WithMessage("Please specify the number of repetitions")
                .GreaterThan(0).WithMessage("Wrong value!");
            RuleFor(m => m.RestTime)
                .NotNull().WithMessage("Please specify the rest time")
                .GreaterThan(0).WithMessage("Wrong value!");
            RuleFor(m => m.Weight)
                .NotNull().WithMessage("Please specify the weight")
                .GreaterThanOrEqualTo(0).WithMessage("Wrong value!");
        }
    }
}
