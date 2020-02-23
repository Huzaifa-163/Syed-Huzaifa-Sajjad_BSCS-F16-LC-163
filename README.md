# Voice-Recognition-Attendance-Managment-System
Syed Huzaifa Sajjad, BSCS-F16-LC-163

-----------------------week-9------------------------------


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


______________________________
    

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
    
-----------------------week-10------------------------------

public class Instructor
    {
        public int? id { get; set; }
        [Display(Name="Name")]
        [Required]
        public string name { get; set; }
        [Display(Name = "User-Name")]
        //[UniqueInstructorName]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string password { get; set; }
        [Display(Name = "Section")]
        public string section { get; set; }
        public string subject { get; set; }
        public string image_path { get; set; }
    }

 public class InstructorViewModel
    {
        public IEnumerable <Instructor> Inst_list { get; set; }
        public Instructor Instructors { get; set; }
        [Display(Name = "Re-Enter Password")]
        public string repassword { get; set; }
        public string extra { get; set; }
        public HttpPostedFileBase imageFile;
    }

public class InstructorEditModel
    {
        public int? id { get; set; }
        [Display(Name = "Name")]
      
        public string name { get; set; }
        [Display(Name = "User-Name")]
        
        public string username { get; set; }
        [Display(Name = "Password")]
       
        public string password { get; set; }
        [Display(Name = "Section")]
        public string section { get; set; }
        [Display(Name = "Subject")]
        public string subject { get; set; }
        [Display(Name = "Profile Picture")]
        public string image_path { get; set; }
        [Display(Name = "Re-Enter Password")]
        public string repassword { get; set; }
    }
    ____________________________
    
    @model Attendance.ViewModels.InstructorViewModel
@{
    ViewBag.Title = "Instructor";
}
@{
    List<SelectListItem> listItems = new List<SelectListItem>();
    listItems.Add(new SelectListItem
    {
        Text = "BS(CS)",
        Value = "BS(CS)"
    });
    listItems.Add(new SelectListItem
    {
        Text = "BS(SE)",
        Value = "BS(SE)",
        Selected = true
    });
    listItems.Add(new SelectListItem
    {
        Text = "BS(IT)",
        Value = "BS(IT)"
    });
}
@{
    List<SelectListItem> listItems1 = new List<SelectListItem>();
    listItems1.Add(new SelectListItem
    {
        Text = "PF",
        Value = "PF"
    });
    listItems1.Add(new SelectListItem
    {
        Text = "OOP",
        Value = "OOP",

    });
    listItems1.Add(new SelectListItem
    {
        Text = "DSA",
        Value = "DSA"
    });
}
@Html.Partial("_NavBar")
<div>
    @{
        if (@Model.extra != "" && @Model.extra != null)
        {
            ViewBag.data = @Model.extra;
            <center class="alert alert-info">@Model.extra<a class='close' data-dismiss='alert'>&times;</a></center>
        }
    }
    <div class="content container-fluid">
        <div class="row">
            <div class="col-sm-4 col-xs-3">
                <h4 class="page-title">Instructors</h4>
            </div>
            <div class="col-sm-8 col-xs-9 text-right m-b-20">
                <a href="#" class="btn btn-primary rounded pull-right" style="margin-left: 1%" data-toggle="modal" data-target="#add_client"><i class="fa fa-plus"></i> Add Instructor</a>
                @Html.ActionLink("Add Admin", "Signup", "User", new { @class = "btn btn-primary  rounded"})

            </div>
        </div>
        <div class="row filter-row">
            <div class="col-sm-3 col-xs-6">
                <a type="button" class="btn btn-primary btn-block" data-toggle="collapse" href="#collapse">Switch</a>
                <ul id ="collapse" class="list-group collapse">
                    <li class="list-group-item">@Html.ActionLink("Instructors", "Index", "User")</li>
                    <li class="list-group-item">@Html.ActionLink("Students", "StudentIndex", "User")</li>
                </ul>
            </div>
            
        @using (Html.BeginForm("Search", "User"))
        {
            <div class="col-sm-5 col-xs-6">

                <div class="form-group form-focus">
                    <label for="search" class="control-label">Search User-Name</label>
                    <input type="text" name="search" class="form-control floating"/>
                </div>
                
            </div>

            <div class="col-sm-4 col-xs-6">
                <input type ="submit" class="btn btn-success btn-block" value="Search">
            </div>
        }
        </div>
        <div class="row staff-grid-row">
            @foreach (var instructor in Model.Inst_list)
            {
                <div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
                    <div class="profile-widget">
                        <div class="profile-img">
                            <a href="#" class="avatar"><img src="@{@instructor.image_path}" /></a>
                        </div>
                        <div class="dropdown profile-action">
                            <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
                            <ul class="dropdown-menu pull-right">
                                <li>@Html.ActionLink((string)"Edit", "Edit", "User", new { id = (int)instructor.id }, null)</li>
                                <li>@Html.ActionLink((string)"Delete", "Delete", "User", new { id = (int)instructor.id }, null)</li>
                            </ul>
                        </div>
                        <h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="">@instructor.name</a></h4>
                        <h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="">@instructor.username</a></h5>
                        <div class="small text-muted">@instructor.section</div>
                        <div class="small text-muted">@instructor.subject</div>
                    </div>
                </div>
            }
        </div>
    </div>
