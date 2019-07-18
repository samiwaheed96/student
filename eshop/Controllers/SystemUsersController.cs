using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using eshop.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace eshop.Controllers
{
    public class SystemUsersController : Controller
    {
        private readonly eshopContext _context;

        private readonly IHostingEnvironment _env;

        public SystemUsersController(eshopContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: SystemUsers
        public async Task<IActionResult> Index()
        {
            if (AuthenticateUser())
            {
                return View(await _context.SystemUser.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        
        




        // GET: SystemUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SystemUser U)
        {
            SystemUser LoggedInUser = _context.SystemUser.Where(abc => abc.Username == U.Username && abc.Password == U.Password).FirstOrDefault();

            if (LoggedInUser == null)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }


            ////Maintain User Server Side Session
            HttpContext.Session.SetString("Username", LoggedInUser.Username);
            HttpContext.Session.SetString("UserRole", LoggedInUser.Role);
            HttpContext.Session.SetString("UserDisplayName", LoggedInUser.DisplayName);
            if (LoggedInUser.Role == "Admin")
            {
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return RedirectToAction("UserDashboard");
            }
        }
          


            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }



            public bool AuthenticateUser()
            {


                return true;
            }
        


        // GET: SystemUsers/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult UserDashboard()
        {
            return View();
        }

        // POST: SystemUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,DisplayName,Status,Role,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,ProfilePicture")] SystemUser systemUser, IFormFile ProfilePicture)
        {
            if (ModelState.IsValid)
            {
                if (ProfilePicture != null)
                {
                    string FileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfilePicture.FileName);
                    string FilePath = _env.WebRootPath + "/SystemData/ProfilePictures/";
                    FileStream FS = new FileStream(FilePath + FileName, FileMode.Create);
                    ProfilePicture.CopyTo(FS);
                    FS.Close();
                    systemUser.ProfilePicture = "/SystemData/ProfilePictures/" + FileName;
                }

                systemUser.Status = "Active";
                systemUser.Role = "staff";
                systemUser.CreatedDate = DateTime.Now;
                systemUser.CreatedBy = "Self";
                _context.Add(systemUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemUser);
        }

        // GET: SystemUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser.FindAsync(id);
            if (systemUser == null)
            {
                return NotFound();
            }
            return View(systemUser);
        }

        // POST: SystemUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,DisplayName,Status,Role,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,ProfilePicture")] SystemUser systemUser)

        {
            if (id != systemUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemUserExists(systemUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(systemUser);
        }

        // GET: SystemUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }

        // POST: SystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemUser = await _context.SystemUser.FindAsync(id);
            _context.SystemUser.Remove(systemUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemUserExists(int id)
        {
            return _context.SystemUser.Any(e => e.Id == id);
        }
    }
}
