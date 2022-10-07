using DataAccess.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Models.Concrete; 

namespace WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var courseList = _unitOfWork.CourseRepository.GetAll();
            return View(courseList);
        }

        #region Add => GET - POST
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseRepository.Add(course);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Course Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Process Failed";
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit => GET - POST
        public IActionResult Edit(int id)
        {
            var course = _unitOfWork.CourseRepository.GetFirstOrDefault(s => s.Id == id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveAsync(); 
            TempData["success"] = "Course Updated Successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete => GET - POST
        public IActionResult Delete(int id)
        {
            var course = _unitOfWork.CourseRepository.GetFirstOrDefault(s => s.Id == id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Course course)
        {
            _unitOfWork.CourseRepository.Remove(course);
            await _unitOfWork.SaveAsync(); 
            TempData["success"] = "Course Removed Successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion 

    }
}
