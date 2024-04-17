using API_torneo_Mario.DTO;
using API_torneo_Mario.Models;
using API_torneo_Mario.Repos;

namespace API_torneo_Mario.Services
{
    public class PersonaggioService
    {
        private readonly PersonaggioRepo _repository;

        public PersonaggioService(PersonaggioRepo repository)
        {
            _repository = repository;
        }

        public List<PersonaggioDTO> GetAllPer()
        {
            List<PersonaggioDTO> elenco = _repository.GetAll().Select(p => new PersonaggioDTO()
            {
                Code = p.CodiceP,
                Nome = p.NomeP,
                Cate = p.Categoria,
                Cred = p.Crediti,
                SqRif= p.SquadraRIF,
                Squa = p.SquadraRifNavigation
            }).ToList();

            return elenco;
        }

        public bool InsPersonaggio(PersonaggioDTO p)
        {
            Personaggio per = new Personaggio()
            {
                CodiceP = p.Code,
                NomeP = p.Nome,
                Categoria = p.Cate,
                Crediti = p.Cred
            };

            return _repository.Create(per);
        }
        public bool ModPersonaggio(PersonaggioDTO p)
        {
            if (p.Code != null)
            {
                Personaggio? per = _repository.GetByCodice(p.Code);
                if (per != null)
                {
                    per.NomeP = p.Nome;
                    per.Categoria = p.Cate;
                    per.Crediti = p.Cred;
                    return _repository.Update(per);
                }
            }
            return false;
        }
    }
}
