using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_torneo_Mario.Models
{
    public class Personaggio
    {
        public int PersonaggioID { get; set; }
        public string CodiceP { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public string? NomeP { get; set; }
        public string? Categoria { get; set; }
        public int Crediti { get; set; }
        public int? SquadraRIF { get; set; }
        public Squadra? SquadraRifNavigation { get; set; }
    }
}


