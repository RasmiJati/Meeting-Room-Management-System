using MeetingRoomManagementSystem.Converter;
using MeetingRoomManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomManagementSystem.Data
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
    }
}
