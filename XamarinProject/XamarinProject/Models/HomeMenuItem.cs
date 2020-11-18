using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.Models
{
    public enum MenuItemType
    {
        AnaSayfa,
        Hakkimizda,
        Giris,
        Kayit
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
        public string IconName { get; set; }
    }
}
