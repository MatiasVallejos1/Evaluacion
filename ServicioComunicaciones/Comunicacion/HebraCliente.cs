using MedidorModel;
using MedidorModel.DAL;
using MedidorModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicaciones
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
            if (Verificar(nombre) == false)
            {
                clienteCom.Escribir("Ingrese nombre : ");
                nombre = clienteCom.Leer();
            }
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
                Lectura = lectura
            };
            lock (lecturas)
            {
                
                medidorDAL.AgregarLectura(lecturas);
                
            }
            clienteCom.Escribir("OK");
            clienteCom.Desconectar();
        }

        public bool Verificar(String nombre)
        {
            bool v = false;
            List<Medidor> listaMedidores = medidorDAL.ObtenerMedidor();
            foreach (var i in listaMedidores)
            {
                if (i.Equals(nombre))
                {
                    v = false;
                }
                else
                {
                    v = true;
                }
            }
            return v;
        }

        public string obtenerFecha(DateTime dateTime)
        {
            String fecha = dateTime.ToString("yyyy-MM-dd-HH-mm-ss");
            return fecha;
        }
    }
}
