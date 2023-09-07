using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CoursesAndStudents;

public class Course
{
    public int CourseID { get; set; }
    [Required]
    [StringLength(60)]
    public string? Title { get; set; }
    public ICollection<Student> Students { get; set; }
}
