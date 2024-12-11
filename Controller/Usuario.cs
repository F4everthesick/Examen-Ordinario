using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Ordinario.Controller
{
    public class Usuario
    {
        public Usuario(string nombreuser, string password)
        {
            NombreUser = nombreuser;
            this.Password = password;
        }

        public Usuario() { }

        public string NombreUser { get; set; }
        public string Password { get; set; }
    }
}