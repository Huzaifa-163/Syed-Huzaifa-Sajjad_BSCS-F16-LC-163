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