using SchoolWeb.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class OGEResult
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Год")]
        [Range(2010, 3000, ErrorMessage = "Год должен быть больше 2009")]
        [Required(ErrorMessage = "Год должен быть обязательно указан")]
        public int Year { get; set; }

        [DisplayName("Русский язык")]
        [Result("Русский язык")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Russian { get; set; }

        [DisplayName("Математика")]
        [Result("Математика")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Math { get; set; }

        [DisplayName("Обществознание")]
        [Result("Обществознание")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float SocialStudies { get; set; }

        [DisplayName("Английский язык")]
        [Result("Английский язык")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float English { get; set; }

        [DisplayName("Информатика")]
        [Result("Информатика")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Informatics { get; set; }

        [DisplayName("История")]
        [Result("История")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float History { get; set; }

        [DisplayName("Биология")]
        [Result("Биология")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Biology { get; set; }

        [DisplayName("Химия")]
        [Result("Химия")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Chemistry { get; set; }

        [DisplayName("География")]
        [Result("География")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Geography { get; set; }

        [DisplayName("Физика")]
        [Result("Физика")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Physics { get; set; }
    }
}
