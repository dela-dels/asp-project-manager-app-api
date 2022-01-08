using System;
using AutoMapper;
using ProjectManagerApp.DTOS.Projects;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.AutoMapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}