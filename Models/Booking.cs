namespace MeetingRoomManagementSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Description { get; set; }
        
    }
}
