using WPF_neg_abb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_neg_abb.DAL;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class OrdineDAL : IDAL<Ordine>
    {
        #region Singleton
        static OrdineDAL? instance;

        public static OrdineDAL getInstance()
        {
            if (instance == null)
                instance = new OrdineDAL();

            return instance;
        }

        OrdineDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Prodotto prodotto = context.Prodottos.Single(p => p.ProdottoId== id);
                    context.Prodottos.Remove(prodotto);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Ordine> findAll()
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Ordines.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Ordine>();
        }

        public Ordine findById(int id)
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Ordines.Single(o => o.OrdineId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Ordine();
        }

        public bool insert(Ordine t)
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

        public bool update(Ordine t)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Ordine? ordine = context.Ordines.Find(t.OrdineId);

                    if (ordine == null)
                        return controllo;

                    context.Entry(ordine).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }
    }
}
