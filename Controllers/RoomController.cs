using MeetingRoomManagementSystem.Data;
using MeetingRoomManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly MeetingDbContext _db;

        public RoomController(MeetingDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Room> rooms = _db.Rooms.ToList();
            return View(rooms);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Room obj)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var room = _db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Room obj)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Successfully Edited ";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var room = _db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        //[HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Rooms.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Rooms.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Successfully Deleted ";
            return RedirectToAction("Index");
        }

    }
}
