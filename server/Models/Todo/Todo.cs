using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string? Content { get; set; }
        public bool isDone { get; set; }
    }
}