using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal class Moto : Veicolo
    {
        int _n_tempi;
        bool _portacasco;
        public Moto(int n_tempi, bool portacasco, string marca, string modello, int km_percorsi ) : base(marca, modello, km_percorsi)
        {
            _n_tempi = n_tempi;
            _portacasco = portacasco;
        }

        public bool Portacasco { get => _portacasco; set => _portacasco = value; }

        public double CostoViaggio()
        {
            return (25 * 0.2 * Km_percorsi);
        }
        public override string Stampa()
        {
            return String.Format($"MOTO: Marca: {Marca}, Modello: {Modello}, Km percorsi: {Km_percorsi}, Costo viaggio: {CostoViaggio()}, Portacasco: {_portacasco}, Numero di tempi: {_n_tempi}");
        }
    }
}
