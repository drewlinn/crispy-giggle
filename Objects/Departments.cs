using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Department
  {
    private int _id;
    private string _name;

    public Department(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherDepartment)
    {
      if(!(otherDepartment is Department))
      {
        return false;
      }
      else
      {
        Department newDepartment = (Department) otherDepartment;
        bool idEquality = (this.GetId() == newDepartment.GetId());
        bool nameEquality = (this.GetName() == newDepartment.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static List<Department> GetAll()
    {
      List<Department> AllDepartment = new List<Department>{};
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM departments", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Department newDepartment = new Department(name, id);
        AllDepartment.Add(newDepartment);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
        if (conn != null)
      {
        conn.Close();
      }
      return AllDepartment;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO departments (name) OUTPUT INSERTED.id VALUES (@name);", conn);

      SqlParameter namePara = new SqlParameter("@name", this.GetName());

      cmd.Parameters.Add(namePara);

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

    public static Department Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM departments WHERE id = @id;", conn);
      SqlParameter idParameter = new SqlParameter("@id", id.ToString());

      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string name = null;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }
      Department foundDepartment = new Department(name, foundId);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundDepartment;
    }

    public void Update(string name)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE departments SET name = @name WHERE id = @Id;", conn);

      SqlParameter namePara = new SqlParameter("@name", name);
      SqlParameter idPara = new SqlParameter("@Id", this.GetId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(idPara);

      this._name = name;
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void AddCourse(Course newCourse)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO departments_courses (courses_id, departments_id) VALUES (@CourseId, @DepartmentId);", conn);

      SqlParameter departmentIdParameter = new SqlParameter("@DepartmentId", this.GetId());
      SqlParameter courseIdParameter = new SqlParameter( "@CourseId", newCourse.GetId());

      cmd.Parameters.Add(departmentIdParameter);
      cmd.Parameters.Add(courseIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public List<Course> GetCourses()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT courses.* FROM departments JOIN departments_courses ON (departments.id = departments_courses.departments_id) JOIN courses ON (departments_courses.courses_id = courses.id) WHERE departments.id = @DepartmentsId;", conn);
      SqlParameter DepartmentsIdParam = new SqlParameter();
      DepartmentsIdParam.ParameterName = "@DepartmentsId";
      DepartmentsIdParam.Value = this.GetId().ToString();

      cmd.Parameters.Add(DepartmentsIdParam);

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





    public static void DeleteAll()
    {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM departments;", conn);
     cmd.ExecuteNonQuery();
     conn.Close();
    }

  }
}
