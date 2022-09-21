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
            throw new AggregateException("Student cannot be null");
        }
        _repository.Add(student);
    }
}