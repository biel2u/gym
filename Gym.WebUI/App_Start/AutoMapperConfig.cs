using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gym.Domain.Entities;
using Gym.WebUI.Models;

namespace Gym.WebUI.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Training, TrainingViewModel>();
            CreateMap<TrainingViewModel, Training>();
            CreateMap<Exercise, ExerciseViewModel>().ReverseMap();
        }
    }
}