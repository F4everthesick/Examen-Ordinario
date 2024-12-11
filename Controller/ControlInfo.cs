using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Examen_Ordinario.Models.DBComprasTableAdapters;

namespace Examen_Ordinario.Controller
{
    public class ControlInfo : IPrenda
    {
        private Prenda p = new Prenda();
        List<Prenda> listaprend = new List<Prenda>();

        public bool ActualizarPrenda(int id, string nombre, string talla, string color, string material, decimal precio, string marca, int cantidad)
        {
            try
            {
                using (prendasTableAdapter prendasTable = new prendasTableAdapter())
                {
                    if (nombre.Length > 3 && precio > 0)
                    {
                        prendasTable.Update(nombre, talla, color, material, Convert.ToDecimal(precio), marca, Convert.ToInt32(cantidad), id);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }

        public bool EliminarPrenda(int id)
        {
            try
            {
                using (prendasTableAdapter prendasTable = new prendasTableAdapter())
                {
                    prendasTable.Delete(id);
                }

                return true;
            }

            catch (Exception)
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public bool InsertarPrenda(string nombre, string talla, string color, string material, decimal precio, string marca, int cantidad)
        {
            try
            {
                using (prendasTableAdapter prendasTable = new prendasTableAdapter())
                {
                    if (nombre.Length > 3 && precio > 0)
                    {
                        prendasTable.Insert(nombre, talla, color, material, Convert.ToDecimal(precio), marca, Convert.ToInt32(cantidad));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception)
            {

                return false;
            }

            throw new NotImplementedException();
        }

        public List<Prenda> ObtenerProductos()
        {
            using (prendasTableAdapter prendasTable = new prendasTableAdapter())

            {
                var datos = prendasTable.GetData();
                foreach (var row in datos)
                {
                    p.ID_Prenda = Convert.ToInt32(row["ID_Prenda"]);
                    p.Nombre = row["Nombre"].ToString();
                    p.Talla = row["Talla"].ToString();
                    p.Color = row["Color"].ToString();
                    p.Material = row["Material"].ToString();
                    p.Precio = Convert.ToDecimal(row["Precio"]);
                    p.Marca = row["Marca"].ToString();
                    p.Cantidad_Disponible = Convert.ToInt32(row["Cantidad_Disponible"]);
                    listaprend.Add(new Prenda(p.ID_Prenda,p.Nombre, p.Talla, p.Color, p.Material, p.Precio, p.Marca, p.Cantidad_Disponible));
                }

                return listaprend;
            }

            throw new NotImplementedException();
        }

        public Prenda ObtenerProductoPorId(int idPrenda)
        {
            // Crear una instancia de la clase Prenda para almacenar el resultado
            Prenda prenda = null;

            using (prendasTableAdapter prendasTable = new prendasTableAdapter())
            {
                var datos = prendasTable.GetDataByIDPrenda(idPrenda);
                foreach (var row in datos)
                {
                    p.ID_Prenda = Convert.ToInt32(row["ID_Prenda"]);
                    p.Nombre = row["Nombre"].ToString();
                    p.Talla = row["Talla"].ToString();
                    p.Color = row["Color"].ToString();
                    p.Material = row["Material"].ToString();
                    p.Precio = Convert.ToDecimal(row["Precio"]);
                    p.Marca = row["Marca"].ToString();
                    p.Cantidad_Disponible = Convert.ToInt32(row["Cantidad_Disponible"]);
                    listaprend.Add(new Prenda(p.ID_Prenda, p.Nombre, p.Talla, p.Color, p.Material, p.Precio, p.Marca, p.Cantidad_Disponible));
                }

                return prenda;
            }

            throw new NotImplementedException();
        }
    }
    
}
