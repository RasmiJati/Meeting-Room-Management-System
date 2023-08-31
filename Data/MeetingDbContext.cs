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
    }
}
