using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace UniversityRegistrar
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/departments"] = _ => {
        List<Department> AllDepartments = Department.GetAll();
        return View["departments.cshtml", AllDepartments];
      };
      Get["/courses"] = _ => {
        List<Course> AllCourses = Course.GetAll();
        return View["courses.cshtml", AllCourses];
      };
      Get["/students"] = _ => {
        List<Student> AllStudents = Student.GetAll();
        return View["students.cshtml", AllStudents];
      };
      //CREATE
      Get["/departments/new"] = _ => {
        return View["department_form.cshtml"];
      };
      Get["/courses/new"] = _ => {
        return View["course_form.cshtml"];
      };
      Get["/students/new"] = _ => {
        List<Course> AllCourses = Course.GetAll();
        return View["student_form.cshtml", AllCourses];
      };
      Post["/departments/new"] = _ => {
        Department newDepartment = new Department (Request.Form["name"]);
        newDepartment.Save();
        return View["success.cshtml"];
      };
      Post["/courses/new"] = _ => {
        Course newCourse = new Course (Request.Form["name"], Request.Form["number"], Request.Form["completion"], Request.Form["grade"]);
        newCourse.Save();
        return View["success.cshtml"];
      };
      Post["/students/new"] = _ => {
        Student newStudent = new Student (Request.Form["name"], Request.Form["enrollment"], Request.Form["major"]);
        int courseId = Request.Form["course_id"];
        Course SelectedCourse = Course.Find(courseId);
        newStudent.Save();
        newStudent.AddCourse(SelectedCourse);
        SelectedCourse.AddStudent(newStudent);
        return View["success.cshtml"];
      };
      //READ
      Get["/departments/{id}"]= parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedDepartment = Department.Find(parameters.id);
        var StudentDepartment = selectedDepartment.GetStudent();
        var CourseDepartment = selectedDepartment.GetCourses();
        model.Add("department", selectedDepartment);
        model.Add("students", StudentDepartment);
        model.Add("courses", CourseDepartment);
        return View["department.cshtml", model];
      };
      Get["/courses/{id}"]= parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCourse = Course.Find(parameters.id);
        var StudentCourse = selectedCourse.GetStudent();
        model.Add("course", selectedCourse);
        model.Add("students", StudentCourse);
        return View["course.cshtml", model];
      };
      Get["/students/{id}"] = parameters => {
       Dictionary<string, object> model = new Dictionary<string, object>();
       var selectedStudent = Student.Find(parameters.id);
       var selectedCourse = selectedStudent.GetCourses();
       model.Add("course", selectedCourse);
       model.Add("students", selectedStudent);
       return View["student.cshtml", model];
      };
      //UPDATE
      Get["/departments/edit/{id}"] = parameters => {
        Department SelectedDepartment = Department.Find(parameters.id);
        return View["department_edit.cshtml", SelectedDepartment];
      };
      Patch["/departments/edit/{id}"] = parameters =>{
        Department SelectedDepartment = Department.Find(parameters.id);
        SelectedDepartment.Update(Request.Form["name"]);
        return View["success.cshtml"];
      };
      Get["/courses/edit/{id}"] = parameters => {
        Course SelectedCourse = Course.Find(parameters.id);
        return View["course_edit.cshtml", SelectedCourse];
      };
      Patch["/courses/edit/{id}"] = parameters =>{
        Course SelectedCourse = Course.Find(parameters.id);
        SelectedCourse.Update(Request.Form["name"], Request.Form["number"], Request.Form["completion"], Request.Form["grade"]);
        return View["success.cshtml"];
      };
      Get["/students/edit/{id}"] = parameters => {
       Student selectedStudent = Student.Find(parameters.id);
       return View["student_edit.cshtml", selectedStudent];
      };
      Patch["/students/edit/{id}"] = parameters =>{
        Student SelectedStudent = Student.Find(parameters.id);
        SelectedStudent.Update(Request.Form["name"], Request.Form["enrollment"], Request.Form["major"]);
        return View["success.cshtml"];
      };

      //DESTROY
      Get["departments/delete/{id}"] = parameters => {
       Department SelectedDepartment = Department.Find(parameters.id);
       return View["department_delete.cshtml", SelectedDepartment];
      };
      Delete["departments/delete/{id}"] = parameters => {
        Department SelectedDepartment = Department.Find(parameters.id);
        SelectedDepartment.Delete();
        return View["success.cshtml"];
      };
      Get["courses/delete/{id}"] = parameters => {
       Course SelectedCourse = Course.Find(parameters.id);
       return View["course_delete.cshtml", SelectedCourse];
      };
      Delete["courses/delete/{id}"] = parameters => {
        Course SelectedCourse = Course.Find(parameters.id);
        SelectedCourse.Delete();
        return View["success.cshtml"];
      };
      Get["students/delete/{id}"] = parameters => {
        Student SelectedStudent = Student.Find(parameters.id);
        return View["student_delete.cshtml", SelectedStudent];
      };
      Delete["students/delete/{id}"] = parameters => {
        Student SelectedStudent = Student.Find(parameters.id);
        SelectedStudent.Delete();
        return View["success.cshtml"];
      };

    }
  }
}
