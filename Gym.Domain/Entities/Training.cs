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
    [FluentValidation.Attributes.Validator(typeof(TrainingValidator))]
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }
        public string Name { get; set; }
        public string Day { get; set; }
        public Categories Category { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual User User { get; set; }
    }

    public enum Categories
    {
        Endurance,
        Strenght,
        Balance,
        Flexibility
    }
}
