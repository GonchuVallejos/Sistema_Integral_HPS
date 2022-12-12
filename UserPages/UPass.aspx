<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="UPass.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.UPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#body_Image1').hover(function show() {
                //Cambiar el atributo a texto
                $('#body_TextBox1').attr('type', 'text');
                $('#body_Image1').attr('src', '../Images/HidePass.png');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#body_TextBox1').attr('type', 'password');
                    $('#body_Image1').attr('src', '../Images/ShowPass.png');
                });
            $('#body_Image2').hover(function show() {
                //Cambiar el atributo a texto
                $('#body_TextBox2').attr('type', 'text');
                $('#body_Image2').attr('src', '../Images/HidePass.png');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#body_TextBox2').attr('type', 'password');
                    $('#body_Image2').attr('src', '../Images/ShowPass.png');
                });
            $('#body_Image3').hover(function show() {
                //Cambiar el atributo a texto
                $('#body_TextBox3').attr('type', 'text');
                $('#body_Image3').attr('src', '../Images/HidePass.png');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#body_TextBox3').attr('type', 'password');
                    $('#body_Image3').attr('src', '../Images/ShowPass.png');
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">CAMBIAR CLAVE</asp:Label>
    <hr />
    <br />
    <div class="row">
        <div class="col-3"></div>
        <div class="col-lg-6 justify-content-center">
            <asp:Label ID="Label2" runat="server" CssClass="font-weight-normal" Text="INGRESE SU CONTRASEÑA ACTUAL"></asp:Label>
            <div class="d-flex justify-content-center">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese contraseña" TextMode="Password"></asp:TextBox>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ShowPass.png" Width="5%" />
            </div>
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="font-weight-normal" Text="INGRESE SU NUEVA CONTRASEÑA"></asp:Label>
            <div class="d-flex justify-content-center">
                <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" CssClass="form-control text-uppercase" placeholder="Ingrese su nueva contraseña"></asp:TextBox>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ShowPass.png" Width="5%" />
            </div>
            <br />
            <asp:Label ID="Label4" runat="server" CssClass="font-weight-normal" Text="REINGRESE SU NUEVA CONTRASEÑA"></asp:Label>
            <div class="d-flex justify-content-center">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control text-uppercase" TextMode="Password" placeholder="Rengrese su nueva contraseña"></asp:TextBox>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ShowPass.png" Width="5%" />
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <br />
    <div class="row">
        <div class="col-3"></div>
        <div class="col-lg-2 d-flex justify-content-center">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-info" Text="CAMBIAR CLAVE" OnClick="Button1_Click" />
        </div>
        <div class="col-2"></div>
        <div class="col-lg-2 d-flex justify-content-center">
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-danger" Text="CANCELAR" />
        </div>
    </div>
</asp:Content>
