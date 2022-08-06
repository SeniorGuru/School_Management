﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("StudentAbsense")]
    public class StudentAbsense
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "ClientId")]
        [Column(TypeName = "int")]
        public int ClientId { get; set; } = 0;

        [Required]
        [Display(Name = "StudentId")]
        [Column(TypeName = "int")]
        public int StudentId { get; set; } = 0;

        [Required]
        [Display(Name = "Subject")]
        [Column(TypeName = "nvarchar(50)")]
        public string Subject   { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Teacher")]
        [Column(TypeName = "nvarchar(50)")]
        public string Teacher { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "AbsenseType")]
        [Column(TypeName = "int")]

        public int AbsenseType { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime AuditDate { get; set; }

        [Required]
        [Display(Name = "Note")]
        [Column(TypeName = "string")]
        public string Note { get; set; } = string.Empty;
    }
}
