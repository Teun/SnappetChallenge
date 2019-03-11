using AutoMapper;
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
            this.CreateMap<IResultV1Dto, Result>();
            this.CreateMap<Result, Result>();
        }
    }
}
