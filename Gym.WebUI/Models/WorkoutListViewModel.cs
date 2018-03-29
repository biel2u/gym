using Gym.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.WebUI.Models
{
    public class WorkoutListViewModel
    {
        public IEnumerable<Training> Trainings { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}