using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Models {
    [Index("Username", IsUnique = true)]
    public class User {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [StringLength(30)]
        public string Username { get; set; } = string.Empty;
        [StringLength(30)]
        public string Password { get; set; } = string.Empty;
        [StringLength(80)]
        public string Email { get; set; } = string.Empty;
    }
}