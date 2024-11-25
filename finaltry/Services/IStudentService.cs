using finaltry.models.entity;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(int id, Student student);
    Task DeleteStudentAsync(int id);
}
