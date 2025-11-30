namespace Lab_2
{
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
}