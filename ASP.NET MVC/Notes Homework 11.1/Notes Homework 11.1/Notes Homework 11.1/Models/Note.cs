using System.ComponentModel.DataAnnotations;

namespace Notes_Homework_11._1.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Note Title")]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Text")]
        public string? Text { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Tags")]
        public string? Tags { get; set; }
    }
}
