using System.Collections.Generic;
using System.Linq;
using Contracts.Core;
using Contracts.Models;
using Contracts.Services;
using Contracts.UnitOfWork;
using lab3.Entities;

namespace lab3.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentDb _studentDb;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(
            IStudentDb studentDb, 
            IUnitOfWork unitOfWork)
        {
            _studentDb = studentDb;
            _unitOfWork = unitOfWork;
        }

        public int Update(StudentEntity model)
        {
            using (_unitOfWork)
            {
                int id = _studentDb.Update(model);
                return id;
            }        
        }

        public int Insert(StudentEntity model)
        {
            StudentEntity result = null;
            using (_unitOfWork)
            {
                result = _studentDb.Add(model);
            }
            return result.Id;
        }

        public IEnumerable<StudentEntity> GetFilter(Filter filter)
        {
            var students = _studentDb.GetAll().ToList();

            if (!string.IsNullOrEmpty(filter.Query))
            {
                if (filter.IsGlobal.HasValue && filter.IsGlobal.Value)
                    students = students.Where(el => filter.Query.Contains(el.Id.ToString()) ||
                                                    el.Name.Contains(filter.Query) || el.Phone.Contains(filter.Query))
                        .ToList();

                else students = students.Where(el => el.Name.Contains(filter.Query)).ToList();
            }

            if (filter.MinId.HasValue) students = students.Where(el => el.Id > filter.MinId.Value).ToList();
            if (filter.MaxId.HasValue) students = students.Where(el => el.Id < filter.MaxId.Value).ToList();

            if (filter.IsSort.HasValue && filter.IsSort.Value)
                students = students.OrderBy(el => el.Name).ToList();
            else students = students.OrderBy(el => el.Id).ToList();

            if (filter.Offset.HasValue) students = students.Skip(filter.Offset.Value).ToList();
            if (filter.Limit.HasValue) students = students.Take(filter.Limit.Value).ToList();

            return students;
        }

        public void Delete(int id)
        {
            using (_unitOfWork)
            {
                var model = _studentDb.Get(id);
                _studentDb.Delete(model);
            } 
        }
    }
}