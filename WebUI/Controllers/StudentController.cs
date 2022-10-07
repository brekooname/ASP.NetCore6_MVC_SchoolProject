using DataAccess;
using DataAccess.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Concrete;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var studentList = _unitOfWork.StudentRepository.GetAll();
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
                _unitOfWork.StudentRepository.Add(student);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Student Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Process Failed";
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit => GET - POST
        public IActionResult Edit(int id)
        {
            var student = _unitOfWork.StudentRepository.GetFirstOrDefault(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Student Updated Successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete => GET - POST
        public IActionResult Delete(int id)
        {
            var student = _unitOfWork.StudentRepository.GetFirstOrDefault(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student student)
        {
            _unitOfWork.StudentRepository.Remove(student);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Student Removed Successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
