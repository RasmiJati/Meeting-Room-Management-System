using MeetingRoomManagementSystem.Data;
using MeetingRoomManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly MeetingDbContext _db;

        public UserController(MeetingDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }

}