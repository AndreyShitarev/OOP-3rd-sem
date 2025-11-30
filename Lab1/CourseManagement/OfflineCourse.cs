namespace Lab_2
{
    public class OfflineCourse : Course
    {
        public string Location { get; private set; }

        public OfflineCourse(int id, string title, string location) : base(id, title)
        {
            Location = location;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Offline course with ID: {Id}, Name: {Title}, Location: {Location},  Teacher's ID: {(TeacherID.HasValue ? TeacherID.Value.ToString() : "Unassigned")}"); // the same logic as for an online course
            PrintStudents();
        }

        private void PrintStudents()
        {
            if (Students.Count == 0) return;
            Console.WriteLine("   Студенты:");
            foreach (var s in Students) 
            {
                Console.WriteLine($" - {s.Name} (ID: {s.Id})");
            }
        }
    }
}