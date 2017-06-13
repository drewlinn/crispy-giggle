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

    public static Student Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @id;", conn);
      SqlParameter idParameter = new SqlParameter("@id", id.ToString());

      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string name = null;
      DateTime enrollment = new DateTime();
      string major = null;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        enrollment = rdr.GetDateTime(2);
        major = rdr.GetString(3);
      }
      Student foundStudent = new Student(name, enrollment, major, foundId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundStudent;
    }

    public void Update(string name, DateTime enrollment, string major)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE students SET name = @name, enrollment = @enrollment, major = @major WHERE id = @Id;", conn);

      SqlParameter namePara = new SqlParameter("@name", name);
      SqlParameter enrollmentPara = new SqlParameter("@enrollment", enrollment);
      SqlParameter majorPara = new SqlParameter("@major", major);
      SqlParameter idPara = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(enrollmentPara);
      cmd.Parameters.Add(majorPara);
      cmd.Parameters.Add(idPara);

      this._name = name;
      this._enrollment = enrollment;
      this._major = major;
      cmd.ExecuteNonQuery();
      conn.Close();
    }


    public List<Course> GetCourses()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT courses.* FROM students JOIN courses_students ON (students.id = courses_students.students_id) JOIN courses ON (courses_students.courses_id = courses.id) WHERE students.id = @StudentsId;", conn);
      SqlParameter StudentsIdParam = new SqlParameter();
      StudentsIdParam.ParameterName = "@StudentsId";
      StudentsIdParam.Value = this.GetId().ToString();

      cmd.Parameters.Add(StudentsIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Course> courses = new List<Course>{};

      while(rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string course_number = rdr.GetString(2);
        string completion = rdr.GetString(3);
        string grade = rdr.GetString(4);
        Course newCourse = new Course(name, course_number, completion, grade, courseId);
        courses.Add(newCourse);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return courses;
    }

    public void AddCourse(Course newCourse)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses_students (courses_id, students_id) VALUES (@CourseId, @StudentId);", conn);

      SqlParameter studentIdParameter = new SqlParameter("@StudentId", this.GetId());
      SqlParameter courseIdParameter = new SqlParameter( "@CourseId", newCourse.GetId());

      cmd.Parameters.Add(studentIdParameter);
      cmd.Parameters.Add(courseIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE id = @studentId; DELETE FROM courses_students WHERE students_id = @studentId;", conn);
      SqlParameter studentIdParameter = new SqlParameter("@studentId", this.GetId());

      cmd.Parameters.Add(studentIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
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
