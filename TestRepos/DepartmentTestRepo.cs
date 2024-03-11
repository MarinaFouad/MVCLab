using Lab4.Models;
using Lab4.Service;

namespace Lab4.TestRepos
{
    public class DepartmentTestRepo : IDepartmentRepo
    {
        List<Department> departmentList = [
            new Department() { Name = "Dept1", Id = 1 },
            new Department() { Name = "Dept2", Id = 2 }

            ];

        public List<Department> GetAll()
        {
            return departmentList;
        }
        public Department GetById(int id)
        {
            return departmentList.FirstOrDefault(d => d.Id == id);
        }
        public Department GetByName(string name)
        {
            return departmentList.FirstOrDefault(s => s.Name == name);
        }
        public void Add(Department Department)
        {
            departmentList.Add(Department);
            
        }
        public void Update(Department Department)
        {
            var department = GetById(Department.Id);
            department.Name = Department.Name;
       
        }
        public void Delete(int id)
        {
            var Department = departmentList.FirstOrDefault(i => i.Id == id);
            departmentList.Remove(Department);
        }

    }
}
