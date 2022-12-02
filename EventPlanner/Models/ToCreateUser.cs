namespace EventPlanner.Models
{
    public class ToCreateUser
    {
        public int ID { get; set; }
        public long Pseudo { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public DateTime Birthday { get; set; }
        private string? email { get; set; }
        private string? password { get; set; }

    }
}
