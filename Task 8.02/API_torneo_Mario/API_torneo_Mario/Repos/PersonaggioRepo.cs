using API_torneo_Mario.Models;

namespace API_torneo_Mario.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        private readonly Context _context;

        public PersonaggioRepo(Context context)
        {
            _context = context;
        }

        public bool Create(Personaggio entity)
        {
            try
            {
                _context.Personaggios.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return false;
            }
        }

        public bool DeleteByCode(string cod)
        {
            try
            {
                Personaggio? temp = GetByCodice(cod);
                if (temp != null)
                {
                    _context.Personaggios.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return false;
        }

        public Personaggio? Get(int id)
        {
            return _context.Personaggios.Find(id);
        }

        public IEnumerable<Personaggio> GetAll()
        {
            return _context.Personaggios.ToList();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                _context.Personaggios.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Personaggio? GetByCodice(string codice)
        {
            try
            {
                return _context.Personaggios.FirstOrDefault(p => p.CodiceP == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
