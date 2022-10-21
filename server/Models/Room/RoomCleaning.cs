using System.ComponentModel.DataAnnotations;

namespace Meddelandecentral.Models
{
    public class RoomCleaning
    {
        [Key]
        public int Id { get; set; }
        public bool isCleaned { get; set; }
    }
}