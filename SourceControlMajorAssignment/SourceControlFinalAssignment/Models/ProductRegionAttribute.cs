using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment.Models
{
    public class ProductRegionAttribute : ValidationAttribute
    {
        private string[] _allowedRegions;
        private string _regionsStr;

        public ProductRegionAttribute(string regions)
        {
            _regionsStr = regions;
            _allowedRegions = regions.ToLower().Split(',');
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is string)
                {
                    string enteredRegion = value.ToString().ToLower();
                    foreach (string x in _allowedRegions)
                    {
                        if (enteredRegion.Contains(x))
                        {
                            return ValidationResult.Success;
                        }
                    }
                    return new ValidationResult("This application only supports the " + _regionsStr + " regions as of now. Please try again later.");
                }
            }
            return ValidationResult.Success;
        }
    }
}