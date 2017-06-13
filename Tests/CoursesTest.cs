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

    // [Fact]
    // public void Test_Find_FindsCourseInDatabase()
    // {
    //   //Arrange
    //   Course testCourse = new Course("eva");
    //   testCourse.Save();
    //   //Act
    //   Course foundCourse = Course.Find(testCourse.GetId());
    //   //Assert
    //   Assert.Equal(testCourse, foundCourse);
    // }
    //
    // [Fact]
    // public void Delete_DeletesCourseAssociationsFromDatabase_Courseist()
    // {
    //   //Arrange
    //   Student testStudent = new Student("portland", "New York", "today", "tomorrow", "on time");
    //   testStudent.Save();
    //
    //   Course testCourse = new Course("eva");
    //   testCourse.Save();
    //
    //   //Act
    //   testCourse.AddStudent(testStudent);
    //   testCourse.Delete();
    //
    //   List<Course> resultStudentCategories = testStudent.GetCourse();
    //   List<Course> testStudentCategories = new List<Course> {};
    //
    //   //Assert
    //   Assert.Equal(testStudentCategories, resultStudentCategories);
    // }
    //
    // [Fact]
    // public void Test_AddStudent_AddsStudentToCourse()
    // {
    //  //Arrange
    //  Course testCourse = new Course("eva");
    //  testCourse.Save();
    //
    //  Student testStudent = new Student("portland", "New York", "today", "tomorrow", "on time");
    //  testStudent.Save();
    //
    //  Student testStudent2 = new Student("Seattle", "New York", "today", "tomorrow", "on time");
    //  testStudent2.Save();
    //
    //  //Act
    //  testCourse.AddStudent(testStudent);
    //  testCourse.AddStudent(testStudent2);
    //
    //  List<Student> result = testCourse.GetStudent();
    //  List<Student> testList = new List<Student>{testStudent, testStudent2};
    //
    //  //Assert
    //  Assert.Equal(testList, result);
    // }
    //
    // [Fact]
    // public void GetStudent_ReturnsAllCourseStudent_TaskList()
    // {
    //  //Arrange
    //  Course testCourse = new Course("eva");
    //  testCourse.Save();
    //
    //  Student testStudent1 = new Student("portland", "New York", "today", "tomorrow", "on time");
    //  testStudent1.Save();
    //
    //  Student testStudent2 = new Student("Seattle", "New York", "today", "tomorrow", "on time");
    //  testStudent2.Save();
    //
    //  //Act
    //  testCourse.AddStudent(testStudent1);
    //  List<Student> savedStudent = testCourse.GetStudent();
    //  List<Student> testList = new List<Student> {testStudent1};
    //
    //  //Assert
    //  Assert.Equal(testList, savedStudent);
    // }


    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
    }

  }
}
