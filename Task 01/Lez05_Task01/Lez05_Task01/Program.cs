using Lez05_Task01.Classes;

namespace Lez05_Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edicola = new Edicola("Antica Edicola Romana", "Via Dei Faggi, 101");

            bool ins = true;

            while (ins)
            {
                Console.WriteLine("Benvenuto all'Antica Edicola Romana.\nScegli una tra le seguenti opzioni:");
                Console.WriteLine("1) Aggiungere giornale");
                Console.WriteLine("2) Aggiungere rivista");
                Console.WriteLine("3) Rimuovere pubblicazione");
                Console.WriteLine("4) Aggiornare quantità delle pubblicazioni");
                Console.WriteLine("5) Visualizzare elenco delle pubblicazioni");
                Console.WriteLine("Q) Esci");
                string? inputUtente = Console.ReadLine().ToUpper();

                switch (inputUtente)
                {
                    case ("1"):
                        Console.WriteLine("Inserire redazione:");
                        string? redazione = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire numero di pagine:");
                        int numPagine = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire prezzo:");
                        float prezzoGio = float.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire periodicità:");
                        string? periodicitaGio = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire codice:");
                        string? codiceGio = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire quantità:");
                        int? stockGio = int.Parse(Console.ReadLine());
                        Pubblicazione giornale = new Giornale(redazione, numPagine, prezzoGio, periodicitaGio, codiceGio, stockGio);
                        edicola.aggiungiPub(giornale);
                        giornale.stampaDettaglio();
                        break;
                    case ("2"):
                        Console.WriteLine("Inserire titolo:");
                        string? titolo = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire categoria:");
                        string? categoria = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire prezzo:");
                        float prezzoRiv = float.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire periodicità:");
                        string? periodicitaRiv = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire codice:");
                        string? codiceRiv = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire quantità:");
                        int? stockRiv = int.Parse(Console.ReadLine());
                        Pubblicazione rivista = new Rivista(titolo, categoria, prezzoRiv, periodicitaRiv, codiceRiv, stockRiv);
                        edicola.aggiungiPub(rivista);
                        rivista.stampaDettaglio();
                        break;
                    case ("3"):
                        Console.WriteLine("Inserire codice:");
                        string? rimozioneCod = Console.ReadLine().ToUpper();
                        edicola.rimuoviPub(rimozioneCod);
                        break;
                    case ("4"):
                        Console.WriteLine("Inserire codice da aggiornare:");
                        string? aggiornamentoCod = Console.ReadLine().ToUpper();
                        Console.WriteLine("Inserire stock:");
                        int aggiornamentoStock = int.Parse(Console.ReadLine());
                        edicola.aggiornaDisp(aggiornamentoCod, aggiornamentoStock);
                        break;
                    case ("5"):
                        edicola.visualizzaPub();
                        break;
                    case ("Q"):
                        ins = false;
                        break;
                    default:
                        Console.WriteLine("Errore!");
                        break;
                }
            }
        }
    }
}
