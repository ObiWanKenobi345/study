using System.Collections.Generic;
using Contracts.Core;
using lab3.Context;
using lab3.Entities;

namespace lab3.Core
{
    public class StudentDb : IStudentDb
    {
        private StudentContext db;

        public StudentDb()
        {
            db = new StudentContext();
        }

        public StudentEntity Add(StudentEntity model)
        {
            db.Students.Add(model);
            return model;
        }

        public StudentEntity Get(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return db.Students;
        }

        public int Update(StudentEntity model)
        {
            db.Students.Attach(model);
            var entry = db.Entry(model);

            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.Phone).IsModified = true;

            return model.Id;
        }

        public void Delete(StudentEntity model)
        {
            db.Students.Remove(model);
        }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}