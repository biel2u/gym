using Gym.Domain.Abstract;
using Gym.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Gym.Domain.Concrete
{
    public class TrainingRepository : ITrainingRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Training> Trainings
        {
            get { return context.Trainings; }
        }

        public void SaveWorkout(Training training)
        {
            training.UserID = HttpContext.Current.User.Identity.GetUserId();
            if (training.TrainingID == 0)
            {
                context.Trainings.Add(training);
            }
            else
            {
                Training dbEntry = context.Trainings.Find(training.TrainingID);
                if (dbEntry != null)
                {
                    dbEntry.Name = training.Name;
                    dbEntry.Category = training.Category;
                    dbEntry.Day = training.Day;
                }
            }
            context.SaveChanges();
        }

        public Training DeleteWorkout(int trainingID)
        {
            Training dbEntry = context.Trainings.Find(trainingID);
            if (dbEntry != null)
            {
                context.Trainings.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
