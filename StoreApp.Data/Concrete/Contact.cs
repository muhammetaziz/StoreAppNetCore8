using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        
        [Required]
        public string FullName { get; set; }=string.Empty;
        [Required]
        public string Subject { get; set; }=string.Empty;
        [Required]
        public string Message { get; set; }=string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;

    }
}
