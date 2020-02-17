# Voice-Recognition-Attendance-Managment-System
Syed Huzaifa Sajjad, BSCS-F16-LC-163
namespace Attendance.Models
{
    public class Student
    {
        public int id { get; set; }
        [Display(Name="Name")]
        public string name { get; set; }
        [Display(Name = "Section")]
        public string section { get; set; }
        [Display(Name = "Roll Number")]
        public string rollno { get; set; }
        [Display(Name = "Profile Picture")]
        public string img_path { get; set; }


    public class StudentViewModel
    {
        public IEnumerable<Student> st_list { get; set; }
        public IEnumerable<Proxy> at_list { get; set; }
        public List<bool> proxy_list { get; set; }
        public Student students { get; set; }
        public string extra { get; set; }
       
    }


    public class Student
    {
        public int id { get; set; }
        [Display(Name="Name")]
        public string name { get; set; }
        [Display(Name = "Section")]
        public string section { get; set; }
        [Display(Name = "Roll Number")]
        public string rollno { get; set; }
        [Display(Name = "Profile Picture")]
        public string img_path { get; set; }


    public class StudentViewModel
    {
        public IEnumerable<Student> st_list { get; set; }
        public IEnumerable<Proxy> at_list { get; set; }
        public List<bool> proxy_list { get; set; }
        public Student students { get; set; }
        public string extra { get; set; }
       
    }
}

---------------------------------------------------------
    
@Html.Partial("_NavBar")
<div>
    @{
        if (@Model.extra != null && @Model.extra != "")
        {
            ViewBag.data = @Model.extra;
            <center class="alert alert-info">@Model.extra<a class='close' data-dismiss='alert'>&times;</a></center>
        }
    }
    <div class="content container-fluid">
        <div class="row">
            <div class="col-sm-4 col-xs-3">
                <h4 class="page-title">Students</h4>
            </div>
            <div class="col-sm-8 col-xs-9 text-right m-b-20">
                <a href="#" class="btn btn-primary rounded pull-right" data-toggle="modal" data-target="#add_client"><i class="fa fa-plus"></i> Add Student</a>

            </div>
        </div>
        <div class="row filter-row">
            <div class="col-sm-3 col-xs-6">
                <a type="button" class="btn btn-primary btn-block" data-toggle="collapse" href="#collapse">Switch</a>
                <ul id="collapse" class="list-group collapse">
                    <li class="list-group-item">@Html.ActionLink("Instructors", "Index", "User")</li>
                    <li class="list-group-item">@Html.ActionLink("Students", "StudentIndex", "User")</li>
                </ul>
            </div>

            @using (Html.BeginForm("SearchStudent", "User"))
            {
                <div class="col-sm-5 col-xs-6">

                    <div class="form-group form-focus">
                        <label for="searchstudent" class="control-label">Search Roll Number</label>
                        <input type="text" name="searchstudent" class="form-control floating" />
                    </div>

                </div>

                <div class="col-sm-4 col-xs-6">
                    <input type="submit" class="btn btn-success btn-block" value="Search">
                </div>
            }
        </div>
        <div class="row staff-grid-row">
            @foreach (var student in Model.st_list)
            {
                <div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
                    <div class="profile-widget">
                        <div class="profile-img">
                            <a href="#" class="avatar"><img src="@{@student.img_path}" /></a>
                        </div>
                        <div class="dropdown profile-action">
                            <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
                            <ul class="dropdown-menu pull-right">
                                <li>@Html.ActionLink((string)"Edit", "EditStudent", "User", new { id = (int)student.id }, null)</li>
                                <li>@Html.ActionLink((string)"Delete", "DeleteStudent", "User", new { id = (int)student.id }, null)</li>
                            </ul>
                        </div>
                        <h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="">@student.name</a></h4>
                        <h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="">@student.rollno</a></h5>
                        <div class="small text-muted">@student.section</div>

                    </div>
                </div>
            }
        </div>
    </div>
</div>
    