</div>
<div id="add_client" class="modal custom-modal fade" role="dialog">
    <div class="modal-dialog">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <div class="modal-content modal-lg">
            <div class="modal-header">
                <h4 class="modal-title">Add Instructor</h4>
            </div>
            <div class="modal-body">
                <div class="m-b-30">

                    <div class="row">
                        @using (Html.BeginForm("AddInstructor", "User", FormMethod.Post, new { enctype = "multipart/form-data" }))
                        {
                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.Instructors.name, new { @class = "control-label" })
                                @Html.TextBoxFor(m => m.Instructors.name, new { @class = "form-control" })
                                @Html.ValidationMessageFor(m => m.Instructors.name)
                            </div>


                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.Instructors.username, new { @class = "control-label" })
                                @Html.TextBoxFor(m => m.Instructors.username, new { @class = "form-control", required="required" })
                                @Html.ValidationMessageFor(m => m.Instructors.username)
                            </div>


                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.Instructors.password, new { @class = "control-label" })
                                @Html.PasswordFor(m => m.Instructors.password, new { @class = "form-control" })
                                @Html.ValidationMessageFor(m => m.Instructors.password)
                            </div>

                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.repassword, new { @class = "control-label" })
                                @Html.PasswordFor(m => m.repassword, new { @class = "form-control", required = "required" })

                            </div>

                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.Instructors.section, new { @class = "control-label" })
                                @Html.DropDownListFor(m => m.Instructors.section, listItems, "Select Section", new { @class = "form-control" })
                            </div>
                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.Instructors.subject, new { @class = "control-label" })
                                @Html.DropDownListFor(m => m.Instructors.subject, listItems1, "Select Subject", new { @class = "form-control" })
                            </div>

                            <div class="form-group col-md-6">
                                @Html.LabelFor(m => m.imageFile, new { @class = "control-label" })
                                <input name="image" type="file" class="form-control">

                            </div>

                            @Html.HiddenFor(m => m.Instructors.id)

                            <div class="m-t-20 text-center">
                                <button class="btn btn-primary" type="submit">Add Instructor</button>
                            </div>
                        }
                    </div>


                </div>
            </div>
        </div>
    </div>
</div>
<div id="delete_client" class="modal custom-modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content modal-md">
            <div class="modal-header">
                <h4 class="modal-title">Delete Client</h4>
            </div>
            <div class="modal-body card-box">
                <p>Are you sure want to delete this?</p>
                <div class="m-t-20">
                    <a href="#" class="btn btn-default" data-dismiss="modal">Close</a>
                    <button type="submit" class="btn btn-danger">Delete</button>
                </div>
            </div>
        </div>
    </div>
</div>


