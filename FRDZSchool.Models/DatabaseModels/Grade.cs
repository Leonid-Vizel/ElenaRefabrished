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
        [Required(ErrorMessage = "У класса обязательно должен быть номер!")]
        [Range(1, 11, ErrorMessage = "В школе могут быть только {1}-{2} классы!")]
        public int Number { get; set; }

        [DisplayName("Литера")]
        [Required(ErrorMessage = "У класса обязательно должен быть буквенный индекс!")]
        public char Litera { get; set; }

        [DisplayName("Учебный год")]
        [Required(ErrorMessage = "У класса обязательно должен быть указан учебный год!")]
        public DateTime AcademYear { get; set; }

        [DisplayName("Специализация")]
        public string? Specialization { get; set; }

        [ValidateNever]
        public List<Student_Grade> Student_Grades { get; set; }

        public void Update(GradeEditModel gradeEditModel)
        {
            Id = gradeEditModel.Id;
            Number = gradeEditModel.Number;
            Litera = gradeEditModel.Litera;
            AcademYear = gradeEditModel.AcademYear;
        }
    }
}
