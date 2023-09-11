using MeetingRoomManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomManagementSystem.Data
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin123@gmail.com",
                Password = "Admin@123",
                Role = UserRole.ADMIN
            };

            modelBuilder.Entity<User>().HasData(user);
            base.OnModelCreating(modelBuilder);
        }

    }
}
