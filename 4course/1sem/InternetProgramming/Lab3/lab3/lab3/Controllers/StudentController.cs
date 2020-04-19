using System.Collections.Generic;
using System.Web.Http;
using Contracts.Mapper;
using Contracts.Models;
using Contracts.Services;
using lab3.Entities;
using lab3.Models;

namespace lab3.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentMapperConfig _studentMapperConfig;
        private readonly IStudentService _studentService;
        
        public StudentController(
            IStudentMapperConfig studentMapperConfig,
            IStudentService studentService)
        {
            _studentMapperConfig = studentMapperConfig;
            _studentService = studentService;
        }

        [HttpPost]
        public int Post([FromBody] Student model)
        {
            var mapper = _studentMapperConfig
                .StudentMapperInit()
                .CreateMapper();

            var entity = mapper.Map<StudentEntity>(model);

            return _studentService.Insert(entity);
        }

        [HttpGet]
        public IEnumerable<Student> Get([FromUri] Filter filter)
        {
            var mapper = _studentMapperConfig
                .StudentMapperInit()
                .CreateMapper();

            return mapper
                .Map<IEnumerable<StudentEntity>, 
                IEnumerable<Student>>(
                _studentService.GetFilter(filter));
        }

        [HttpPut]
        public int Put(int id, [FromBody] Student model)
        {
            var mapper = _studentMapperConfig
                .StudentMapperInit()
                .CreateMapper();

            model.Id = id;
            var entity = mapper.Map<StudentEntity>(model);

            return _studentService.Update(entity);
        }

        [HttpDelete]
        public void Delete(int id)
        {
           _studentService.Delete(id);
        }
    }
}
