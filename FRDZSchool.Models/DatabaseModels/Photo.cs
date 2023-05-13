using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRDZSchool.Models.DatabaseModels
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название для фото")]
        [DisplayName("Название:")]
        [MinLength(1, ErrorMessage = "Слишком короткое название")]
        [MaxLength(80, ErrorMessage = "Слишком длинное название")]
        public string Title { get; set; }

        [DisplayName("Описание (Необязательно):")]
        [ValidateNever]
        public string? Description { get; set; }

        [ValidateNever]
        public string ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Добавьте фото")]
        public IFormFile ImageFile { get; set; }

        public override string ToString() => $"/gallery/{ImageName}";
    }
}
