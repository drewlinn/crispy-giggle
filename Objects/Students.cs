using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Students
  {
    private int _id;
    private string _name;
    private DateTime _enrollment;
    private string _major;

    public Students(string name, DateTime enrollment, string major, int id = 0)
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

    public override bool Equals(System.Object otherStudents)
    {
      if(!(otherStudents is Students))
      {
        return false;
      }
      else
      {
        Students newStudents = (Students) otherStudents;
        bool idEquality = (this.GetId() == newStudents.GetId());
        bool nameEquality = (this.GetName() == newStudents.GetName());
        bool enrollmentEquality = (this.GetEnrollment() == newStudents.GetEnrollment());
        bool majorEquality = (this.GetMajor() == newStudents.GetMajor());
        return (idEquality && nameEquality && majorEquality && enrollmentEquality);
      }
    }

    public static List<Students> GetAll()
    {
      List<Students> AllStudents = new List<Students>{};
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
        Students newStudent = new Students(name, enrollment, major, id);
        AllStudents.Add(newStudent);
      }
      if (rdr != null)
      {
       rdr.Close();
      }
      if (conn != null)
      {
       conn.Close();
      }
      return AllStudents;
    }

    // public void Save()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("INSERT INTO flights (flying_from, flying_to, depart, arrival, status) OUTPUT INSERTED.id VALUES (@flying_from, @flying_to, @depart, @arrival, @status);", conn);
    //
    //   SqlParameter fromPara = new SqlParameter("@flying_from", this.GetFlyingFrom());
    //   SqlParameter toPara = new SqlParameter("@flying_to", this.GetFlyingTo());
    //   SqlParameter departPara = new SqlParameter("@depart", this.GetDepart());
    //   SqlParameter arrivePara = new SqlParameter("@arrival", this.GetArrivalDate());
    //   SqlParameter StatusPara = new SqlParameter("@status", this.GetStatus());
    //
    //   cmd.Parameters.Add(fromPara);
    //   cmd.Parameters.Add(toPara);
    //   cmd.Parameters.Add(departPara);
    //   cmd.Parameters.Add(arrivePara);
    //   cmd.Parameters.Add(StatusPara);
    //
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   while(rdr.Read())
    //   {
    //     this._id = rdr.GetInt32(0);
    //   }
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    // }



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
