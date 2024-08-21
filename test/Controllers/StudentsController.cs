using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentIdentity viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.StudID);

            if(student is not null)
            {
                student.StudName = viewModel.StudName;
                student.StudEmail = viewModel.StudEmail;
                student.StudPhone = viewModel.StudPhone;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentIdentity viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StudID == viewModel.StudID);

            if(student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

			return RedirectToAction("List", "Students");
		}
    }
}
