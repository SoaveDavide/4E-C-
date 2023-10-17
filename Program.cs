using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Anagrafica
{
    internal class Program
    {
        enum Opzioni
        {
            Inserimento = 1,
            VisualizzaAnagrafica = 2,
            EtàPersona = 3,
            Modifica = 4,
            Esci = 5
            
        }

        enum Sesso
        {
            Maschio,
            Femmina
        }

        enum StatoCivile
        {
            Celibe,
            Nubile,
            Coniugato,
            Vedovo,
            Separato
        }

        struct Persona
        {
            public string nome;
            public string cognome;
            public string codiceFiscale;
            public string cittadinanza;
            public DateTime nascita;
            public StatoCivile stato;
            public Sesso genere;
        }

        static void Main(string[] args)
        {
            Persona[] anagrafica = new Persona[3];
            int ContaPersone = 0;
            bool continua = true;
            do
            {
                Console.Clear();
                switch ((Opzioni)Menu())
                {
                    case Opzioni.Inserimento:
                        Console.Clear();
                        Inserimento(anagrafica, ref ContaPersone);
                        break;
                    case Opzioni.VisualizzaAnagrafica:
                        Console.Clear();
                        VisualizzaAnagrafica(anagrafica, ContaPersone);
                        break;
                    case Opzioni.EtàPersona:
                        Console.Clear();
                        MenùEtà(anagrafica, ContaPersone);
                        break;
                    case Opzioni.Modifica:
                        Console.Clear();
                        Console.WriteLine("Di quale persona vuoi cambiare lo stato civile?");
                        string codiceFiscale = Console.ReadLine();
                        Modifica(codiceFiscale, anagrafica);
                        break;
                    case Opzioni.Esci:
                        continua = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Errore");
                        break;
                }
            } while (continua);

            Console.ReadLine();
        }

        static int Menu()
        {
            Console.WriteLine("Menu: ");
            foreach (Opzioni Op in Enum.GetValues(typeof(Opzioni)))
            {
                Console.WriteLine((int)Op + " - " + Op); //Op mi dà i valori del menù
            }
            Console.WriteLine("Inserisci scelta");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void VisualizzaAnagrafica(Persona[] anagrafica, int ContaPersone)
        {
            if (ContaPersone > 0)
            {
                foreach (Persona p in anagrafica)
                {

                    Console.WriteLine("Nome: " + p.nome);
                    Console.WriteLine("Cognome: " + p.cognome);
                    Console.WriteLine("CF: " + p.codiceFiscale);
                    Console.WriteLine("Cittadinanza: " + p.cittadinanza);
                    Console.WriteLine("Data di nascita: " + p.nascita.ToShortDateString());
                    Console.WriteLine("Stato civile: " + p.stato);
                    Console.WriteLine("Genere: " + p.genere);
                    Console.WriteLine();

                }
            }
            Console.ReadLine();
        }

        static void Inserimento(Persona[] anagrafica, ref int ContaPersone)
        {
            Persona p = new Persona();
            if (ContaPersone < 3)
            {
                Console.WriteLine("Inserisci nome");
                p.nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome");
                p.cognome = Console.ReadLine();

                Console.WriteLine("Inserisci CF");
                p.codiceFiscale = Console.ReadLine();

                Console.WriteLine("Inserisci cittadinanza");
                p.cittadinanza = Console.ReadLine();

                Console.WriteLine("Inserisci data di nascita (YYYY-MM-DD)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascita))
                {
                    p.nascita = dataNascita;
                }
                else
                {
                    Console.WriteLine("Formato data non valido");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Inserisci stato civile (Celibe, Nubile, Coniugato, Vedovo, Separato)");
                if (Enum.TryParse(Console.ReadLine(), out StatoCivile statoCivile))
                {
                    p.stato = statoCivile;
                }
                else
                {
                    Console.WriteLine("Stato civile non valido");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Inserisci genere (Maschio, Femmina)");
                if (Enum.TryParse(Console.ReadLine(), out Sesso genere))
                {
                    p.genere = genere;
                }
                else
                {
                    Console.WriteLine("Genere non valido");
                    Console.ReadLine();
                    return;
                }

                if (GiaInserito(p, anagrafica, ContaPersone))
                {
                    Console.WriteLine("Codice fiscale già presente");
                    Console.ReadLine();
                }
                else
                {
                    anagrafica[ContaPersone] = p;
                    ContaPersone++;
                }
            }
            else
            {
                Console.WriteLine("Anagrafica piena");
                Console.ReadLine();
            }
        }

        static bool GiaInserito(Persona p, Persona[] anagrafica, int ContaPersone)
        {
            for (int i = 0; i < ContaPersone; i++)
            {
                if (p.codiceFiscale == anagrafica[i].codiceFiscale)
                {
                    return true;
                }
            }
            return false;
        }

        static void MenùEtà(Persona[] anagrafica, int contaPersone)
        {
            string[] sottomenù = new string[] { "Persona", "Archivio" };
            for (int i = 0; i < sottomenù.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {sottomenù[i]}");
            }
            int scelta = Convert.ToInt32(Console.ReadLine());
            if (scelta == 1)
            {
                EtàPersona(anagrafica);
            }
            else if (scelta == 2)
            {
                ArchivioStampa(anagrafica, contaPersone);
            }
        }

        static void EtàPersona(Persona[] anagrafica)
        {
            Console.WriteLine("Inserisci il codice fiscale della persona di cui vuoi calcolare l'età:");
            string codiceFiscaleRicerca = Console.ReadLine();

            int indicePersona = TrovaPersonaPerCodiceFiscale(codiceFiscaleRicerca, anagrafica);

            if (indicePersona != -1)
            {
                DateTime dataDiNascita = anagrafica[indicePersona].nascita;
                DateTime dataCorrente = DateTime.Now;
                int età = CalcolaEtà(dataDiNascita, dataCorrente);

                Console.WriteLine($"Nome: {anagrafica[indicePersona].nome}");
                Console.WriteLine($"Cognome: {anagrafica[indicePersona].cognome}");
                Console.WriteLine($"Età: {età} anni");
            }
            else
            {
                Console.WriteLine("Persona non trovata nell'archivio.");
            }

            Console.ReadLine();
        }

        static int TrovaPersonaPerCodiceFiscale(string codiceFiscale, Persona[] anagrafica)
        {
            for (int i = 0; i < anagrafica.Length; i++)
            {
                if (anagrafica[i].codiceFiscale == codiceFiscale)
                {
                    return i;
                }
            }
            return -1; // Persona non trovata
        }

        static int CalcolaEtà(DateTime dataDiNascita, DateTime dataCorrente)
        {
            int età = dataCorrente.Year - dataDiNascita.Year;

            if (dataCorrente.Month < dataDiNascita.Month || (dataCorrente.Month == dataDiNascita.Month && dataCorrente.Day < dataDiNascita.Day))
            {
                età--;
            }

            return età;
        }

        static void ArchivioStampa(Persona[] anagrafica, int ContaPersone)
        {
            if (ContaPersone > 0)
            {
                foreach (Persona p in anagrafica)
                {

                    Console.Write($"Nome: {p.nome},");
                    Console.Write($"Cognome: {p.cognome},");
                    int annoCorrente, Nascita, meseCorrente, giornoCorrente, meseNascita, giornoNascita;
                    DateTime annoNascita = p.nascita;
                    annoCorrente = DateTime.Now.Year;
                    meseCorrente = DateTime.Now.Month;
                    giornoCorrente = DateTime.Now.Day;
                    meseNascita = annoNascita.Month;
                    giornoNascita = annoNascita.Day;
                    Nascita = annoNascita.Year;
                    int età = CalcolaEtaSenzaDateTime(annoCorrente, Nascita, meseCorrente, giornoCorrente, meseNascita, giornoNascita);
                    Console.Write($"età: {età},");

                }
            }
            Console.ReadLine();
        }

        static int CalcolaEtaSenzaDateTime(int annoCorrente, int annoNascita, int meseCorrente, int giornoCorrente, int meseNascita, int giornoNascita)
        {
            int età;
            età = annoCorrente - annoNascita;
            if (meseCorrente < meseNascita || (meseCorrente == meseNascita && giornoCorrente < giornoNascita))
            {
                età--;
            }
            return età;
        }
        static void Modifica(string codiceFiscale, Persona[] anagrafica)
        {
            
            for (int i = 0; i < anagrafica.Length; i++)
            {
                if (codiceFiscale == anagrafica[i].codiceFiscale)
                {
                    Console.WriteLine("Inserisci stato civile (Celibe, Nubile, Coniugato, Vedovo, Separato)");
                    if (Enum.TryParse(Console.ReadLine(), out StatoCivile statoCivile))
                    {
                        anagrafica[i].stato = statoCivile;
                    }
                    else
                    {
                        Console.WriteLine("Stato civile non valido");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Codice fiscale non esiste");
                }

            }

        }
    }
}