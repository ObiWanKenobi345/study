using AutoMapper;
using Contracts.Mapper;
using lab3.Entities;
using lab3.Models;

namespace lab3.Mapper
{
    public class StudentMapperConfig : IStudentMapperConfig
    {
        public MapperConfiguration StudentMapperInit()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentEntity>();
                cfg.CreateMap<StudentEntity, Student>();
            });
        }    
    }
}