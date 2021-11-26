using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVisualStudio.Clases
{
    public class Atleta
    {
        public String nombre { get; set; }                          //Usamos los getter y setter básicos
        public String peso { get; set; }
        public String edad { get; set; }
        public Atleta(string nombre, string peso, string edad)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.edad = edad;
        }

        public override string ToString()
        {
            return nombre;
        }

        public static implicit operator List<object>(Atleta v)
        {
            throw new NotImplementedException();
        }
    }
}
