using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public bool isCleaned { get; set; }
        public ICollection<Todo>? Todo { get; set; } 
    }
}