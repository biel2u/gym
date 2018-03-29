﻿using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Abstract
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> Exercises { get; }
        void SaveExercise(Exercise exercise);
        Exercise DeleteExercise(int exerciseID);
    }
}
