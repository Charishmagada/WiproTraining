﻿using System.ComponentModel.DataAnnotations;

namespace MVCDemoCore.Models
{
    public class Employee
    {
       
        [Key]
        [Required(ErrorMessage = "Please Enter Employ No")]
        public int Empno { get; set; }

        [MinLength(5, ErrorMessage = "Minimum 5 chars")]
        [MaxLength(12, ErrorMessage = "Maximum 12 chars")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string? Name { get; set; }


        public int Basic { get; set; }

    }
}

