<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Examen_Ordinario.Views.MainPage" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prendas de Ropa</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('<%= ResolveUrl("../Imagenes/Main Page.jpg") %>'); /* Fondo de página */
            background-size: cover;
            background-attachment: fixed;
        }

        h1 {
           text-align: center;
           color: white;
           margin-top: 20px;
           font-size: 40px; /* Tamaño de fuente más grande */
           z-index: 1;
           position: relative;
        }

        h1 {
            text-align: center;
            color: white;
            margin-top: 20px;
            z-index: 1;
            position: relative;
        }

        .title-bar {
            background-color: rgba(78, 52, 46, 0.8);
            padding: 20px;
            margin-bottom: 20px;
        }

        .button-container {
            display: flex;
            justify-content: space-between;
            margin: 20px;
        }

        .button-container .left, .button-container .right {
            background-color: #4e342e;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        .button-container .left:hover, .button-container .right:hover {
            background-color: #333;
        }

        .grid-container {
            margin: 20px auto;
            width: 90%;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #3e2723;
            color: black;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .gridview th, .gridview td {
            border: 1px solid #795548;
            text-align: center;
            padding: 8px;
        }

        .gridview th {
            background-color: #4e342e;
            color: white;
        }

        .gridview tr:nth-child(even) {
            background-color: #d7ccc8;
        }

        .gridview tr:nth-child(odd) {
            background-color: #efebe9;
        }

        .gridview tr:hover {
            background-color: #bcaaa4;
        }

        .gridview td {
            color: black;
        }

        .gridview .button {
            display: block;
            margin: 0 auto;
            background-color: #4e342e;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        .gridview .button:hover {
            background-color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title-bar">
            <h1>Prendas de Ropa</h1>
        </div>

        <div class="button-container">
            <asp:Button ID="SessionBtn" CssClass="left" Text="Iniciar Sesión" runat="server" OnClick="SessionBtn_Click" />
            <asp:Button ID="CarritoBtn" CssClass="right" Text="Carrito" runat="server" OnClick="CarritoBtn_Click" />
        </div>

        <div class="grid-container">
            <asp:GridView ID="GVPrendasV2" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="ID_Prenda" HeaderText="ID Prenda" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Talla" HeaderText="Talla" />
                    <asp:BoundField DataField="Color" HeaderText="Color" />
                    <asp:BoundField DataField="Material" HeaderText="Material" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                    
                    <asp:TemplateField HeaderText=" ">
                        <ItemTemplate>
                            <asp:Button ID="AgregarBtn" CssClass="button" OnClick="AgregarBtn_Click" Text="Agregar al Carrito" runat="server" CommandName="Agregar" CommandArgument='<%# Eval("ID_Prenda") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
