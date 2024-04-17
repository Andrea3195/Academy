using API_torneo_Mario.Models;

namespace API_torneo_Mario.Repos
{
    public class SquadraRepo : IRepo<Squadra>
    {
        private readonly Context _context;

        public SquadraRepo(Context context)
        {
            _context = context;
        }

        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadras.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return false;
            }
        }

        public bool DeleteByCode(string code)
        {

            try
            {
                Squadra? temp = GetByCodice(code);
                if (temp != null)
                {
                    _context.Squadras.Remove(temp);
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

        public Squadra? Get(int id)
        {
            return _context.Squadras.Find(id);
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadras.ToList();
        }

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadras.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Squadra? GetByCodice(string codice)
        {
            try
            {
                return _context.Squadras.FirstOrDefault(p => p.CodiceS == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
