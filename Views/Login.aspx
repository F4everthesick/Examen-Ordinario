<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Examen_Ordinario.Views.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        /* Fondo general */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image:url('../Imagenes/Sign In.jpg');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            color: #333;
        }

        /* Contenedor principal */
        .login-container {
            max-width: 400px;
            margin: 100px auto;
            padding: 30px;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            text-align: center;
        }

        /* Título */
        h1 {
            margin-bottom: 20px;
            color: black;
        }

        /* Entrada de texto */
        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Botones */
        .btn {
            width: 100%;
            padding: 10px;
            margin-top: 10px;
            border-radius: 5px;
            border: none;
            cursor: pointer;
            font-weight: bold;
            color: white;
        }

        #RegresarInicioBtn {
            background-color: black;
        }

        #LoginAdminBtn {
            background-color: red; 
        }

        .btn:hover {
            opacity: 0.8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Inicio de Sesión</h1>
            <div class="form-group">
                <label for="UserTxtbx">Usuario</label>
                <asp:TextBox ID="UserTxtbx" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="PasswordTxtbx">Contraseña</label>
                <asp:TextBox ID="PasswordTxtbx" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <asp:Button ID="LoginAdminBtn" runat="server" Text="Login como Admin" CssClass="btn" OnClick="LoginAdminBtn_Click" />
            <asp:Button ID="RegresarInicioBtn" runat="server" Text="Regresar al Inicio" CssClass="btn" OnClick="RegresarInicioBtn_Click" />
        </div>
    </form>
</body>
</html>
