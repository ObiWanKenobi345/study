using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private WebApiContext db = new WebApiContext();
        private const int defaultLimit = 50;

        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        [Route("api/students.{ext}/search")]
        public IHttpActionResult SearchStudents(JObject sParams)
        {
            if (sParams == null)
                BadRequest();

            var students = new List<Student>();
            var name = (string)sParams["name"];
            var phone = (string)sParams["phone"];
            var columns = ((string)sParams["columns"]).Split(',');
            var offset = (int)sParams["offset"];
            var limit = ((int)sParams["limit"]) == 0 ? defaultLimit : (int)sParams["limit"];
            var globalike = ((string)sParams["globalike"]) == "on";
            var orderBy = (string)sParams["orderby"] == string.Empty ? "Id" : (string)sParams["orderby"];
            var sqlQuery = string.Empty;
            int minId = 0;
            int maxId = int.MaxValue;

            try
            {
                minId = (int)sParams["minid"];
            }
            catch (Exception) { }

            try
            {
                maxId = (int)sParams["maxid"];
            }
            catch (Exception) { }

            if (columns.Length == 0)
                columns = new string[] { "id", "name", "phone" };

            // 'Equal' search
            if (!globalike)
                sqlQuery = "SELECT * FROM Students WHERE Name = @P0 AND Phone = @P1 AND Id Between @P2 AND @P3 " +
                    "ORDER BY " + orderBy + " " +
                    "OFFSET @P4 ROWS FETCH NEXT @P5 ROWS ONLY";
            // 'Like' search
            else
                sqlQuery = "SELECT * FROM Students " +
                "WHERE Name LIKE '%' + @P0 + '%' AND Phone LIKE '%' + @P1 + '%' AND Id Between @P2 AND @P3 " +
                "ORDER BY " + orderBy + " " +
                "OFFSET @P4 ROWS FETCH NEXT @P5 ROWS ONLY";

            students = db.Students.SqlQuery(sqlQuery, name, phone, minId, maxId, offset, limit).ToList();

            if (columns.Contains("name") && columns.Contains("phone"))
                return Ok(students);
            if (columns.Contains("name"))
                return Ok(students.Select(x => new Student() { Id = x.Id, Name = x.Name }));
            if (columns.Contains("phone"))
                return Ok(students.Select(x => new Student() { Id = x.Id, Phone = x.Phone }));
            if (columns.Contains("id") && columns.Count() == 1)
                return Ok(students.Select(x => new Student() { Id = x.Id }));
            return Ok(students);
        }

        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student;
            try
            {
                student = db.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (InvalidOperationException) { }
            return NotFound();
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("StudentsApi", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}