using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class CreateTodo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string? Notis { get; set; }
    }
}