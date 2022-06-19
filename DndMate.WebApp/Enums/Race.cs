using System.ComponentModel.DataAnnotations;

namespace DndMate.WebApp.Enums
{
    public enum Race
    {
        Human = 0,
        Dragonborn = 1,
        Dwarf = 2,
        Elf = 3,
        Gnome = 4,
        [Display(Name = "Half-Elf")]
        HalfElf = 5,
        Halfing = 6,
        [Display(Name = "Half-Orc")]
        HalfOrc = 7,
        Tiefling = 8,
    }
}