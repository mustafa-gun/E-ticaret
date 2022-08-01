namespace E_ticaret.Models
{
    public class MenuItem
    {

        public MenuItem(AnaMenu _anaMenuItem)
        {
            AnaMenuItem = _anaMenuItem;
        }
        

        public AnaMenu AnaMenuItem { get; set; }
    }
}
