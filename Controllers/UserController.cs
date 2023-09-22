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
        public IActionResult UserIndex()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] // prevent the cross site frogery attacks
        public IActionResult Create(User obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("name", "Name and email can't be same");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
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
            var user = _db.Users.Find(id);
            
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] // prevent the cross site frogery attacks
        public IActionResult Edit(User obj)
        {
            if (obj.Name == obj.Email)
            {
                ModelState.AddModelError("name", "Name and email can't be same");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
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
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        //[HttpPost]
        [ValidateAntiForgeryToken] // prevent the cross site frogery attacks
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Successfully Deleted ";
            return RedirectToAction("Index");
        }

        [HttpPost]
       public IActionResult Login(User obj)
        {
            bool userExist = _db.Users.Any(x => x.Role == obj.Role && x.Email == obj.Email && x.Password == obj.Password);
            
            if (userExist)
            {
                if (obj.Role == UserRole.ADMIN)
                {
                    TempData["success"] = "Login Successfull";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["success"] = "Login Successfull";
                    return RedirectToAction("UserIndex", "Home");
                }
            }
            TempData["error"] = "Email or password or role is invalid";
            return View();
        }
    }
        }