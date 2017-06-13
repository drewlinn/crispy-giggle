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

    public void Dispose()
    {
      Department.DeleteAll();
    }
  }
}
