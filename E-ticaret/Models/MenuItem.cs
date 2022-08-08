namespace E_ticaret.Models
{
    //public class MenuItem
    //{
    //    public MenuItem(AnaMenu _anaMenuItem)
    //    {
    //        AnaMenuItem = _anaMenuItem;
    //    }

    //    public AnaMenu AnaMenuItem { get; set; }
    //}
    //public class Student
    //{
    //    public int StudentId { get; set; }
    //    public string StudentName { get; set; }
    //    public int Age { get; set; }
    //}
    public class MenuItem
    {
        public string text { get; set; }
        public bool disabled { get; set; }
        public string icon { get; set; }
        public int price { get; set; }
        public IEnumerable<MenuItem> items { get; set; }
    }
}
