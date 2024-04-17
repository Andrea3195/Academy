using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_neg_abb.Models;

namespace WPF_neg_abb.DAL
{
    internal class CategoriaDAL : IDAL<Categorium>
    {
        #region Singleton
        static CategoriaDAL? instance;

        public static CategoriaDAL getInstance()
        {
            if (instance == null)
                instance = new CategoriaDAL();

            return instance;
        }
        CategoriaDAL() { }
        #endregion


        public bool insert(Categorium t)
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

        public bool update(Categorium t)
        {
            bool controllo = false;

            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    Categorium? categoria = context.Categoria.Find(t.CategoriaId);

                    if (categoria == null)
                        return controllo;

                    context.Entry(categoria).CurrentValues.SetValues(t);
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
                    Categorium categoria= context.Categoria.Single(e => e.CategoriaId== id);
                    context.Categoria.Remove(categoria);
                    context.SaveChanges();
                    controllo = true;
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return controllo;
        }

        public List<Categorium> findAll()
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Categoria.ToList();
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            return new List<Categorium>();
        }

        public Categorium findById(int id)
        {
            using (var context = new TaskNegAbbContext())
            {
                try
                {
                    return context.Categoria.Single(e => e.CategoriaId == id);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }

            return new Categorium();
        }
    }
}
