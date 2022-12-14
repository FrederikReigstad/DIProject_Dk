using DIProject.Interface;
using DIProject.Model;
using DIProject.Service;
using Moq;

namespace DIProject_Dk;

public class StudentServiceTest
{
    [Fact]
    public void CreateStudentService()
    {
        // Arrange
        Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        
        // Act
        StudentService s = new StudentService(mockRepository.Object);
        
        // Assert
        Assert.NotNull(s);
        Assert.True(s is StudentService);
    }

    [Fact]
    public void AddValidStudent()
    {
        // Arrange
        List<Student> data = new List<Student>();
        Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        mockRepository.Setup(r => r.Add(It.IsAny<Student>())).Callback<Student>(s => data.Add(s));
        StudentService service = new StudentService(mockRepository.Object);
        Student student = new Student(1,"mads","madsman@gmail.com");
        
        
        // Act
        service.AddStudent(student);
        

        // Assert
        Assert.True(data.Count == 1);
        Assert.Equal(student, data[0]);
        mockRepository.Verify(r =>r.Add(student), Times.Once);
    }

    [Fact]
    public void AddIsNullStudentExpectArgumentException()
    {
        // Arrange
        //The Mok of the Repository
        Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        //  StudentServise whit injected MockRepositoy (Rember to use .Object)
        StudentService service = new StudentService(mockRepository.Object);
        
        // Act
        var action = () => service.AddStudent(null);
        
        // Assert
        var  ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Student cannot be null",ex.Message);
        mockRepository.Verify(r => r.Add(null), Times.Never);
        
    }

    [Theory]
    [InlineData(-1, "Name", "Email", "ID Must be positive number")]
    [InlineData(0, "Name", "Email", "ID Must be positive number")]
    [InlineData(1, null, "Email", "Name Canot be null")]
    [InlineData(1, "", "Email", "Name Canot be Empty")]
    [InlineData(1, "Name", "","Email Canot be Empty")]
    public void AddIncalidStudentExpectArgumentException(int id, string name, string email, string expectedMessage )
    {
        // Arrange
        //The Mok of the Repository
        Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        //  StudentServise whit injected MockRepositoy (Rember to use .Object)
        StudentService service = new StudentService(mockRepository.Object);
        Student student = new Student(id, name, email);

        // Act
        var action = () => service.AddStudent(student);
        
        // Assert
        var  ex = Assert.Throws<ArgumentException>(action);
        Assert.Equal(expectedMessage,ex.Message);
        mockRepository.Verify(r => r.Add(student), Times.Never);
    }
    
}