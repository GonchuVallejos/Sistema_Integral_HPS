<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <asp:Label ID="Label1" class="justify-content-center h1" runat="server">REGISTRAR UN NUEVO USUARIO</asp:Label>
            <br />
            <asp:Label ID="Label2" class="justify-content-center h3" runat="server">DATOS PERSONALES</asp:Label>
            <hr />
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Label ID="Label3" runat="server" CssClass="font-weight-normal" Text="APELLIDO"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" CssClass="font-weight-normal" Text="DNI"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control text-uppercase" TextMode="Number" MaxLength="8" Placeholder="SIN PUNTOS NI ESPACIOS"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" CssClass="font-weight-normal" Text="FECHA DE NACIMIENTO"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control text-uppercase" TextMode="Date"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-lg-6">
                        <asp:Label ID="Label4" runat="server" CssClass="font-weight-normal" Text="NOMBRE"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" CssClass="font-weight-normal" Text="DOMICILIO"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" CssClass="font-weight-normal" Text="SEXO"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select text-uppercase">
                            <asp:ListItem>Seleccione</asp:ListItem>
                            <asp:ListItem>MASCULINO</asp:ListItem>
                            <asp:ListItem>FEMENINO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
