using System;
using System.Collections.Generic;

namespace Lab 1
{
    abstract class Course // abstract class for all types of courses
    {
        public int Id {get; private set; } 
        public string Title { get; private set; }
        public int? TeacherID { get; private set; } // a course can exists without a teacher
        private readonly List<Students> _students = new();
        public IReadOnlyCollection<Student> Students => _students; // return list of students, but only for reading

        protected Course(int id, string title)
        {
            Id = id
            Title = title;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public AddTeacher(int? Teacherid);
        {
            TeacherID = Teacherid;
        }
        public RemoveTeacher()
        {
            TeacherID = null;
        }
        public void AddStudent(Student student) // class Student will be add next
        {
            _students.Add(student);
        }

        public abstract void PtintInfo();
    }
    
    public class OnlineCourse : Course
    {
        public string Platform { get; private set; }

        // I use word base to connect ID and title of Online course with parent class
        public OnlineCourse(int id, string title; string platform) : base(id, title)  
        { 
            Platform = platform;
        }

        public override PrintInfo()
        {
            Console.WriteLine($"Online Course name: {Title}, platform {Platform}, TeacherID: {TeacherID}");
            Console.WriteLine("Students on this couurse: ");
            foreach (var s in Students)
            {
                Console.writeLine($"{s.Id}: {s.Name}"); // Name and Id will be added next
            }
        }
    }

    public class OfflineCourse : Course
    {
        public string Location { get; private set; }

        public OfflineCourse(int id, string title, string location) : base(id, title)
        {
            Location = location;
        }

        public override PrintInfo()
        {
            Console.writeLine($"Offline course name: {Title}, location: {Location}, TeacherID: {TeacherID}");
            Console.writeLine($"Students on this course: ");
            foreach (var s in Student)
            {
                Console.writeLine($"{s.Id}: {s.Name}");
            }
        }
    }

    public class Student 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Program
    {
        static void Main()
        {
            var student1 = new Student(001, "Andrey");
            var student2 = new Student(002, "Dima");
            var student3 = new Student(003, "Danya");
            var student4 = new Student(004, "Gosha");
            var student5 = new Student(005, "Arseniy");

            var online1 = new OnlineCourse(1, "Math logic", "Yandex Telemost");
            var offline1 = new OfflineCourse(2, "Underwater horseriding", "Central Swimming pool");

            // add students 
            online1.AddStudent(studen1);
            online1.AddStudent(studen2);
            offline1.AddStudent(studen3);
            offline1.AddStudent(studen4);
            offline1.AddStudent(studen5);

            // add teachers
            online1.AddTeacher(1);
            offline1.AddTeacher(2);

            online1.PrintInfo();
            offline1.PrintInfo();
        }
    }
}
