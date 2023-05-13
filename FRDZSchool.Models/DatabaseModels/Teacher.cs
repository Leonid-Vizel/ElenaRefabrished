using FRDZSchool.Models.ViewModels.EditModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Teacher
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

        [DisplayName("Должность")]
        [Required]
        public string Post { get; set; }

        [DisplayName("Дата рождения")]
        [Required]
        public DateTime Birthday { get; set; }

        [DisplayName("Квалификация")]
        [Required]
        public string Qualification { get; set; }

        [DisplayName("Стаж")]
        [Required]
        [Range(0, 60)]
        public int Experience { get; set; }

        [DisplayName("Номер телефона")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [DisplayName("Фото")]
        public string? PhotoUrl { get; set; }

        public void Update(TeacherEditModel teacherEditModel)
        {
            Name = teacherEditModel.Name;
            Lastname = teacherEditModel.Lastname;
            Fathername = teacherEditModel.Fathername;
            Post = teacherEditModel.Post;
            Birthday = teacherEditModel.Birthday;
            Qualification = teacherEditModel.Qualification;
            Experience = teacherEditModel.Experience;
            PhoneNumber = teacherEditModel.PhoneNumber;
        }

        [DisplayName("ФИО")]
        public string FullName => $"{Lastname} {Name} {Fathername}";
        public string Birth => Birthday.ToString("d MMMM yyyyг.");
    }
}
