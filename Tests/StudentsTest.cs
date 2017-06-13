using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  [Collection("UniversityRegistrar")]
  public class StudentTest : IDisposable
  {
    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=university_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
     //Arrange, Act
     int result = Student.GetAll().Count;

     //Assert
     Assert.Equal(0, result);
    }


    [Fact]
    public void Test_Save_SavesToDatabase()
    {
     //Arrange
    Student testStudent = new Student("Kimlan", new DateTime(2017, 02, 28), "Software Engineering");

     //Act
     testStudent.Save();
     List<Student> result =Student.GetAll();
     List<Student> testList = new List<Student>{testStudent};

     //Assert
     Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindStudentInDatabase()
    {
      //Arrange
      Student testStudent = new Student("Expandrew", new DateTime(2016, 10, 20), "Game Art & Design");
      testStudent.Save();

      //Act
      Student foundStudent = Student.Find(testStudent.GetId());

      //Assert
      Assert.Equal(testStudent, foundStudent);
    }

    [Fact]
    public void GetCourses_ReturnsAllStudentCourses_CourseList()
    {
      //Arrange
      Student testStudent = new Student("Expandrew", new DateTime(2016, 10, 20), "Game Art & Design");
      testStudent.Save();

      Course testCourses1 = new Course("Underwater Basketweaving", "UB107", "No", "N/A");
      testCourses1.Save();

      Course testCourses2 = new Course("Sleepology", "SL101", "No", "F");
      testCourses2.Save();

      //Act
      testStudent.AddCourse(testCourses1);
      List<Course> result = testStudent.GetCourses();
      List<Course> testList = new List<Course> {testCourses1};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Update_UpdatesStudentInDatabase()
    {
      //Arrange
      Student testStudent = new Student("Steven", new DateTime(1984, 12, 25), "Gun Economics");
      testStudent.Save();
      string newMajor = "Performance Art";
      //Act
      testStudent.Update("Steven", new DateTime(1984, 12, 25), "Performance Art");
      string result =testStudent.GetMajor();

      //Assert
      Assert.Equal(newMajor, result);
    }

    [Fact]
    public void AddCourses_AddsCoursesToStudent_CoursesList()
    {
      //Arrange
      Student testStudent = new Student("Steven", new DateTime(1984, 12, 25), "Gun Economics");
      testStudent.Save();

      Course testCourses = new Course("Sleepology", "SL101", "No", "F");
      testCourses.Save();

      //Act
      testStudent.AddCourse(testCourses);

      List<Course> result = testStudent.GetCourses();
      List<Course> testList = new List<Course>{testCourses};

      //Assert

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Delete_DeletesStudentsAssociationsFromDatabase_StudentsList()
    {
      //Arrange
      Course testCourse = new Course("Sleepology", "SL101", "No", "F");
      testCourse.Save();

      Student testStudents = new Student("Steven", new DateTime(1984, 12, 25), "Gun Economics");
      testStudents.Save();

      //Act
      testStudents.AddCourse(testCourse);
      testStudents.Delete();

      List<Student> resultCourseStudents = testCourse.GetStudent();
      List<Student> testCourseStudents = new List<Student> {};

      //Assert
      Assert.Equal(testCourseStudents, resultCourseStudents);
    }





    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
      Department.DeleteAll();
    }


  }
}
