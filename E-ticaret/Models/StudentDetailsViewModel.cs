namespace E_ticaret.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Gender { get; set; }
    }
    public class Address
    {
        public int StudentId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
    }
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public Address Address { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
    }
}
