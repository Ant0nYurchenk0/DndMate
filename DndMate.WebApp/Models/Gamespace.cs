﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class Gamespace
    {
        public Gamespace()
        {
            GamespaceCharacters = new List<GamespaceChar>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public List<GamespaceChar> GamespaceCharacters { get; set; }
    }
}