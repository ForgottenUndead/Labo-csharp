using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class NewMessageViewModel
    {
        [Required]
        public string Content { get; set; }
    }
}
