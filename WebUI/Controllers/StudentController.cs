using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Concrete;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _db;

        public StudentController(SchoolDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var studentList = await _db.Students.ToListAsync();

            return View(studentList);
        }
        #region Add => GET - POST
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit => GET - POST
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete => GET - POST
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion




    }
}
