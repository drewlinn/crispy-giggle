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

    public static Course Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE id = @id;", conn);
      SqlParameter IdPara = new SqlParameter("@id", id.ToString());
      cmd.Parameters.Add(IdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundid = 0;
      string name = null;
      string course_number = null;
      string completion = null;
      string grade = null;

      while(rdr.Read())
      {
        foundid = rdr.GetInt32(0);
        name = rdr.GetString(1);
        course_number = rdr.GetString(2);
        completion = rdr.GetString(3);
        grade = rdr.GetString(4);
      }
      Course foundCourse = new Course(name, course_number, completion, grade, foundid);
      if (rdr != null)
      {
       rdr.Close();
      }
      if (conn != null)
      {
       conn.Close();
      }
     return foundCourse;
    }

    public void Update(string name, string course_number, string completion, string grade)
    {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("UPDATE courses SET name = @name, course_number = @course_number, completion = @completion, grade = @grade WHERE id = @Id;", conn);

    SqlParameter namePara = new SqlParameter("@name", name);
    SqlParameter coursePara = new SqlParameter("@course_number", course_number);
    SqlParameter completionPara = new SqlParameter("@completion", completion);
    SqlParameter gradePara = new SqlParameter("@grade", grade);
    SqlParameter idPara = new SqlParameter("@Id", this.GetId());

    cmd.Parameters.Add(namePara);
    cmd.Parameters.Add(coursePara);
    cmd.Parameters.Add(completionPara);
    cmd.Parameters.Add(gradePara);
    cmd.Parameters.Add(idPara);

    this._name = name;
    this._course_number = course_number;
    this._completion = completion;
    this._grade = grade;
    cmd.ExecuteNonQuery();
    conn.Close();
    }
    //Add student's id and course's id to courses_students table
    public void AddStudent(Student newStudent)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO courses_students (courses_id, students_id) VALUES (@CourseId, @StudentId);", conn);

      SqlParameter courseIdParameter = new SqlParameter("@CourseId", this.GetId());
      SqlParameter studentIdParameter = new SqlParameter( "@StudentId", newStudent.GetId());

      cmd.Parameters.Add(courseIdParameter);
      cmd.Parameters.Add(studentIdParameter);
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

      SqlCommand cmd = new SqlCommand("DELETE FROM courses WHERE id = @Id; DELETE FROM courses_students WHERE courses_id = @Id;", conn);
      SqlParameter IdParameter = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(IdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Student> GetStudent()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT students.* FROM courses JOIN courses_students ON (courses.id = courses_students.courses_id) JOIN students ON (courses_students.students_id = students.id) WHERE courses.id = @courseId;", conn);
      SqlParameter CourseIdParam = new SqlParameter("@courseId", this.GetId().ToString());

      cmd.Parameters.Add(CourseIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Student> students = new List<Student>{};
    
      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime enrollment = rdr.GetDateTime(2);
        string major = rdr.GetString(3);
      Student newStudent = new Student(name, enrollment, major, studentId);
        students.Add(newStudent);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return students;
    }




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
