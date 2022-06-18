﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<Character>
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Gamespace> Gamespaces { get; set; }
        public DbSet<GamespaceChar> Characters { get; set; }
        public DbSet<GamespaceCharacterSpell> CharacterSpells { get; set; }
        public DbSet<Note> Notes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}