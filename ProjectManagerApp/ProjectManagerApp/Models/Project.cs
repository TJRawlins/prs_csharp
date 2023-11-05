using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApp.Models {
    public class Project {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        public DateTime startDate { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime endDate { get; set; } = DateTime.Now.AddDays(30);

        public int UserId { get; set; }
        public virtual User? User { get; set; }



    }
}
