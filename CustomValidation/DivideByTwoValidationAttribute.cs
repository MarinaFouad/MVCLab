using System.ComponentModel.DataAnnotations;

namespace Lab4.CustomValidation
{
    public class DivideByTwoValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int age = (int)value;
            if( age%2==0){
                return true;
            }
            else
            {
                return false;
            }
            return base.IsValid(value);
        }
    }
}
