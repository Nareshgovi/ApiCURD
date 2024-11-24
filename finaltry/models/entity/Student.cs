namespace finaltry.models.entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required DateTime EnrollmentDate { get; set; }
    }

}
