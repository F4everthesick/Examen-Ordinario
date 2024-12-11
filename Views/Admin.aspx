<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Examen_Ordinario.Views.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD de Prendas</title>
    <style>
        /* Fondo general */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('../Imagenes/Clothes.jpg');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            color: #333;
        }

        /* Contenedor principal */
        .container {
            max-width: 900px;
            margin: 50px auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        /* Títulos */
        h1 {
            text-align: center;
            color: black;
            margin-bottom: 20px;
        }
        
        .bold-label1 {
            font-weight: bold;
            text-align: center;
            color: black;
        }

        .bold-label2 {
            font-weight: bold;
            text-align: center;
            color: red;
        }

        /* Formulario */
        .form-group {
            display: flex;
            flex-direction: column;
            gap: 15px; /* Espaciado entre los elementos del formulario */
            margin-bottom: 20px; /* Espaciado entre el formulario y otros elementos */
        }

        .form-group label {
            font-weight: bold;
        }

        .form-group input {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Botones personalizados */
        .form-group button {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
            border-radius: 5px;
            color: white;
            border: none;
            cursor: pointer;
            font-weight: bold;
        }

        #AgregarBtn {
            background-color: #4CAF50; /* Verde */
        }

        #MostrarBtn {
            background-color: #2196F3; /* Azul */
        }

        #ActualizarBtn {
            background-color: #FFEB3B; /* Amarillo */
            color: black;
        }

        #BorrarBtn {
            background-color: #F44336; /* Rojo */
        }

        #RegresarBtn {
            background-color: #000; /* Negro */
            color: white; /* Texto en blanco */
        }

        .form-group button:hover {
            opacity: 0.8;
        }

        /* GridView */
        .grid-container {
            margin-top: 30px;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th,
        .gridview td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: center;
        }

        .gridview th {
            background-color: navy;
            color: white;
        }

        .gridview tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Gestión de Prendas</h1>

            <div class="form-group">

                 <asp:Label ID ="Lbl1" runat="server" Text="Bienvenido:   " CssClass="bold-label1" >
                 <asp:Label ID ="Lbl2" runat="server" CssClass="bold-label2"></asp:Label>
                 </asp:Label>

                <label for="IDTxtbx">ID (Actualizar / Borrar)</label>
                <asp:TextBox ID="IDTxtbx" runat="server" CssClass="form-control" />

                <label for="NombreTxtbx">Nombre:</label>
                <asp:TextBox ID="NombreTxtbx" runat="server" CssClass="form-control" />

                <label for="TallaTxtbx">Talla:</label>
                <asp:TextBox ID="TallaTxtbx" runat="server" CssClass="form-control" />

                <label for="ColorTxtbx">Color:</label>
                <asp:TextBox ID="ColorTxtbx" runat="server" CssClass="form-control" />

                <label for="MaterialTxtbx">Material:</label>
                <asp:TextBox ID="MaterialTxtbx" runat="server" CssClass="form-control" />

                <label for="PrecioTxtbx">Precio:</label>
                <asp:TextBox ID="PrecioTxtbx" runat="server" CssClass="form-control" />

                <label for="MarcaTxtbx">Marca:</label>
                <asp:TextBox ID="MarcaTxtbx" runat="server" CssClass="form-control" />

                <label for="CantidadTxtbx">Cantidad Disponible:</label>
                <asp:TextBox ID="CantidadTxtbx" runat="server" CssClass="form-control" />

                <div class="grid-container">
                <asp:GridView ID="GVPrendas" runat="server" AutoGenerateColumns="False" CssClass="gridview">
                    <Columns>
                        <asp:BoundField DataField="ID_Prenda" HeaderText="ID Prenda" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Talla" HeaderText="Talla" />
                        <asp:BoundField DataField="Color" HeaderText="Color" />
                        <asp:BoundField DataField="Material" HeaderText="Material" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                    </Columns>
                </asp:GridView>
            </div>

                <asp:Button ID="AgregarBtn" runat="server" Text="Agregar Prenda" CssClass="form-group button" OnClick="AgregarBtn_Click" />
                <asp:Button ID="MostrarBtn" runat="server" Text="Mostrar Prendas" CssClass="form-group button" OnClick="MostrarBtn_Click" />
                <asp:Button ID="ActualizarBtn" runat="server" Text="Actualizar Prenda" CssClass="form-group button" Onclick="ActualizarBtn_Click"/>
                <asp:Button ID="BorrarBtn" runat="server" Text="Borrar Prenda" CssClass="form-group button" Onclick="BorrarBtn_Click"/> 
                <asp:Button ID="RegresarBtn" runat="server" Text="Regresar al Inicio" CssClass="form-group button" Onclick="RegresarBtn_Click"/>
            </div>

        </div>
    </form>
</body>
</html>
