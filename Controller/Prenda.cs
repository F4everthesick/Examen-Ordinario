using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Ordinario.Controller
{
    public class Prenda
    {
        public Prenda(int iD_Prenda, string nombre, string talla, string color, string material, decimal precio, string marca, int cantidad_Disponible)
        {
            ID_Prenda = iD_Prenda;
            Nombre = nombre;
            Talla = talla;
            Color = color;
            Material = material;
            Precio = precio;
            Marca = marca;
            Cantidad_Disponible = cantidad_Disponible;
        }

        public Prenda() { }

        public int ID_Prenda { get; set; }
        public string Nombre { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public int Cantidad_Disponible { get; set; }
    }
}