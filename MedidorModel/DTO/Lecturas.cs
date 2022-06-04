using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DTO
{
    public class Lecturas
    {
        private string nombre;
        private string fecha;
        private string lectura;
        private string tipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Lectura { get => lectura; set => lectura = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return nombre + "|" + fecha + "|" + lectura + "|" + tipo;
        }
    }
}
