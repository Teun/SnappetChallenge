using AutoMapper;
using SnappetServices.DTOs;
using SnappetServices.Models;
using SnappetServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Services
{
    public class StudentsServices : IStudentsServices
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IMapper mapper;

        public StudentsServices(IStudentsRepository studentsRepository, IMapper mapper)
        {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
        }

        public IEnumerable<StudentV1Dto> GetAll()
        {
            return this.studentsRepository.GetAll().Select(p => this.mapper.Map<Student, StudentV1Dto>(p));
        }
    }
}
