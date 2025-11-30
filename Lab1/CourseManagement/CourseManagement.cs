using System;
using System.Collections.Generic;
using System.Linq; 

namespace Lab_2
{
    public static class CourseManagement
    {
        private static readonly List<Course> _allCourses = new();

        public static void AddCourse(Course course)
        {
            if (_allCourses.Any(c => c.Id == course.Id))
            {
                Console.WriteLine($"Error: the course with ID {course.Id} already exist");
                return;
            }
            _allCourses.Add(course);
            Console.WriteLine($"Course '{course.Title}' added");
        }

        public static void RemoveCourse(int courseId)
        {
            var course = _allCourses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                _allCourses.Remove(course);
                Console.WriteLine($"Course with ID {courseId} deleted");
            }
            else
            {
                Console.WriteLine($"Course with ID {courseId} not found");
            }
        }

        public static List<Course> GetAllCourses()
        {
            return new List<Course>(_allCourses);
        }

        public static Course GetCourseById(int id)
        {
            return _allCourses.FirstOrDefault(c => c.Id == id);
        }

        public static List<Course> GetCoursesByTeacher(int teacherId)
        {
            return _allCourses.Where(c => c.TeacherID == teacherId).ToList();
        }
    }
}