using finaltry.Data;
using finaltry.models.entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Adjust namespace to match your project structure
using System.Linq;
using System.Threading.Tasks;

namespace n.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDBcontext _context;

        public StudentController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.students.ToListAsync();
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student object is null.");
            }

            try
            {
                _context.students.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
            }
            catch (DbUpdateException dbEx)
            {
                // Log database-related errors
                Console.WriteLine($"Database error: {dbEx.Message}");
                return StatusCode(500, "Database error occurred.");
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }



        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.StudentId == id);
        }
    }
}
