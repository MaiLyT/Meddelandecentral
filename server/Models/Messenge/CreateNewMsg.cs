using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class CreateNewMsg
    {
        [Required]
        public string User { get; set; } 
        [Required]
        public string Message { get; set; }
    }
}