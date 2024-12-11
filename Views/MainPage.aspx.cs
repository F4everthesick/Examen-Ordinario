using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_Ordinario.Controller;


namespace Examen_Ordinario.Views
{
    public partial class MainPage : System.Web.UI.Page
    {
        ControlInfo ctl = new ControlInfo();
        private List<int> Carrito
        {
            get
            {
                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = new List<int>();
                }
                return (List<int>)Session["Carrito"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar los datos de las prendas en el GridView
            CargarDatosPrendas();
        }

        protected void SessionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void CarritoBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void AgregarBtn_Click(object sender, EventArgs e)
        {
            // Obtener el botón que fue clickeado
            var button = (Button)sender;

            // Obtener el ID del producto del CommandArgument
            int idPrenda = int.Parse(button.CommandArgument);

            // Agregar el producto al carrito (sesión)
            Carrito.Add(idPrenda);

            // Mostrar script indicando éxito
            string script = "alert('Producto agregado al carrito exitosamente.');";
            ScriptManager.RegisterStartupScript(this, GetType(), "AgregarCarrito", script, true);
        }

        private void CargarDatosPrendas()
        {
            // Simulación de datos para el GridView (deberías reemplazarlo con datos reales)
            var prendas = new List<dynamic>
        {
            new { ID_Prenda = 1, Nombre = "Camiseta Básica", Talla = "M", Color = "Blanco", Material = "Algodón", Precio = 199.99, Marca = "H&M", Cantidad_Disponible = 100 },
            new { ID_Prenda = 2, Nombre = "Sudadera Deportiva", Talla = "L", Color = "Negro", Material = "Poliéster", Precio = 799.50, Marca = "Nike", Cantidad_Disponible = 50 },
            new { ID_Prenda = 3, Nombre = "Jeans Ajustados", Talla = "S", Color = "Azul", Material = "Denim", Precio = 899.00, Marca = "American Eagle", Cantidad_Disponible = 25 },
            new { ID_Prenda = 4, Nombre = "Pantalón Deportivo", Talla = "M", Color = "Gris", Material = "Poliéster", Precio = 599.99, Marca = "Adidas", Cantidad_Disponible = 30 },
            new { ID_Prenda = 5, Nombre = "Playera Casual", Talla = "L", Color = "Verde", Material = "Algodón", Precio = 299.99, Marca = "Hollister", Cantidad_Disponible = 40 },
            new { ID_Prenda = 6, Nombre = "Sudadera Jordan con Capucha", Talla = "M", Color = "Rojo", Material = "Mezcla de algodón", Precio = 1199.99, Marca = "Jordan", Cantidad_Disponible = 20 }
        };

            GVPrendasV2.DataSource = prendas;
            GVPrendasV2.DataBind();
        }

    }
}