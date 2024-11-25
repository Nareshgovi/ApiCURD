using finaltry.models.entity;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _repository.GetAllStudentsAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _repository.GetStudentByIdAsync(id);
    }

    public async Task AddStudentAsync(Student student)
    {
        await _repository.AddStudentAsync(student);
    }

    public async Task UpdateStudentAsync(int id, Student student)
    {
        if (id != student.StudentId)
        {
            throw new ArgumentException("Student ID mismatch.");
        }

        if (!await _repository.StudentExistsAsync(id))
        {
            throw new KeyNotFoundException("Student not found.");
        }

        await _repository.UpdateStudentAsync(student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        if (!await _repository.StudentExistsAsync(id))
        {
            throw new KeyNotFoundException("Student not found.");
        }

        await _repository.DeleteStudentAsync(id);
    }
}
