using MeetingRoomManagementSystem.Data;
using MeetingRoomManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly MeetingDbContext _db;

        public BookingController(MeetingDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Booking> bookings = _db.Bookings.ToList();
            return View(bookings);
        }


        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bookings.Add(obj);
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
            var booking = _db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Booking obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bookings.Update(obj);
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
            var booking = _db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Bookings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Bookings.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Successfully Deleted ";
            return RedirectToAction("Index");
        }

    }
}