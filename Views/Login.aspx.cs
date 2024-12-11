using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_Ordinario.Controller;

namespace Examen_Ordinario.Views
{
    public partial class Login : System.Web.UI.Page
    {
        ValidarLogin validar = new ValidarLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginAdminBtn_Click(object sender, EventArgs e)
        {
            string username = UserTxtbx.Text;
            string password = PasswordTxtbx.Text;

            if (username == "klopez" & password == "12345")
            {
                // Guardar sesión y redirigir
                Session["klopez"] = username;
                Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    

        protected void RegresarInicioBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}