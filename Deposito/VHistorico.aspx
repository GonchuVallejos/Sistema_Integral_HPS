<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="VHistorico.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VHistorico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="h1 justify-content-center" runat="server">HISTORICO DE PRECIOS DE PRODUCTOS EN ADQUISICIONES</asp:Label>
    <hr />
    <asp:Label ID="Label2" runat="server" Text="INGRESE EL ID DEL ARTICULO A BUSCAR:" Visible="True"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="BUSCAR" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive">
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive">
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <br />
</asp:Content>
