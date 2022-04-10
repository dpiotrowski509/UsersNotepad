using System.Data.Entity;
using UsersNotepad.Database.Models;

namespace UsersNotepad.Database
{
    public class UsersNotepadDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAttribute> UserAttributes { get; set; }

        public UsersNotepadDbContext()
        {
        }

    }
}
