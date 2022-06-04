using MedidorModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public class MedidorDALLectura : IMedidorDAL
    {
        //pra implementar Singleton:
        //1. El contructor tiene que ser private
        private MedidorDALLectura()
        {

        }
        //2. Debe poseer un atributo del mismo tipo de la clase y estatico
        private static MedidorDALLectura instancia;
        //3. Tener un metodo GetInstance, que devuelve una referencia al atributo
        public static IMedidorDAL GetInstacia()
        {
            if (instancia == null)
            {
                instancia = new MedidorDALLectura();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";
        public void AgregarLectura(Lecturas lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(lectura.Nombre + "|" + lectura.Fecha + "|" + lectura.Lectura + "|" + lectura.Tipo);
                    writer.Flush();
                }
            }
            catch (Exception)
            {

            }

        }

        public List<Lecturas> ObtenerLecturas()
        {

            List<Lecturas> lista = new List<Lecturas>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');
                            Lecturas lectura = new Lecturas()
                            {
                                Nombre = arr[0],
                                Fecha = arr[1],
                                Lectura = arr[2],
                                Tipo = arr[3]
                            };
                            lista.Add(lectura);
                        }

                    } while (texto != null);
                }
            }
            catch (Exception)
            {
                lista = null;
            }
            return lista;
        }
        public List<Medidor> ObtenerMedidor()
        {

            List<Medidor> lista = new List<Medidor>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');
                            Medidor medidor = new Medidor()
                            {
                                Nombre = arr[0]
                            };
                            lista.Add(medidor);
                        }

                    } while (texto != null);
                }
            }
            catch (Exception)
            {
                lista = null;
            }
            return lista;
        }
    }
}
