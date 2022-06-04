using MedidorModel.DAL;
using MedidorModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medidores
{
    public class HebraServidor
    {
        

        public void EjecutarServidor()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);
            Console.WriteLine("S: Lenvantando servidor en puerto: {0}", puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("S: Esperando Cliente..");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("S: Cliente recibido \n");
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    HebraCliente hebraCliente = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(hebraCliente.Ejecutar));
                    t.IsBackground = false;
                    t.Start();

                }
            }
            else
            {
                Console.WriteLine("ERROR, no se puede levantar server en puerto: {0}", puerto);
            }
        }
    }
}