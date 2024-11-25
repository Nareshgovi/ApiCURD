using finaltry.Data;
using finaltry.models.entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentRepository : IStudentRepository
{
    private readonly AppDBcontext _context;

    public StudentRepository(AppDBcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _context.students.ToListAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _context.students.FindAsync(id);
    }

    public async Task AddStudentAsync(Student student)
    {
        _context.students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await GetStudentByIdAsync(id);
        if (student != null)
        {
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> StudentExistsAsync(int id)
    {
        return await _context.students.AnyAsync(e => e.StudentId == id);
    }
}
