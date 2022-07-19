<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/MasterUser.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-8">
        <div class="form-control card card-body">
            <div class="row justify-content-center">
                <asp:Label ID="Label1" CssClass="row justify-content-center h3" runat="server">REGISTRO DE USUARIOS</asp:Label>
            </div>
            <fieldset>
                <legend class="row justify-content-center">DATOS PERSONALES</legend>
                <div class="input-group">
                    <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Nombres:"></asp:Label>
                    <asp:TextBox ID="TextBoxNombres" CssClass="form-control" runat="server" placeholder="Ingrese nombre/s"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label3" CssClass="form-control" runat="server" Text="Apellidos:"></asp:Label>
                    <asp:TextBox ID="TextBoxApellidos" CssClass="form-control" runat="server" placeholder="Ingrese apellidos/s"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label4" CssClass="form-control" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                    <asp:TextBox ID="TextBoxFechaNac" CssClass="form-control" TextMode="Date" runat="server" placeholder="Ingrese DNI"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label5" CssClass="form-control" runat="server" Text="DNI:"></asp:Label>
                    <asp:TextBox ID="TextBoxDNI" CssClass="form-control" runat="server" placeholder="Ingrese DNI"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label6" CssClass="form-control" runat="server" Text="Telefono:"></asp:Label>
                    <asp:TextBox ID="TextBoxTelefono" CssClass="form-control" runat="server" placeholder="Ingrese numero de telefono"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label7" CssClass="form-control" runat="server" Text="Nombres:"></asp:Label>
                    <asp:TextBox ID="TextBoxDomicilio" CssClass="form-control" runat="server" placeholder="Ingrese domicilio"></asp:TextBox>
                </div>
            </fieldset>
            <br />
            <fieldset>
                <legend class="row justify-content-center">DATOS DE INICIO DE SESION</legend>
                 <div class="input-group">
                    <asp:Label ID="Label8" CssClass="form-control" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="TextBoxContraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <asp:Label ID="Label9" CssClass="form-control" runat="server" Text="Reingrese contraseña:"></asp:Label>
                    <asp:TextBox ID="TextBoxRContraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <br />
                <div class="row justify-content-center">
                    <asp:Image runat="server" CssClass="img-thumbnail" Width="150" Height="150" ImageUrl="http://uxpanol.com/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png" />
                </div>
                <div class="row justify-content-center">
                    <asp:FileUpload runat="server" CssClass="small form-control" ID="FUImage" onchance="mostrarimagen(this)"/>
                </div>
            </fieldset>
            <br />
            <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
            <br />
            <div class="row">
                <asp:Button runat="server" CssClass="form-control btn btn-success" Text="Registrar" OnClick="Unnamed2_Click" />
                <asp:Button runat="server" CssClass="form-control btn btn-warning" Text="Cancelar" />
                <button>hola</button>
            </div>
        </div>
    </div>
</asp:Content>
