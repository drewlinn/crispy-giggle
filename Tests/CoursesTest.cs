using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  [Collection("UniversityRegistrar")]
  public class CourseTest : IDisposable
  {
    public CourseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=university_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CourseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Course.GetAll().Count;

      //Assertf
    }

    [Fact]
    public void Test_Save_SaveCourseToDatabase()
    {
      //Arrange
      Course testCourse = new Course("circuit design", "CS171", "No", "N/A");
      testCourse.Save();

      //Act
      List<Course> result = Course.GetAll();
      List<Course> testList = new List<Course>{testCourse};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsCourseInDatabase()
    {
      //Arrange
      Course testCourse = new Course("Beat Poetry", "Lit501", "Yes", "B");
      testCourse.Save();
      //Act
      Course foundCourse = Course.Find(testCourse.GetId());
      //Assert
      Assert.Equal(testCourse, foundCourse);
    }

    [Fact]
    public void Test_Update_UpdatesCourseInDatabase()
    {
      //Arrange
      Course testCourse = new Course("Sleepology", "SL101", "No", "F");
      testCourse.Save();
      string newGrade = "B+";
      //Act
      testCourse.Update("Sleepology", "SL101", "No", "B+");
      string result =testCourse.GetGrade();

      //Assert
      Assert.Equal(newGrade, result);
    }

    [Fact]
    public void Test_AddStudent_AddsStudentToCourse()
    {
      //Arrange
      Course testCourse = new Course("Sleepology", "SL101", "No", "F");
      testCourse.Save();

      Student testStudent = new Student("Expandrew", new DateTime(2016, 10, 20), "Game Art & Design");
      testStudent.Save();

      Student testStudent2 = new Student("Kimlan", new DateTime(2017, 02, 28), "Software Engineering");
      testStudent2.Save();

      //Act
      testCourse.AddStudent(testStudent);
      testCourse.AddStudent(testStudent2);

      List<Student> result = testCourse.GetStudent();
      List<Student> testList = new List<Student>{testStudent, testStudent2};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetStudent_ReturnsAllCourseStudent_StudentList()
    {
     //Arrange
     Course testCourse = new Course("Underwater Basketweaving", "UB107", "No", "N/A");
     testCourse.Save();

     Student testStudent1 = new Student("MaryAnne", new DateTime(2015, 05, 14), "Marine Biology");
     testStudent1.Save();

     Student testStudent2 = new Student("Garth", new DateTime(2014, 09, 05), "Literature");
     testStudent2.Save();

     //Act
     testCourse.AddStudent(testStudent1);
     List<Student> savedStudent = testCourse.GetStudent();
     List<Student> testList = new List<Student> {testStudent1};

     //Assert
     Assert.Equal(testList, savedStudent);
    }

    [Fact]
    public void Delete_DeletesCourseAssociationsFromDatabase_CourseList()
    {
      //Arrange
      Student testStudent = new Student("Expandrew", new DateTime(2016, 10, 20), "Game Art & Design");
      testStudent.Save();

      Course testCourse = new Course("Sleepology", "SL101", "No", "F");
      testCourse.Save();

      //Act
      testCourse.AddStudent(testStudent);
      testCourse.Delete();

      List<Course> resultStudentCourse = testStudent.GetCourses();
      List<Course> testStudentCourse = new List<Course> {};

      //Assert
      Assert.Equal(testStudentCourse, resultStudentCourse);
    }




    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
    }

  }
}
