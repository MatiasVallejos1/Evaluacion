using MedidorModel.DAL;
using MedidorModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Medidores
{
    class HebraCliente
    {
        private ClienteCom clienteCom;
        private static IMedidorDAL medidorDAL = MedidorDALLectura.GetInstacia();

        public HebraCliente(ClienteCom cliente)
        {
            this.clienteCom = cliente;
        }

        public void Ejecutar()
        {

            clienteCom.Escribir("Ingrese nombre : ");
            string nombre = clienteCom.Leer();
            clienteCom.Escribir("Ingrese fecha: ");
            string fechaInicial = clienteCom.Leer();
            clienteCom.Escribir("Ingrese lectura: ");
            string lectura = clienteCom.Leer();

            DateTime dateTime = DateTime.Parse(fechaInicial);
            string fecha = obtenerFecha(dateTime);

            Lecturas lecturas = new Lecturas()
            {
                Nombre = nombre,
                Fecha = fecha,
                Lectura = lectura,
                Tipo = "TCP"
            };
            lock (lecturas)
            {
                medidorDAL.AgregarLectura(lecturas);
            }
            clienteCom.Escribir("OK");
            clienteCom.Desconectar();
        }

        public string obtenerFecha(DateTime dateTime)
        {
            String fecha = dateTime.ToString("yyyy-MM-dd-HH-mm-ss");
            return fecha;
        }
    }
}
