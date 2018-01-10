<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioPersonaListar.aspx.cs" Inherits="Tanner.Web.FormularioPersonaListar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--agregar un texboxt y boton buscar Contain uso LIKE-->
        <div>

            <asp:GridView runat="server" AutoGenerateColumns="true"  ID="grdPersona" CssClass="table-bordered"></asp:GridView>
        </div>
    </form>
</body>
</html>
