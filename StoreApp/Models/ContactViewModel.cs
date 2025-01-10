using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class ContactViewModel
    {
        [Key]
        public int ContactId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
