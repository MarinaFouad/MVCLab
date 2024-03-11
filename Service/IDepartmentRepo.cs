using Lab4.Models;

namespace Lab4.Service
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
        void Update(Department department);
        void Delete(int id);
        void Add(Department department);
    }
}
