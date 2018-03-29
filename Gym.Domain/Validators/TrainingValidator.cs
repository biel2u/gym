using FluentValidation;
using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Validators
{
    class TrainingValidator : AbstractValidator<Training>
    {
        public TrainingValidator()
        {
            RuleFor(m => m.Name)
                .NotNull().WithMessage("Please specify the name of workout")
                .Length(1, 50).WithMessage("Name should contain from 1 to 50 characters");
        }     
    }
}
