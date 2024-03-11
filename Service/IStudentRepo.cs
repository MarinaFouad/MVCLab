﻿using Lab4.Models;

namespace Lab4.Service
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student GetByName(string Name);
        void Delete(int id);
        void Add(Student student);
        void Update(Student student);


    }
}
