using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Service
{
    public class StudentRepo : IStudentRepo
    {
        LabDbContext db;

        public StudentRepo(LabDbContext _db)
        {
            db = _db;
        }

        public List<Student> GetAll()
        {
            return db.Students.Include(d=>d.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(d => d.Id == id);
        }
        public Student GetByName(string name)
        {
            return db.Students.FirstOrDefault(s => s.Name == name);
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var student = db.Students.FirstOrDefault(i=>i.Id == id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
