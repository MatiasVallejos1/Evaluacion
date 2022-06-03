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

        public string Nombre { get => nombre; set => nombre = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Lectura { get => lectura; set => lectura = value; }

        public override string ToString()
        {
            return nombre + "|" + fecha + "|" + lectura + "|";
        }
    }
}
