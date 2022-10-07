
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.Concrete.ViewModels.TeacherVMs
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
    }
}
