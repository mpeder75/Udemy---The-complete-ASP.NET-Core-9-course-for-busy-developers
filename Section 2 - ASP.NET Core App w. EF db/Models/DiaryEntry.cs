using System.ComponentModel.DataAnnotations;

namespace Diary.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Title")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter Content")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Content must be between 3 and 100 characters")]
        public string Content { get; set; } = String.Empty;

        [Required]        
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
