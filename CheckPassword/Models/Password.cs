using System.ComponentModel.DataAnnotations;

namespace CheckPassword.Models
{
    public class Password
    {
        [Key]
        public string Hash { get; set; } = string.Empty;
    }
}
