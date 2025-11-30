namespace Lab_2
{
    public abstract class Course
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int? TeacherID { get; private set; }
        private readonly List<Student> _students = new();
        public IReadOnlyCollection<Student> Students => _students;

        protected Course(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void AddTeacher(int teacherId)
        {
            TeacherID = teacherId;
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
}
