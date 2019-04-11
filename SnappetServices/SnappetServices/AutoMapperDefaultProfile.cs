using AutoMapper;
using SnappetServices.DTOs;
using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices
{
    public class AutoMapperDefaultProfile : Profile
    {
        public AutoMapperDefaultProfile()
        {
            this.CreateMap<ResultV1Dto, Result>();
            this.CreateMap<Result, ResultV1Dto>();

            this.CreateMap<StudentV1Dto, Student>();
            this.CreateMap<Student, StudentV1Dto>();
        }
    }
}
