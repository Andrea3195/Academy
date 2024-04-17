using Microsoft.EntityFrameworkCore;
using WPF_neg_abb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_neg_abb.DAL;

namespace ProgettoWPF_GestioneAbiti.DAL
{
    internal class ProdottoDAL : IDAL<Prodotto>
    {
        #region Singleton
        static ProdottoDAL? instance;

        public static ProdottoDAL getInstance()
        {
            if (instance == null)
                instance = new ProdottoDAL();

            return instance;
        }

        ProdottoDAL() { }
        #endregion

        public bool deleteById(int id)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Prodotto prodotto = context.Prodottos.Single(p => p.ProdottoId == id);
                    context.Prodottos.Remove(prodotto);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Prodotto> findAll()
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Prodottos.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Prodotto>();
        }

        public Prodotto findById(int id)
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Prodottos.Single(p => p.ProdottoId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Prodotto();
        }

        public bool insert(Prodotto t)
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

        public bool update(Prodotto t)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Prodotto? prodotto = context.Prodottos.Find(t.ProdottoId);

                    if (prodotto == null)
                        return controllo;

                    context.Entry(prodotto).CurrentValues.SetValues(t);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Prodotto> findAllGetCategoria()
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Prodottos.Include(p => p.CategoriaRifNavigation).ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Prodotto>();
        }
    }
}
