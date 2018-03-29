using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Abstract
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> Trainings { get; }
        void SaveWorkout(Training training);
        Training DeleteWorkout(int trainingID);
    }
}
