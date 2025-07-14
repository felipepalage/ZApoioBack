namespace ZApoioBack.Models
{
    public class ProgressoZAcademy
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Modulo { get; set; } 
        public int Acertos { get; set; }
        public int Total { get; set; }
        public DateTime Data { get; set; }
    }
}
