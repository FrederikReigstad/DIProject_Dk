using DIProject.Model;

namespace DIProject.Interface;

public interface IStudentRepository
{
    /// <summary>
    /// find a stundent by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Student GetById(int id);
    /// <summary>
    /// gets all students 
    /// </summary>
    /// <returns></returns>
    List<Student> GetAll();

    void Add(Student s);
    
    void Update(Student s);
    
    void Delete(Student s);
}