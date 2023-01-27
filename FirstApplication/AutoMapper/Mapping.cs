using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FirstApplication.DB;
using FirstApplication.Models;

namespace FirstApplication.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<jobs, JobVm>();
            CreateMap<JobVm, jobs>();
            CreateMap<UserInformation, UserInformationVm>();
            CreateMap<UserInformationVm, UserInformation>();
            CreateMap<Adresss, AdressUserVM>();
            CreateMap<AdressUserVM, Adresss>();
            CreateMap<QuestionJob, QuestionJobVm>();
            CreateMap<QuestionJobVm, QuestionJob>();

            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Post, PostVm>();
            CreateMap<PostVm, Post>();

            CreateMap<Feeling, FeelingVm>();
            CreateMap<FeelingVm, Feeling>();
        }

        /*
         ID , Name , Department , Description
         
         */
    }
}
