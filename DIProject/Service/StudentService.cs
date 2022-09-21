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
        _repository.Add(student);
    }
}