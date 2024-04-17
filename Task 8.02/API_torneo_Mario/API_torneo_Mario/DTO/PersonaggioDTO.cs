using API_torneo_Mario.Models;

namespace API_torneo_Mario.DTO
{
    public class PersonaggioDTO
    {
        public string Code { get; set; } = null!;
        public string? Nome { get; set; }
        public string? Cate { get; set; } 
        public int Cred { get; set; }
        public int? SqRif { get; set; }
        public Squadra? Squa { get; set; }
    }

}
