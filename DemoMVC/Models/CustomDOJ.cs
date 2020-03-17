using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    //public class CustomDOJ:ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        DateTime db = Convert.ToDateTime(value);
    //        return db<=DateTime.Now;//Returns true if date is less than or equal today's date.
    //    }
    //}
    //public class CustomAge : ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        DateTime d= Convert.ToDateTime(value);
    //        DateTime t = DateTime.Today;
    //        int age=(int)(t.Subtract(d).TotalDays / 365);
    //        if (age > 21 && age <= 58)
    //            return true;
    //        else
    //            return false;
    //    }
    //}
    public class CustomDOJ : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime d = Convert.ToDateTime(value);
            DateTime t = DateTime.Today;
            int age = (int)(t.Subtract(d).TotalDays / 365);
            if (d > t)
                return new ValidationResult("date cannot be > todays date");
            else if (age < 21 || age > 58)
                return new ValidationResult("age must be b/w 21 to 58 only");
            else
                return ValidationResult.Success;
        }
    }
}