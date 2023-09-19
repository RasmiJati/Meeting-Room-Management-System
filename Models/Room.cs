namespace MeetingRoomManagementSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public string Capacity { get;set; }
        public string Description { get;set; }
        public RoomStatus Status { get; set; }
    }
}
