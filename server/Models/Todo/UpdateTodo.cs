using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class UpdateTodo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool isDone { get; set; }
    }
}