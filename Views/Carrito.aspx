<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Examen_Ordinario.Views.Carrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrito</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('<%= ResolveUrl("../Imagenes/Carrito.jpg") %>'); /* Fondo de la página */
            background-size: cover;
            background-position: center;
            background-attachment: fixed; /* Mantener el fondo fijo */
            display: flex;
            flex-direction: column;
            height: 100vh;
            justify-content: space-between;
        }

        /* Title Bar */
        .title-bar {
            background-color: rgba(78, 52, 46, 0.8);
            padding: 20px;
            width: 100%;
            text-align: center;
        }

        .title-bar h1 {
            color: white;
            margin: 0;
            font-size: 36px;
            font-weight: bold;
        }

        /* Estilo para el contenedor principal */
        .content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-start;
            width: 100%;
            padding-top: 50px; /* Espacio arriba */
            z-index: 1;
        }

        /* Contenedor para los botones */
        .button-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: 100%;
            padding: 20px;
        }

        /* Botón de regresar alineado a la izquierda */
        .button-container .left {
            background-color: #4e342e;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            margin-left: 20px; /* No tan pegado al borde izquierdo */
            align-self: flex-start; /* Alineado a la izquierda */
        }

        .button-container .left:hover {
            background-color: #333;
        }

        /* Botón de facturación centrado */
        .button-container .center {
            background-color: #4e342e;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            margin-top: auto;
            margin-bottom: 20px; /* Espacio desde el fondo */
        }

        .button-container .center:hover {
            background-color: #333;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Title Bar -->
        <div class="title-bar">
            <h1>Carrito</h1>
        </div>

        <div class="content">
            <div class="button-container">
                <!-- Botón para regresar al inicio alineado a la izquierda -->
                <asp:Button ID="RegresarBtn" CssClass="left" Text="Regresar al Inicio" runat="server" OnClick="RegresarBtn_Click" />

<asp:GridView ID="GVCarrito" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="ID_Prenda" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Talla" HeaderText="Talla" />
        <asp:BoundField DataField="Color" HeaderText="Color" />
        <asp:BoundField DataField="Material" HeaderText="Material" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Marca" HeaderText="Marca" />
        <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
    </Columns>
</asp:GridView>

                <asp:Button ID="FracturarBtn" CssClass="center" Text="Facturar su Pedido" runat="server" OnClick="FracturarBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
