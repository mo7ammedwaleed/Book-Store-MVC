using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models.ViewModels;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using BookStore.Utility;
using BookStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Company).ToList();

            foreach (var user in objUserList)
            {
                if(user.Company == null)
                {
                    user.Company = new(){ Name = ""};
                }
            }

            return View(objUserList);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            return Json(new { data = objUserList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {


            return Json(new { success = true, message = "User Deleted Successfully" });
        }

        #endregion
    }
}