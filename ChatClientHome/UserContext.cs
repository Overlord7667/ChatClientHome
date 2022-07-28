using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ChatClientHome
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }

        public DbSet<ChatUser> Users { get; set; }
        public DbSet<User> UserLogin { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
