//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EmpireUniversity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [Required]

        public int CourseID { get; set; }
        [Required]

        public int CourseCode { get; set; }
        [Required]

        public string CourseName { get; set; }
        [Required]

         [Range(0.5, 5)]
        public decimal CourseCredit { get; set; }
        [Required]

        public string CourseDescription { get; set; }
        [Required]

        public string Department { get; set; }
        [Required]

        public string Semestar { get; set; }
    }
}
