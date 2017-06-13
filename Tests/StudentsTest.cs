using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  [Collection("UniversityRegistrar")]
  public class StudentsTest : IDisposable
  {
    public StudentsTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=university_test; Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
     //Arrange, Act
     int result = Students.GetAll().Count;

     //Assert
     Assert.Equal(0, result);
    }




    public void Dispose()
    {
      Students.DeleteAll();
    }


  }
}
