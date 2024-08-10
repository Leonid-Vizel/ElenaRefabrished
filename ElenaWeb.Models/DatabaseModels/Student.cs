using FRDZSchool.Models.ViewModels.EditModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Имя")]
        [Required]
        public string Name { get; set; } 

        [DisplayName("Фамилия")]
        [Required]
        public string Lastname { get; set; } 

        [DisplayName("Отчество")]
        [Required]
        public string Fathername { get; set; } 

        [DisplayName("Пол")]
        [Required]
        public char Sex { get; set; }

        [DisplayName("Дата рождения")]
        [Required]
        public DateTime Birthday { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Grade Grade { get; set; } 

        public int GradeId { get; set; }

        [ValidateNever]
        public List<LessonStudent> LessonStudent { get; set; } 

        public void Update(StudentEditModel studentEditModel)
        {
            Id = studentEditModel.Id;
            Name = studentEditModel.Name;
            Lastname = studentEditModel.Lastname;
            Fathername = studentEditModel.Fathername;
            Sex = studentEditModel.Sex;
            Birthday = studentEditModel.Birthday;
            GradeId = studentEditModel.GradeId;
        }

        [DisplayName("ФИО")]
        public string FullName => $"{Lastname} {Name} {Fathername}";
        public string Birth => Birthday.ToString("d MMMM yyyyг.");
        [DisplayName("Класс")]
        public string GradeNumber => $"{Grade?.Number} «{Grade?.Litera}» - {Grade?.Specialization}";
    }
}
