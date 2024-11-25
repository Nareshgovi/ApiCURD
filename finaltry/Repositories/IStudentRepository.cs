using finaltry.models.entity;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int id);
    Task<bool> StudentExistsAsync(int id);
}
