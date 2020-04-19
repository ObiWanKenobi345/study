using System.Collections.Generic;
using lab3.Entities;

namespace Contracts.Core
{
    public interface IStudentDb
    {
        StudentEntity Add(StudentEntity model);
        StudentEntity Get(int id);
        IEnumerable<StudentEntity> GetAll();
        int Update(StudentEntity model);
        void Delete(StudentEntity model);
        void Commit();
    }
}
