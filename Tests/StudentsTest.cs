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

    // [Fact]
    // public void Delete_DeletesStudentsAssociationsFromDatabase_StudentsList()
    // {
    //   //Arrange
    //   Course testCourse = new Course();
    //   testCourse.Save();
    //
    //   Students testStudents = new Students();
    //   testStudents.Save();
    //
    //   //Act
    //   testStudents.AddCourse(testCourse);
    //   testStudents.Delete();
    //
    //   List<Students> resultCourseStudents = testCourse.GetStudents();
    //   List<Students> testCourseStudents = new List<Students> {};
    //
    //   //Assert
    //   Assert.Equal(testCourseStudents, resultCourseStudents);
    // }





    public void Dispose()
    {
      Student.DeleteAll();
    }


  }
}
