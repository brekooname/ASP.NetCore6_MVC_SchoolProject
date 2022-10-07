using DataAccess.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Concrete;
using Models.Concrete.ViewModels.TeacherVMs;

namespace WebUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            TeacherListViewModel teacherListVM = new()
            {
                TeacherList = _unitOfWork.TeacherRepository.GetAll(),
                CourseList = _unitOfWork.CourseRepository.GetAll()
            };
            return View(teacherListVM);
        }


        #region Add => GET - POST
        public IActionResult Add()
        {
            TeacherViewModel teacherVM = new()
            {
                Teacher = new(),
                CourseList = GetSelectedItems()
            };
            return View(teacherVM);
        }
        [HttpPost]
        public async Task<IActionResult> Add(TeacherViewModel teacherVm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TeacherRepository.Add(teacherVm.Teacher);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Teacher Added Successfully";
                return RedirectToAction(nameof(Index));
            }
            teacherVm.CourseList = GetSelectedItems();
            return View(teacherVm);
        }
        #endregion


        #region Edit => GET - POST
        public IActionResult Edit(int id)
        {
            var teacher = _unitOfWork.TeacherRepository.GetFirstOrDefault(s => s.Id == id);

            TeacherViewModel teacherVM = new()
            {
                Teacher = teacher,
                CourseList = GetSelectedItems()
            };
            return View(teacherVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeacherViewModel teacherVm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TeacherRepository.Update(teacherVm.Teacher);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Teacher Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            teacherVm.CourseList = GetSelectedItems();
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete => GET - POST
        public IActionResult Delete(int id)
        {
            var teacher = _unitOfWork.TeacherRepository.GetFirstOrDefault(s => s.Id == id);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Teacher teacher)
        {
            _unitOfWork.TeacherRepository.Remove(teacher);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Teacher Removed Successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Functions
        private IEnumerable<SelectListItem> GetSelectedItems()
        {
            return _unitOfWork.CourseRepository.GetAll().Select(course => new SelectListItem
            {
                Text = $"{course.Name} {course.Code}",
                Value = course.Id.ToString()
            });
        }
        #endregion



    }
}
