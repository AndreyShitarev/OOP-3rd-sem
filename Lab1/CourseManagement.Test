using Lab_2;
using Xunit;
using System.Linq;
using System.Reflection; 
using System.Collections.Generic;

public class SimpleCourseTests : IDisposable
{
    public SimpleCourseTests()
    {
        var field = typeof(CourseManagement).GetField("_allCourses", BindingFlags.Static | BindingFlags.NonPublic);
        (field?.GetValue(null) as List<Course>)?.Clear();
    }

    public void Dispose()
    {
        var field = typeof(CourseManagement).GetField("_allCourses", BindingFlags.Static | BindingFlags.NonPublic);
        (field?.GetValue(null) as List<Course>)?.Clear();
    }
    
    private class DummyCourse : Course
    {
        public DummyCourse(int id, string title) : base(id, title) { }
        public override void PrintInfo() { }
    }

    [Fact]
    public void Course_TeacherAssignment_Works()
    {
        var course = new DummyCourse(1, "Test");
        course.AddTeacher(101);
        Assert.Equal(101, course.TeacherID);
        
        course.RemoveTeacher();
        Assert.Null(course.TeacherID);
    }

    [Fact]
    public void Course_StudentRegistration_Works()
    {
        var course = new DummyCourse(2, "Test");
        course.AddStudent(new Student(1, "Alice"));
        Assert.Single(course.Students);
        Assert.Equal("Alice", course.Students.First().Name);
    }

    [Fact]
    public void OnlineCourse_StoresPlatform()
    {
        var course = new OnlineCourse(3, "Net", "Zoom");
        Assert.Equal("Zoom", course.Platform);
    }

    [Fact]
    public void OfflineCourse_StoresLocation()
    {
        var course = new OfflineCourse(4, "Java", "Room");
        Assert.Equal("Room", course.Location);
    }

    [Fact]
    public void Management_AddAndRemove_Works()
    {
        var course = new OnlineCourse(5, "SQL", "Teams");
        CourseManagement.AddCourse(course);
        Assert.Single(CourseManagement.GetAllCourses());
        
        CourseManagement.RemoveCourse(5);
        Assert.Empty(CourseManagement.GetAllCourses());
    }

    [Fact]
    public void Management_PreventsDuplicateID()
    {
        CourseManagement.AddCourse(new OnlineCourse(6, "A", "P"));
        CourseManagement.AddCourse(new OnlineCourse(6, "B", "P")); 
        Assert.Single(CourseManagement.GetAllCourses());
    }

    [Fact]
    public void Management_GetByTeacher_ReturnsCorrectList()
    {
        var c1 = new DummyCourse(7, "Math"); 
        c1.AddTeacher(200);
        var c2 = new DummyCourse(8, "Phys"); 
        c2.AddTeacher(200); 
        var c3 = new DummyCourse(9, "Chem"); 
        
        CourseManagement.AddCourse(c1);
        CourseManagement.AddCourse(c2);
        CourseManagement.AddCourse(c3);

        var courses = CourseManagement.GetCoursesByTeacher(200);

        Assert.Equal(2, courses.Count);
        Assert.Contains(courses, c => c.Title == "Math");
        Assert.Contains(courses, c => c.Title == "Phys");
    }
}
