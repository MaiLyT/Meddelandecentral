using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class ChatMessage
    {
        // [Key]
        // public Guid Id { get; set; }
        [Required]
        public string User { get; set; } 
        [Required]
        public string Message { get; set; }
    }
}