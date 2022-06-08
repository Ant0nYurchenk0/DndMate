using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DndMate.WebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Character : IdentityUser
    {
        public List<GamespaceChar> GamespaceCharacters { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Character> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<Character>
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Gamespace> Gamespaces { get; set; }
        public DbSet<GamespaceSpell> GamespaceSpell { get; set; }
        public DbSet<GamespaceChar> GamespaceCharacters { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GamespaceChar>().HasKey(sc => new { sc.CharacterId, sc.GamespaceId });
            modelBuilder.Entity<GamespaceSpell>().HasKey(sc => new { sc.SpellId, sc.GamespaceId });
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}