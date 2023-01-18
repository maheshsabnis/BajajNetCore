using System.ComponentModel.DataAnnotations;

namespace MVC_CoreApp.CustomValidators
{
    public class NumericNonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(Convert.ToInt32(value) < 0)
                return false;
            return true;

        }
    }
}
