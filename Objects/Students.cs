using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Student
  {
    private int _id;
    private string _name;
    private DateTime _enrollment;
    private string _major;

    public Student(string name, DateTime enrollment, string major, int id = 0)
    {
      _name = name;
      _enrollment = enrollment;
      _major = major;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public DateTime GetEnrollment()
    {
      return _enrollment;
    }
    public string GetMajor()
    {
      return _major;
    }

    public override bool Equals(System.Object otherStudent)
    {
      if(!(otherStudent is Student))
      {
        return false;
      }
      else
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = (this.GetId() == newStudent.GetId());
        bool nameEquality = (this.GetName() == newStudent.GetName());
        bool enrollmentEquality = (this.GetEnrollment() == newStudent.GetEnrollment());
        bool majorEquality = (this.GetMajor() == newStudent.GetMajor());
        return (idEquality && nameEquality && majorEquality && enrollmentEquality);
      }
    }

    public static List<Student> GetAll()
    {
      List<Student> AllStudent = new List<Student>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime enrollment = rdr.GetDateTime(2);
        string major = rdr.GetString(3);
        Student newStudent = new Student(name, enrollment, major, id);
        AllStudent.Add(newStudent);
      }
      if (rdr != null)
      {
       rdr.Close();
      }
      if (conn != null)
      {
       conn.Close();
      }
      return AllStudent;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students (name, enrollment, major) OUTPUT INSERTED.id VALUES (@name, @enrollment, @major);", conn);

      SqlParameter namePara = new SqlParameter("@name", this.GetName());
      SqlParameter enrollment = new SqlParameter("@enrollment", this.GetEnrollment());
      SqlParameter majorPara = new SqlParameter("@major", this.GetMajor());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(enrollment);
      cmd.Parameters.Add(majorPara);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }



    public static void DeleteAll()
    {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
     cmd.ExecuteNonQuery();
     conn.Close();
    }
  }
}
