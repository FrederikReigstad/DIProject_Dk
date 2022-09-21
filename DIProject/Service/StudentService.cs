using DIProject.Interface;
using DIProject.Model;

namespace DIProject.Service;

public class StudentService
{
    private IStudentRepository _repository;
    public StudentService(IStudentRepository repository)
    {
        this._repository = repository;
    }


    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentException("Student cannot be null");
        }

        ThrowIfIsInvalid(student);
        
        _repository.Add(student);
    }

    private void ThrowIfIsInvalid(Student s)
    {
        if (s.ID <= 0)
        {
            throw new ArgumentException("ID Must be positive number");
        }

        if (s.Name == null)
        {
            throw new ArgumentException("Name Canot be null");
        }
        
        if (s.Name == "")
        {
            throw new ArgumentException("Name Canot be Empty");
        }

        if (s.Email == "")
        {
            throw new ArgumentException("Email Canot be Empty");
        }
    }
}