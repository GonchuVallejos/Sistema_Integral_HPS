<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="AProveedores.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.Reportes.AProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" class="h1 justify-content-center" runat="server">ALTA PROVEEDOR</asp:Label>
    <hr />

     <asp:Label ID="Label5" runat="server" Text="INGRESE NOMBRE DEL PROVEEDOR: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="BUSCAR" />
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive">
    <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <asp:Label ID="Label4" runat="server" Text="AGREGAR PROVEEDOR NUEVO: " Visible="False"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
    <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="AGREGAR NUEVO" Visible="False" />
</asp:Content>
