using MedidorModel;
using MedidorModel.DAL;
using MedidorModel.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicaciones
{
    class Program
    {
        private static IMedidorDAL medidorDAL = MedidorDALLectura.GetInstacia();

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("¿Que necesita hacer?");
            Console.WriteLine(" 1. Ingresar \n 2. Mostrar solo medidores \n 3. Mostrar Lecturas completas \n 0. Salir \n");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    MostrarMedidor();
                    break;
                case "3":
                    MostrarLectura();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }


        static void Main(string[] args)
        {
            //1.- Iniciar el servidor en el puerto 3000
         
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.EjecutarServidor));
            t.IsBackground = false;
            t.Start();

            while (Menu());
        }

        static void Ingresar()
        {
            Console.WriteLine("Ingrese nombre :");
            string nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese nombre :");
            string fecha = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese Lectura :");
            string lectura = Console.ReadLine().Trim();
            Lecturas lecturas = new Lecturas()
            {
                Nombre = nombre,
                Fecha = fecha,
                Lectura = lectura
            };
            lock (lectura)
            {
                medidorDAL.AgregarLectura(lecturas);
            }            
        }

        static void MostrarLectura()
        {
            List<Lecturas> lecturas = medidorDAL.ObtenerLecturas();
            foreach (Lecturas lectura in lecturas)
            {
                Console.WriteLine(lectura);
            }
        }

        static void MostrarMedidor()
        {
            List<Medidor> medidores = medidorDAL.ObtenerMedidor();
            foreach (Medidor medidor in medidores)
            {
                Console.WriteLine(medidor);
            }
        }
        
    }
}

