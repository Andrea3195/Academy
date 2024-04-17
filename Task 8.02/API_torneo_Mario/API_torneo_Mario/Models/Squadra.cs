namespace API_torneo_Mario.Models
{
    public class Squadra
    {
        public int SquadraID { get; set; }
        public string CodiceS { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string? NomeS { get; set; }
        public int Budget { get; set; } = 10;
        public ICollection<Personaggio> elencoPersonaggi { get; } = new List<Personaggio>();
    }
}