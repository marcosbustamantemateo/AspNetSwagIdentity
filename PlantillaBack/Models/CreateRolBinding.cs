﻿using System.ComponentModel.DataAnnotations;

namespace PlantillaBack.Models
{
    public class CreateRoleBinding
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}