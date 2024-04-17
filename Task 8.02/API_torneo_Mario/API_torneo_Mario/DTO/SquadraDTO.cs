using API_torneo_Mario.Models;

namespace API_torneo_Mario.DTO
{
    public class SquadraDTO
    {
        public string Code { get; set; } = null!;
        public string? Nome { get; set; } = null!;
        public int? Budg { get; set; }
        public ICollection<Personaggio> ElPe { get; set; } = new List<Personaggio>();
    }
}
