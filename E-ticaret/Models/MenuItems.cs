namespace E_ticaret.Models
{
    public class MenuItems
    {

        public MenuItems(AnaMenu _anaMenuItem)
        {
            AnaMenuItem = _anaMenuItem;
        }
        

        public AnaMenu AnaMenuItem { get; set; }
    }
}
