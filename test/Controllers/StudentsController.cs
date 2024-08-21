using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;
using test.Models.Entities;

namespace test.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public StudentsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel){

            var student = new StudentIdentity
            {
                StudName = viewModel.StudName,
                StudEmail = viewModel.StudEmail,
                StudPhone = viewModel.StudPhone,
                StudID = viewModel.StudID,
            };


            await dbContext.Students.AddAsync(student);

            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
