using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace UniversityRegistrar
{
  public class Course
  {
    private int _id;
    private string _name;
    private string _course_number;
    private string _completion;
    private string _grade;

    public Course (string name, string course_number, string completion, string grade, int id = 0)
    {
      _name = name;
      _course_number = course_number;
      _completion = completion;
      _grade = grade;
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
    public string GetCompletion()
    {
      return _completion;
    }
    public string GetCourseNumber()
    {
      return _course_number;
    }
    public string GetGrade()
    {
      return _grade;
    }

    public override bool Equals(System.Object otherCourse)
    {
     if(!(otherCourse is Course))
     {
       return false;
     }
     else
      {
       Course newCourse = (Course) otherCourse;
       bool idEquality = (this.GetId() == newCourse.GetId());
       bool nameEquality = (this.GetName() == newCourse.GetName());
       bool courseNumberEquality = (this.GetCourseNumber() == newCourse.GetCourseNumber());
       bool completionEquality = (this.GetCompletion() == newCourse.GetCompletion());
       bool gradeEquality = (this.GetGrade() == newCourse.GetGrade());
       return (idEquality && nameEquality && courseNumberEquality && completionEquality && gradeEquality);
      }
    }

    public static List<Course> GetAll()
    {
      List<Course> AllCourse = new List<Course>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string course_number = rdr.GetString(2);
        string completion = rdr.GetString(3);
        string grade = rdr.GetString(4);
        Course newCourse = new Course(name, course_number, completion, grade, id);
        AllCourse.Add(newCourse);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllCourse;
    }

    public void Save()
    {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("INSERT INTO courses (name, course_number, completion, grade) OUTPUT INSERTED.id VALUES (@name, @course_number, @completion, @grade);", conn);

     SqlParameter namePara = new SqlParameter("@name", this.GetName());
     SqlParameter coursePara = new SqlParameter("@course_number", this.GetCourseNumber());
     SqlParameter completPara = new SqlParameter("@completion", this.GetCompletion());
     SqlParameter gradePara = new SqlParameter("@grade", this.GetGrade());

     cmd.Parameters.Add(namePara);
     cmd.Parameters.Add(coursePara);
     cmd.Parameters.Add(completPara);
     cmd.Parameters.Add(gradePara);
     SqlDataReader rdr = cmd.ExecuteReader();

     while(rdr.Read())
     {
       this._id = rdr.GetInt32(0);
     }
     if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }
    }

    // public static Course Find(int id)
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT * FROM airline_services WHERE id = @id;", conn);
    //   SqlParameter airlineIdPara = new SqlParameter("@id", id.ToString());
    //   cmd.Parameters.Add(airlineIdPara);
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   int foundid = 0;
    //   string foundAirlineName = null;
    //
    //   while(rdr.Read())
    //   {
    //     foundid = rdr.GetInt32(0);
    //     foundAirlineName = rdr.GetString(1);
    //   }
    //   Course foundCourse = new Course(foundAirlineName, foundid);
    //   if (rdr != null)
    //   {
    //    rdr.Close();
    //   }
    //   if (conn != null)
    //   {
    //    conn.Close();
    //   }
    //  return foundCourse;
    // }
    //
    // public void Delete()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("DELETE FROM airline_services WHERE id = @airlineId; DELETE FROM summary WHERE airline_services_id = @airlineId;", conn);
    //   SqlParameter airlineIdParameter = new SqlParameter("@airlineId", this.GetId());
    //
    //   cmd.Parameters.Add(airlineIdParameter);
    //   cmd.ExecuteNonQuery();
    //
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    // }
    //
    // public void AddStudent(Student newStudent)
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("INSERT INTO summary (airline_services_id, student_id) VALUES (@AirlineId, @StudentId);", conn);
    //
    //   SqlParameter airlineIdParameter = new SqlParameter("@AirlineId", this.GetId());
    //   SqlParameter studentIdParameter = new SqlParameter( "@StudentId", newStudent.GetId());
    //
    //   cmd.Parameters.Add(airlineIdParameter);
    //   cmd.Parameters.Add(studentIdParameter);
    //   cmd.ExecuteNonQuery();
    //   if (conn != null)
    //   {
    //    conn.Close();
    //   }
    // }
    //
    // public List<Student> GetStudent()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT student_id FROM summary WHERE airline_services_id = @airline_id;", conn);
    //   SqlParameter airlineIdParameter = new SqlParameter("@airline_Id", this.GetId());
    //
    //   cmd.Parameters.Add(airlineIdParameter);
    //   SqlDataReader rdr = cmd.ExecuteReader();
    //
    //   List<int> studentId = new List<int> {};
    //   while(rdr.Read())
    //   {
    //     int studentId = rdr.GetInt32(0);
    //     studentId.Add(studentId);
    //   }
    //   if (rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //
    //   List<Student> allStudent = new List<Student> {};
    //   foreach (int studentId in studentId)
    //   {
    //     SqlCommand studentQuery = new SqlCommand("SELECT * FROM student WHERE id = @StudentId;", conn);
    //
    //     SqlParameter studentIdParameter = new SqlParameter("@StudentId", studentId);
    //
    //     studentQuery.Parameters.Add(studentIdParameter);
    //     SqlDataReader queryReader = studentQuery.ExecuteReader();
    //     while(queryReader.Read())
    //     {
    //           int thisStudentId = queryReader.GetInt32(0);
    //           string flying_from = queryReader.GetString(1);
    //           string flying_to = queryReader.GetString(2);
    //           string depart = queryReader.GetString(3);
    //           string arrival = queryReader.GetString(4);
    //           string status = queryReader.GetString(5);
    //           Student foundStudent = new Student(flying_from, flying_to, depart, arrival, status, thisStudentId);
    //           allStudent.Add(foundStudent);
    //     }
    //     if (queryReader != null)
    //     {
    //       queryReader.Close();
    //     }
    //   }
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return allStudent;
    // }




    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM courses;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
