using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Concrete
{
    public class ExerciseRepository : IExerciseRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Exercise> Exercises
        {
            get { return context.Exercises; }
        }

        public void SaveExercise(Exercise exercise)
        {  
            if (exercise.ExerciseID == 0)
            {
                context.Exercises.Add(exercise);
            }
            else
            {
                Exercise dbEntry = context.Exercises.Find(exercise.ExerciseID);
                if (dbEntry != null)
                {
                    dbEntry.Name = exercise.Name;
                    dbEntry.Series = exercise.Series;
                    dbEntry.Repetitions = exercise.Repetitions;
                    dbEntry.RestTime = exercise.RestTime;
                    dbEntry.Weight = exercise.Weight;
                    dbEntry.Description = exercise.Description;
                }
            }
            context.SaveChanges();
        }

        public Exercise DeleteExercise(int exerciseID)
        {
            Exercise dbEntry = context.Exercises.Find(exerciseID);
            if (dbEntry != null)
            {
                context.Exercises.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
