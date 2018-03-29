using Gym.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.Entities
{
    [FluentValidation.Attributes.Validator(typeof(ExerciseValidator))]
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int RestTime { get; set; }

        [ForeignKey("Training")]
        public int TrainingID { get; set; }
        public virtual Training Training { get; set; }
    }
}
