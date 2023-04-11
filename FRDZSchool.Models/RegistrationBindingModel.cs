using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models
{
    public class RegistrationBindingModel
    {
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(25, ErrorMessage = "Длинна имени не может быть более {1} символов")]
        [UIHint("String")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(25, ErrorMessage = "Длинна фамилии не может быть более {1} символов")]
        [UIHint("String")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Введите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [DisplayName("Номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Вы указали не номер телефона")]
        public string Phone { get; set; }

        [DisplayName("Электронная почта")]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Вы указали не адрес электронной почты")]
        [UIHint("EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Длинна пароля не может быть менее {2} символов и более {1}")]
        [DisplayName("Пароль")]
        [UIHint("Password")]
        [Compare("Password1", ErrorMessage = "Оба пароля должны совпадать")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Длинна пароля не может быть менее {2} символов и более {1}")]
        [UIHint("Password")]
        [Compare("Password", ErrorMessage = "Оба пароля должны совпадать")]
        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        public RegistrationBindingModel() { }
    }
}
