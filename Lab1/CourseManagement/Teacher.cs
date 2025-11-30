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
}