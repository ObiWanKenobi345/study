using System.Collections.Generic;
using Contracts.Models;
using lab3.Entities;

namespace Contracts.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentEntity> GetFilter(Filter filter);
        int Insert(StudentEntity model);
        int Update(StudentEntity model);
        void Delete(int id);
    }
}
