﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{

    public class Spell
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Level { get; set; }
    }

}