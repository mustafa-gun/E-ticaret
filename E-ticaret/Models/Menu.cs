namespace E_ticaret.Models
{
   public class UrlMenuId
    {
        public int MenuId { get; set; }
    }

    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
    
    public class AltMenu
    {
        public int AltMenuId { get; set; }
        public string AltMenuName { get; set; }
        public int AnaMenuId { get; set; }
    }
}
