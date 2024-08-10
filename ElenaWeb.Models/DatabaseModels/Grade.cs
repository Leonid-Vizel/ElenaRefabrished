﻿using FRDZSchool.Models.ViewModels.EditModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Номер")]
        [Required]
        [Range(1, 11)]
        public int Number { get; set; }

        [DisplayName("Литера")]
        [Required]
        public char Litera { get; set; }

        [DisplayName("Специализация")]
        public string? Specialization { get; set; }

        [ValidateNever]
        public List<Student> Student { get; set; }

        public void Update(GradeEditModel gradeEditModel)
        {
            Id = gradeEditModel.Id;
            Number = gradeEditModel.Number;
            Litera = gradeEditModel.Litera;
            Specialization = gradeEditModel.Specialization;
        }

        [DisplayName("Класс")]
        public string FullNumber => $"{Number} «{Litera}»";

        public override string ToString()
        {
            return $"{Number} «{Litera}» - {Specialization}";
        }
    }
}
