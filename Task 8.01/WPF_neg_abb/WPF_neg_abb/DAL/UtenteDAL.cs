using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_neg_abb.Models;

namespace WPF_neg_abb.DAL
{
    internal class UtenteDAL : IDAL<Utente>
    {
        #region Singleton
        static UtenteDAL? instance;

        public static UtenteDAL getInstance()
        {
            if (instance == null)
                instance = new UtenteDAL();

            return instance;
        }

        UtenteDAL() { }
        #endregion
        
        public bool insert(Utente t)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    context.Add(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Utente> findAll()
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Utentes.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Utente>();
        }
        public Utente findById(int id)
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Utentes.Single(e => e.UtenteId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Utente();
        }
        public bool update(Utente t)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Utente? utente = context.Utentes.Find(t.UtenteId);

                    if (utente == null)
                        return controllo;

                    context.Entry(utente).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Utente utente= context.Utentes.Single(e => e.UtenteId== id);
                    context.Utentes.Remove(utente);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
