using Examen_Ordinario.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_Ordinario.Views
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Prenda> carrito = Session["Carrito"] as List<Prenda>;

            if (carrito != null && carrito.Count > 0)
            {
                GVCarrito.DataSource = carrito;
                GVCarrito.DataBind();
            }
            else
            {
                // Mostrar un mensaje si el carrito está vacío
                GVCarrito.DataSource = null;
                GVCarrito.DataBind();
            }
        }

        protected void RegresarBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void FracturarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase Correo
                Correo correo = new Correo();

                // Llamar al método para enviar el correo con el archivo PDF adjunto
                correo.EnviarCorreo("111844@alumnouninter.mx", "Recibo - Tienda de Ropa", "Muchas gracias por comprar con nosotros :) ");

                // Mensaje de confirmación (opcional)
                Response.Write("<script>alert('Correo enviado con éxito');</script>");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Write("<script>alert('Error al enviar el correo: " + ex.Message + "');</script>");
            }
        }

        protected void EliminarBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idPrenda = Convert.ToInt32(btn.CommandArgument);

            // Obtener el carrito desde la sesión
            List<Prenda> carrito = Session["Carrito"] as List<Prenda>;

            if (carrito != null)
            {
                // Buscar y eliminar el producto del carrito
                Prenda productoAEliminar = carrito.FirstOrDefault(p => p.ID_Prenda == idPrenda);

                if (productoAEliminar != null)
                {
                    carrito.Remove(productoAEliminar);
                    Session["Carrito"] = carrito;

                    // Recargar la tabla
                    GVCarrito.DataSource = carrito;
                    GVCarrito.DataBind();

                    // Mostrar un mensaje de éxito
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto eliminado del carrito con éxito');", true);
                }
            }
        }
    }
}