using Lab4.Models;

namespace Lab4.Service
{
    public class DepartmentRepo : IDepartmentRepo
    {
        LabDbContext db;

        public DepartmentRepo(LabDbContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(d => d.Id == id);
        }
        public Department GetByName(string name)
        {
            return db.Departments.FirstOrDefault(s => s.Name == name);
        }
        public void Add(Department Department)
        {
            db.Departments.Add(Department);
            db.SaveChanges();
        }
        public void Update(Department Department)
        {
            db.Departments.Update(Department);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var Department = db.Departments.FirstOrDefault(i => i.Id == id);
            db.Departments.Remove(Department);
        }
    }
}
