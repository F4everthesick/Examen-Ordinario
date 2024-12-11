using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Ordinario.Controller
{
    interface IPrenda
    {
        List<Prenda> ObtenerProductos();
        bool InsertarPrenda(string nombre, string talla, string color, string material, decimal precio, string marca, int cantidad);
        bool EliminarPrenda(int id);
        bool ActualizarPrenda(int id, string nombre, string talla, string color, string material, decimal precio, string marca, int cantidad);

    }
}
