using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal class Auto : Veicolo
    {
        int _numero_volumi;
        int _cilindrata;
        public Auto(int numero_volumi, int cilindrata, string marca, string modello, int km_percorsi) : base(marca, modello, km_percorsi)
        {
            _numero_volumi = numero_volumi;
            _cilindrata = cilindrata;
        }
        public double CostoViaggio()
        {
            return (25 * 0.2 * Km_percorsi);
        }
        public override string Stampa()
        {
            return String.Format($"AUTO: Marca: {Marca}, Modello: {Modello}, Km percorsi: {Km_percorsi}, Costo viaggio: {CostoViaggio()}, Cilindrata: {_cilindrata}, Numero di volumi: {_numero_volumi}");
        }
        
    }
}
