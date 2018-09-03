using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetailsServiceLayer.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        public StudentRepository()
        {
            Add(new Student { name = "ali", id = 1, gender = "erkek", age = 15 });
            Add(new Student { name = "ayşe", id = 2, gender = "kız", age = 14 });
            Add(new Student { name = "ilhan", id = 3, gender = "erkek", age = 15 });
            Add(new Student { name = "hatice", id = 4, gender = "kız", age = 15 });
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student Get(int id)
        {
            return students.Find(s => s.id == id);
        }

        public Student Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("item");
            }
            students.Add(student);
            return student;
        }

        public void Remove(int id)
        {
            students.RemoveAll(s => s.id == id);
        }

        public bool Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }
            int index = students.FindIndex(s => s.id == student.id);
            if (index == -1)
            {
                return false;
            }
            students.RemoveAt(index);
            students.Add(student);
            return true;
        }
    }
}