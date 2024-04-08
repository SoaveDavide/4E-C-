using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal abstract class Veicolo
    {
        string _marca, _modello;
        int _km_percorsi;
       
        protected Veicolo(string marca,string moedello, int km_percorsi)
        {
            _marca = marca;
            _modello = moedello;
            _km_percorsi = km_percorsi;
            
        }

        public string Marca { get => _marca; set => _marca = value; }
        public string Modello { get => _modello; set => _modello = value; }
        public int Km_percorsi { get => _km_percorsi; set => _km_percorsi = value; }
        public static bool operator ==(Veicolo a1, Veicolo a2)
        {
            return ((a1.Marca == a2.Marca) && (a1.Modello == a2.Modello));
        }
        public static bool operator !=(Veicolo a1, Veicolo a2)
        {
            return !((a1.Marca == a2.Marca) && (a1.Modello == a2.Modello));
        }

        public abstract string Stampa();
    }
}
