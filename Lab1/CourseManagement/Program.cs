using System;
using System.Collections.Generic;
using System.Linq; 

namespace Lab_2
{
    class Program
    {
        static void Main()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Show all courses");
                Console.WriteLine("2. Add course");
                Console.WriteLine("3. Remove course");
                Console.WriteLine("4. Add teacher to a course");
                Console.WriteLine("5. Add student to a course");
                Console.WriteLine("6. Find courses by teacher's ID");
                Console.WriteLine("7. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListOfCourses();
                        break;
                    case "2":
                        AddCourse();
                        break;
                    case "3":
                        RemoveCourse();
                        break;
                    case "4":
                        AssignTeacher();
                        break;
                    case "5":
                        AddStudent();
                        break;
                    case "6":
                        FindTeacherCourses();
                        break;
                    case "7":
                        isRunning = false;
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }

        static void ListOfCourses() // method to show all courses
        {
            var courses = CourseManagement.GetAllCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("no courses");
            }
            else
            {
                Console.WriteLine("All courses list: ");
                foreach (var course in courses)
                {
                    course.PrintInfo();
                }
            }
        }

        static void AddCourse() // method to create new course 
        {
            Console.WriteLine("Offline / Online");
            Console.WriteLine("1. Online");
            Console.WriteLine("2. Offline");
            string type = Console.ReadLine();

            Console.Write("Create course's ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))  // if ID not int
            { 
                Console.WriteLine("Wrong ID"); return; 
            } 
            
            Console.Write("Create Title: ");
            string title = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Choose platform: ");
                string platform = Console.ReadLine();
                CourseManagement.AddCourse(new OnlineCourse(id, title, platform));
            }
            else if (type == "2")
            {
                Console.Write("Choose location: ");
                string location = Console.ReadLine();
                CourseManagement.AddCourse(new OfflineCourse(id, title, location));
            }
            else
            {
                Console.WriteLine("Try to choose course type again");
            }
        }

        static void RemoveCourse()
        {
            Console.Write("Choose course to delete by it's ID: ");
            if (int.TryParse(Console.ReadLine(), out int id)) // if ID is int
            {
                CourseManagement.RemoveCourse(id);
            }
        }

        static void AssignTeacher() // method to add a teacher for a course
        {
            Console.Write("Choose course's ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId)) return;

            var course = CourseManagement.GetCourseById(courseId);
            if (course == null)
            {
                Console.WriteLine("Didn't find a course with this ID");
                return;
            }

            Console.Write("Eneter teacher's ID: ");
            if (int.TryParse(Console.ReadLine(), out int teacherId))
            {
                course.AddTeacher(teacherId);
                Console.WriteLine($"Teacher with ID {teacherId} assigned to a course with name '{course.Title}'.");
            }
        }

        static void AddStudent() // method to add a student to a course
        {
            Console.Write("Enter course's ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId)) return;

            var course = CourseManagement.GetCourseById(courseId);
            if (course == null)
            {
                Console.WriteLine("Didn't find a course with this ID");
                return;
            }

            Console.Write("Enter student's ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId)) return;
            
            Console.Write("Enter syudent's name: ");
            string name = Console.ReadLine();

            course.AddStudent(new Student(studentId, name));
            Console.WriteLine($"Student {name} added to a course");
        }

        static void FindTeacherCourses() // method to find all courses where assigned a teacher with this ID
        {
            Console.Write("Enter teacher's ID: ");
            if (int.TryParse(Console.ReadLine(), out int teacherId))
            {
                var courses = CourseManagement.GetCoursesByTeacher(teacherId);
                if (courses.Count > 0)
                {
                    Console.WriteLine($"Teacher with ID {teacherId} is assigned to this courses:");
                    foreach (var c in courses) c.PrintInfo();
                }
                else
                {
                    Console.WriteLine("This teacher has any courses");
                }
            }
        }
    }
}
