namespace E_ticaret.Models
{
    public class AnaMenu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public List<AltMenu> AltMenuler { get; set; }


    }

    public class AltMenu
    {
        public int Id { get; set; }
        public string DropdownName { get; set; }
        public string DropdownLink { get; set; }
    }
}
