using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  [Collection("UniversityRegistrar")]
  public class DepartmentTest : IDisposable
  {
    public DepartmentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=university_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DepartmentEmptyAtFirst()
    {
      //Arrange, Act
      int result = Department.GetAll().Count;

      //Assertf
    }

    [Fact]
    public void Test_Save_SaveDepartmentToDatabase()
    {
      //Arrange
      Department testDepartment = new Department("computer science");
      testDepartment.Save();

      //Act
      List<Department> result = Department.GetAll();
      List<Department> testList = new List<Department>{testDepartment};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsDepartmentInDatabase()
    {
      //Arrange
      Department testDepartment = new Department("Beat Poetry");
      testDepartment.Save();
      //Act
      Department foundDepartment = Department.Find(testDepartment.GetId());
      //Assert
      Assert.Equal(testDepartment, foundDepartment);
    }

    [Fact]
    public void Test_Update_UpdatesDepartmentInDatabase()
    {
      //Arrange
      Department testDepartment = new Department("Sleepology");
      testDepartment.Save();
      string newName= "Beat Poetry";
      //Act
      testDepartment.Update("Beat Poetry");
      string result =testDepartment.GetName();

      //Assert
      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_AddCourse_AddsCourseToDepartment()
    {
      //Arrange
      Department testDepartment = new Department("science");
      testDepartment.Save();

      Course testCourse = new Course("Sleepology", "SL101", "No", "F");
      testCourse.Save();

      Course testCourse2 = new Course("Underwater Basketweaving", "UB107", "No", "N/A");
      testCourse2.Save();

      //Act
      testDepartment.AddCourse(testCourse);
      testDepartment.AddCourse(testCourse2);

      List<Course> result = testDepartment.GetCourses();
      List<Course> testList = new List<Course>{testCourse, testCourse2};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void GetCourses_ReturnsAllDepartmentCourses_CourseList()
    {
      //Arrange
      Department testDepartment = new Department("Expandrew");
      testDepartment.Save();

      Course testCourses1 = new Course("Underwater Basketweaving", "UB107", "No", "N/A");
      testCourses1.Save();

      Course testCourses2 = new Course("Sleepology", "SL101", "No", "F");
      testCourses2.Save();

      //Act
      testDepartment.AddCourse(testCourses1);
      List<Course> result = testDepartment.GetCourses();
      List<Course> testList = new List<Course> {testCourses1};

      //Assert
      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Department.DeleteAll();
    }
  }
}
