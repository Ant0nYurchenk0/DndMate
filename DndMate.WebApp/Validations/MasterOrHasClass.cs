using DndMate.WebApp.Dtos;
using DndMate.WebApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DndMate.WebApp.Validations
{
    public class MasterOrHasClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var character = (GamespaceCharDto)validationContext.ObjectInstance;
            if (character.Role == Role.Player && character.CharacterClass == null)
                return new ValidationResult("Player must have a character class");
            return ValidationResult.Success;
        }
    }
}