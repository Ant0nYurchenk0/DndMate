using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Enums
{
    public static class Class
    {
        public static Dictionary<CharacterClass, string> Icons = new Dictionary<CharacterClass, string> {
            { CharacterClass.Rogue, "https://cdn-icons.flaticon.com/png/512/4352/premium/4352171.png?token=exp=1655540768~hmac=cae335287e46d55f289e4487531ada2a" },
            { CharacterClass.Master, "https://cdn-icons-png.flaticon.com/512/5532/5532796.png" },
        };
    }
}