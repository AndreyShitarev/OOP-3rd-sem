namespace Lab_2
{
    public class OnlineCourse : Course
    {
        public string Platform { get; private set; }

        public OnlineCourse(int id, string title, string platform) : base(id, title)
        {
            Platform = platform;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"[Online course with ID: {Id}, name : {Title}, Platform: {Platform}, ID of this course's teacher: {(TeacherID.HasValue ? TeacherID.Value.ToString() : "Unassigned")}"); // if a course doesnt't have a teacher - programm will write "Unassigned"
            PrintStudents();
        }

        private void PrintStudents()
        {
            if (Students.Count == 0) return;
            Console.WriteLine("   Students:");
            foreach (var s in Students)
            {
                 Console.WriteLine($" - {s.Name} (ID: {s.Id})");
            }
        }
    }
}