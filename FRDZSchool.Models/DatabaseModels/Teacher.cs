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
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию!")]
        public string Lastname { get; set; }

        [DisplayName("Отчество")]
        [Required(ErrorMessage = "Введите отчество!")]
        public string Fathername { get; set; }

        [DisplayName("Должность")]
        [Required(ErrorMessage = "Введите должность!")]
        public string Post { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения!")]
        public DateTime Birthday { get; set; }

        [DisplayName("Квалификация")]
        [Required(ErrorMessage = "Введите квалификацию!")]
        public string Qualification { get; set; }

        [DisplayName("Стаж")]
        [Required(ErrorMessage = "Введите стаж!")]
        [Range(0, 60, ErrorMessage = "Стаж не может превышать {2} лет!")]
        public int Experience { get; set; }

        [DisplayName("Номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона!")]
        [Phone(ErrorMessage = "Вы указали не номер телефона!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Добавьте фото!")]
        public string PhotoUrl { get; set; }

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
    }
}
