namespace ProjectManagerApp.Models {
    public class Task {
        private static int days = 0;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }

        public DateTime startDate { get; set; }
        private static int Days = 0;
        public DateTime endDate { get; set; } = DateTime.Now.AddDays(Days);
    }

}
