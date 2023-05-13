using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class SettingOption
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
