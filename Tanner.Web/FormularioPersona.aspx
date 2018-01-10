<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioPersona.aspx.cs" Inherits="Tanner.Web.FormularioPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="container-fluid">
            <h2>Guardar datos de Persona</h2>
            <asp:Label Text="Nombre" id="lblNombre" runat="server" />
            <asp:TextBox id="txtNombre" CssClass="form-control" runat="server" />
            <br />
            <asp:Label Text="Apellido" id="lblApellido" runat="server" />
            <asp:TextBox id="txtApellido" CssClass="form-control" runat="server" />
            <br />
            <asp:Button Text="Grabar" CssClass="btn-success" id="btnGrabar" runat="server" OnClick="btnGrabar_Click" />
        </div>
        <div class="container-fluid">
            <h2>Mostrar y eliminar persona</h2>
        </div>
    </div>
    </form>
</body>
</html>

