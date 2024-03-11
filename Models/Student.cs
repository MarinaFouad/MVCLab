using Lab4.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public class Student
    {
       
        public int Id { get; set; }

        [Required (ErrorMessage ="*")]
        [StringLength (15,MinimumLength =3,ErrorMessage ="Please Enter Valid name")]
        public string Name { get; set; }
        [Required (ErrorMessage ="*")]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }
        [Required (ErrorMessage ="The range from 20 t0 30 years")]
        [Range(20,30)]

        [DivideByTwoValidationAttribute]
        public int Age { get; set; }
     
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
