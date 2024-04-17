using Lez_Task04.Models;
using Lez_Task04.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez_Task04.DAL
{
    internal class PrestitoDAL : IDal<Prestito>
    {
        private static PrestitoDAL? istanza;

        public static PrestitoDAL getIstanza()
        {
            if (istanza == null)
                istanza = new PrestitoDAL();

            return istanza;
        }

        private PrestitoDAL() { }

        public bool Delete(Prestito t)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prestito GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Prestito t)
        {
            bool risultato = false;

            using (SqlConnection con = new SqlConnection(Config.getIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Prestito(dataPrestito, dataRitorno, utenteRIF, libroRIF) VALUES (@dataPrestito, @dataRitorno, @utenteRIF, @libroRIF)";
                sqlCommand.Parameters.AddWithValue("@dataPrestito", t.DataPrestito);
                sqlCommand.Parameters.AddWithValue("@dataRitorno", t.DataRitorno);
                sqlCommand.Parameters.AddWithValue("@utenteRIF", t.UtenteRIF);
                sqlCommand.Parameters.AddWithValue("@libroRIF", t.LibroRIF);

                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return risultato;
        }

        public bool Update(Prestito t)
        {
            throw new NotImplementedException();
        }
    }
}
