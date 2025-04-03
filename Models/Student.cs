using System.ComponentModel.DataAnnotations;

namespace WebMVCDao.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(75,MinimumLength = 3, ErrorMessage = "Name must be between 3 and 75 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string Name { get; set; }

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Adress { get; set; }  
        public Student() { }
        public Student(int id, string name, int age, string adress) 
        {
            Id = id;
            Name = name;
            Age = age;
            Adress = adress;
        }

    }
}
