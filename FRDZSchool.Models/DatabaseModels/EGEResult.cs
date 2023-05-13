using SchoolWeb.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public class EGEResult
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Год:")]
        [Range(2010, 3000, ErrorMessage = "Год должен быть больше 2009")]
        [Required(ErrorMessage = "Год должен быть обязательно указан")]
        public int Year { get; set; }

        [DisplayName("Русский язык:")]
        [Result("Русский язык")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Russian { get; set; }

        [DisplayName("Математика (Базовая):")]
        [Result("Математика (Базовая)")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float MathBase { get; set; }

        [DisplayName("Математика (Профильная):")]
        [Result("Математика (Профильная)")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float MathProfi { get; set; }

        [DisplayName("История:")]
        [Result("История")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float History { get; set; }

        [DisplayName("Обществознание:")]
        [Result("Обществознание")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float SocialStudies { get; set; }

        [DisplayName("Физика:")]
        [Result("Физика")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Physics { get; set; }

        [DisplayName("Химия:")]
        [Result("Химия")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Chemistry { get; set; }

        [DisplayName("География:")]
        [Result("География")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Geography { get; set; }

        [DisplayName("Биология:")]
        [Result("Биология")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Biology { get; set; }

        [DisplayName("Информатика:")]
        [Result("Информатика")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Informatics { get; set; }

        [DisplayName("Английский язык:")]
        [Result("Английский язык")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float English { get; set; }

        [DisplayName("Литература:")]
        [Result("Литература")]
        [RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Значение должно быть десятичной дробью (Как разделитель используйте '.')")]
        [Range(0, 100, ErrorMessage = "Количество баллов должно быть в пределах от 0 до 100")]
        [Required(ErrorMessage = "Укажите средний балл по этому предмету. Если предмет не сдавался в этом году, то поставьте 0")]
        public float Literature { get; set; }
    }
}
