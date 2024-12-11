using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_Ordinario.Controller;

namespace Examen_Ordinario.Views
{
    public partial class Admin : System.Web.UI.Page
    {
        ControlInfo cntrl = new ControlInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["klopez"] != null)
            {
                Lbl2.Text = Session["klopez"].ToString();
            }
            else
            {
                Lbl2.Text = "Sesion no encontrada. ";
                Response.Redirect("Login.aspx");
            }
        }

        protected void AgregarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Prenda prend = new Prenda
                {
                    Nombre = NombreTxtbx.Text,
                    Talla = TallaTxtbx.Text,
                    Color = ColorTxtbx.Text,
                    Material = MaterialTxtbx.Text,
                    Precio = Convert.ToDecimal(PrecioTxtbx.Text),
                    Marca = MarcaTxtbx.Text,
                    Cantidad_Disponible = Convert.ToInt32(CantidadTxtbx.Text)
                };
                
                cntrl.InsertarPrenda(prend.Nombre, prend.Talla, prend.Color, prend.Material, prend.Precio, prend.Marca, prend.Cantidad_Disponible);
                Response.Write("<script>alert('Prenda fue agregado con éxito');</script>");
                LimpiarCampos();
            }

            catch (Exception)
            {
                Response.Write("<script>alert('Prenda no fue agregado');</script>");
                LimpiarCampos();
            }
        }

        protected void ActualizarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Prenda prendact = new Prenda
                {
                    ID_Prenda = Convert.ToInt32(IDTxtbx.Text),
                    Nombre = NombreTxtbx.Text,
                    Talla = TallaTxtbx.Text,
                    Color = ColorTxtbx.Text,
                    Material = MaterialTxtbx.Text,
                    Precio = Convert.ToDecimal(PrecioTxtbx.Text),
                    Marca = MarcaTxtbx.Text,
                    Cantidad_Disponible = Convert.ToInt32(CantidadTxtbx.Text)
                };

                cntrl.ActualizarPrenda(prendact.ID_Prenda, prendact.Nombre, prendact.Talla, prendact.Color, prendact.Material, prendact.Precio, prendact.Marca, prendact.Cantidad_Disponible);
                Response.Write("<script>alert('Prenda fue actualizado con éxito');</script>");
                LimpiarCampos();
            }

            catch (Exception)
            {
                Response.Write("<script>alert('Prenda no fue actualizado');</script>");
                LimpiarCampos();
            }

        }

        protected void BorrarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int prendID = Convert.ToInt32(IDTxtbx.Text);
                cntrl.EliminarPrenda(prendID);
                Response.Write("<script>alert('Prenda fue eliminado con éxito');</script>");
                LimpiarCampos();
            }

            catch (Exception)
            {
                Response.Write("<script>alert('Producto no fue eliminado');</script>");
                LimpiarCampos();
            }

        }

        protected void MostrarBtn_Click(object sender, EventArgs e)
        {
            GVPrendas.DataSource = cntrl.ObtenerProductos();
            GVPrendas.DataBind();
        }

        private void LimpiarCampos()
        {
            NombreTxtbx.Text = "";
            TallaTxtbx.Text = "";
            ColorTxtbx.Text = "";
            MaterialTxtbx.Text = "";
            PrecioTxtbx.Text = "";
            MarcaTxtbx.Text = "";
            CantidadTxtbx.Text = "";
            IDTxtbx.Text = "";
        }

        protected void RegresarBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}