using DataAccess.Repository.Abstract;
using DataAccess.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Concrete;
using Models.Concrete.ViewModels.ExamGradeVMs;

namespace WebUI.Controllers
{
    public class GradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ExamGradeFullViewModel model = new()
            {
                ExamGradeList = _unitOfWork.ExamGradeRepository.GetAll().OrderBy(x => x.StudentId),
                StudentList = _unitOfWork.StudentRepository.GetAll(),
                TeacherList = _unitOfWork.TeacherRepository.GetAll(),
                CourseList = _unitOfWork.CourseRepository.GetAll(),
            };
            return View(model);
        }

        public IActionResult GetListByStudentId(int id)
        { 
            ExamGradeByStudentIdViewModel model = new()
            {
                ExamGradeList = _unitOfWork.ExamGradeRepository.GetAll(eg => eg.StudentId == id),
                CourseList = _unitOfWork.StudentRepository.GetStudentCourseList(id),
                Student = _unitOfWork.StudentRepository.GetFirstOrDefault(s => s.Id == id)
        };
            return View(model);
        }
        public IActionResult GetListByTeacherId(int id)
        {
            var teacherExamGradeList = _unitOfWork.ExamGradeRepository.GetAll(eg => eg.TeacherId == id);
            return View(teacherExamGradeList);
        }
        public IActionResult GetListByCourseId(int id)
        {
            var courseExamGradeList = _unitOfWork.ExamGradeRepository.GetAll(eg => eg.CourseId == id);
            return View(courseExamGradeList);
        }

        #region Teacher Add - Update - Delete Exam Grade Codes : Will be removed after Indentity Section integrated
        //#region Add => GET - POST
        //public IActionResult Add(int? id)
        //{
        //    var teacher = _unitOfWork.TeacherRepository.GetFirstOrDefault(t => t.Id == id);

        //    ExamGradeAddViewModel model = new()
        //    {
        //        ExamGrade = new()
        //        {
        //            Teacher = teacher,
        //            Course = teacher.Course
        //        },
        //        StudentList = GetSelectedItems()
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add(ExamGrade examGrade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.ExamGradeRepository.Add(examGrade);
        //        await _unitOfWork.SaveAsync();
        //        TempData["success"] = "Exam Grade Added Successfully";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    TempData["error"] = "Process Failed";
        //    return RedirectToAction(nameof(Index));
        //}
        //#endregion


        //#region Edit => GET - POST
        //public IActionResult Edit(int id)
        //{
        //    var examGrade = _unitOfWork.ExamGradeRepository.GetFirstOrDefault(s => s.Id == id);
        //    return View(examGrade);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(ExamGrade examGrade)
        //{
        //    _unitOfWork.ExamGradeRepository.Update(examGrade);
        //    await _unitOfWork.SaveAsync();
        //    TempData["success"] = "Exam Grade Updated Successfully";
        //    return RedirectToAction(nameof(Index));
        //}
        //#endregion


        //#region Delete => GET - POST
        //public IActionResult Delete(int id)
        //{
        //    var examGrade = _unitOfWork.ExamGradeRepository.GetFirstOrDefault(s => s.Id == id);
        //    return View(examGrade);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(ExamGrade examGrade)
        //{
        //    _unitOfWork.ExamGradeRepository.Remove(examGrade);
        //    await _unitOfWork.SaveAsync();
        //    TempData["success"] = "Exam Grade Removed Successfully";
        //    return RedirectToAction(nameof(Index));
        //}
        //#endregion
        #endregion


    }
}
