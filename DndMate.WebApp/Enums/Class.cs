using System.Collections.Generic;

namespace DndMate.WebApp.Enums
{
    public static class Class
    {
        public static Dictionary<CharacterClass, string> Icons = new Dictionary<CharacterClass, string> {
            { CharacterClass.Master, "https://cdn-icons-png.flaticon.com/512/1995/1995571.png" },
            { CharacterClass.Artificer, "https://dndmate.blob.core.windows.net/dndmate/artificer.png" },
            { CharacterClass.Barbarian, "https://dndmate.blob.core.windows.net/dndmate/barbarian.png" },
            { CharacterClass.Bard, "https://dndmate.blob.core.windows.net/dndmate/bard.png" },
            { CharacterClass.Cleric, "https://dndmate.blob.core.windows.net/dndmate/cleric.png" },
            { CharacterClass.Druid, "https://dndmate.blob.core.windows.net/dndmate/druid.png" },
            { CharacterClass.Fighter, "https://dndmate.blob.core.windows.net/dndmate/fighter.png" },
            { CharacterClass.Monk, "https://dndmate.blob.core.windows.net/dndmate/monk.png" },
            { CharacterClass.Paladin, "https://dndmate.blob.core.windows.net/dndmate/paladin.png" },
            { CharacterClass.Ranger, "https://dndmate.blob.core.windows.net/dndmate/ranger.png" },
            { CharacterClass.Rogue, "https://dndmate.blob.core.windows.net/dndmate/rogue.png" },
            { CharacterClass.Sorcerer, "https://dndmate.blob.core.windows.net/dndmate/sorcerer.png" },
            { CharacterClass.Warlock, "https://dndmate.blob.core.windows.net/dndmate/warlock.png" },
            { CharacterClass.Wizard, "https://dndmate.blob.core.windows.net/dndmate/wizard.png" },
        };
    }
}