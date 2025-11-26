using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class Teacher
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
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

    abstract class Course // abstract class for all types of courses
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int? TeacherID { get; private set; } // a course can exists without a teacher
        private readonly List<Student> _students = new();
        public IReadOnlyCollection<Student> Students => _students; // return list of students, but only for reading

        protected Course(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void AddTeacher(int? Teacherid) 
        {
            TeacherID = Teacherid;
        }
        
        public void RemoveTeacher()
        {
            TeacherID = null;
        }

        public void AddStudent(Student student) 
        {
            _students.Add(student);
        }

        public abstract void PrintInfo();
    }

    public class OnlineCourse : Course
    {
        public string Platform { get; private set; }

        // I use word base to connect ID and title of Online course with parent class
        public OnlineCourse(int id, string title, string platform) : base(id, title)
        {
            Platform = platform;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"\n--- Online Course (ID: {Id}) ---");
            Console.WriteLine($"Online Course name: {Title}, platform {Platform}, TeacherID: {TeacherID ?? -1} (Unassigned)");
            Console.WriteLine("Students on this couurse: ");
            foreach (var s in Students)
            {
                Console.WriteLine($"- {s.Id}: {s.Name}"); // Name and Id will be added next
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

        public override void PrintInfo()
        {
            Console.WriteLine($"\n--- Offline Course (ID: {Id}) ---");
            Console.WriteLine($"Offline course name: {Title}, location: {Location}, TeacherID: {TeacherID ?? -1} (Unassigned)");
            Console.WriteLine($"Students on this course: ");
            foreach (var s in Students)
            {
                Console.WriteLine($"- {s.Id}: {s.Name}");
            }
        }
    }

    public static class CourseManagement
    {
        private static readonly List<Course> _allCourses = new();

        public static void AddCourse(Course course)
        {
            _allCourses.Add(course);
            Console.WriteLine($"\n[INFO] Course '{course.Title}' (ID: {course.Id}) successfully added.");
        }

        public static void RemoveCourse(int courseId)
        {
            Course deleteCourse = null;
            // Find needed course
            foreach (var course in _allCourses)
            {
                if (course.Id == courseId)
                {
                    deleteCourse = course;
                    break;
                }
            }

            if (deleteCourse != null)
            {
                _allCourses.Remove(deleteCourse);
            }
            else
            {
                Console.WriteLine($"Course with ID: {courseId} not found.");
            }
        }

        public static List<Course> CourseByTeacher(int teacherId)
        {
            var teacherCourses = new List<Course>();
            foreach (var course in _allCourses)
            {
                if (course.TeacherID.HasValue && course.TeacherID.Value == teacherId)
                {
                    teacherCourses.Add(course);
                }
            }
            return teacherCourses;
        }
    }

    class Program
    {
        static void Main()
        {
            var student1 = new Student(1, "Andrey");
            var student2 = new Student(2, "Dima");
            var student3 = new Student(3, "Danya");
            var student4 = new Student(4, "Gosha");
            var student5 = new Student(5, "Arseniy");
            
            var teacher1 = new Teacher(1, "San Sanych");
            var teacher2 = new Teacher(2, "Nikolay Nikolaevich");

            var online1 = new OnlineCourse(101, "Math logic", "Yandex Telemost");
            var offline1 = new OfflineCourse(102, "Underwater horseriding", "Central Swimming pool");
            var online2 = new OnlineCourse(103, "C# Advanced", "Zoom");

            // add courses
            CourseManagement.AddCourse(online1);
            CourseManagement.AddCourse(offline1);
            CourseManagement.AddCourse(online2);

            // add students 
            online1.AddStudent(student1);
            online1.AddStudent(student2);
            offline1.AddStudent(student3);
            offline1.AddStudent(student4);
            offline1.AddStudent(student5);
            online2.AddStudent(student1);

            // add teachers
            online1.AddTeacher(teacher1.Id);
            offline1.AddTeacher(teacher2.Id);
            online2.AddTeacher(teacher1.Id);

            online1.PrintInfo();
            offline1.PrintInfo();
            online2.PrintInfo();

            Console.WriteLine($"Courses with teacher {teacher1.Name} (ID: {teacher1.Id}):");
            CourseManagement.RemoveCourse(101);
        }
    }
}
