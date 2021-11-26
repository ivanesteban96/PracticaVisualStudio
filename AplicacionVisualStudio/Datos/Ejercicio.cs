using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVisualStudio.Clases
{
    public class Ejercicio: INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        private String nombre;
        public String Nombre
        {
            get { return nombre; }                                                      //Usamos los getter y setter personalizados 
            set
            {
                nombre = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private String peso;
        public String Peso
        {
            get { return peso; }
            set
            {
                peso = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Peso"));
            }
        }

        private String atleta;
        public String Atleta
        {
            get { return atleta; }
            set
            {
                atleta = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Atleta"));
            }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Fecha"));
            }
        }
        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if(columnName=="Nombre")
                {
                    if(string.IsNullOrEmpty(nombre))
                    {
                        result = "Debe introducir el nombre del ejercicio";
                    }
                }
                if (columnName == "Peso")
                {
                    if (string.IsNullOrEmpty(peso))
                    {
                        result = "Debe introducir el peso";
                    }
                }
                return result;

            }
        }

        public Ejercicio(string nombre, string peso, string atleta, DateTime fecha)   //Creamos 2 constructores para una misma clase (Ejercicio)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.atleta = atleta;
            this.fecha = fecha;
        }

        public Ejercicio()
        {
          
        }

        public event PropertyChangedEventHandler PropertyChanged;  //AVISA A LA TABLA DE QUE EL CONTENIDO DE LA LISTA HA CAMBIADO

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
