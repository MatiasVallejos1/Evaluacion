using MedidorModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public interface IMedidorDAL
    {
        void AgregarLectura(Lecturas lectura);

        List<Lecturas> ObtenerLecturas();
        List<Medidor> ObtenerMedidor();
    }
}