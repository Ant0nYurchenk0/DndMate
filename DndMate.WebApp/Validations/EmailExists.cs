using DndMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Validations
{
    public class EmailExists : ValidationAttribute
    {
        private ApplicationDbContext _context;
        public EmailExists()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_context.Users.Any(u => u.UserName == value.ToString()))
                return ValidationResult.Success;
            return new ValidationResult("There is no such user.");
        }
    }
}