<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="VPedido.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" class="justify-content-center h1" runat="server">CONSULTAR PEDIDOS</asp:Label>
        <hr />
        <asp:GridView ID="GridView1" runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField HeaderText="VER" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE Y APELLIDO" HeaderText="USUARIO" />
                <asp:BoundField DataField="descripcion" HeaderText="SECTOR" />
                <asp:BoundField DataField="fecha" HeaderText="FECHA DE PEDIDO" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False" >

        <asp:Label ID="Label2" class="row justify-content-center h2" runat="server" Text="PEDIDO"></asp:Label>
        <hr />
        <div class="row">
            <div class="col-lg-3">
                <asp:Label ID="Label3" class="row justify-content-center h3" runat="server" Text="Usuario"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <asp:Label ID="Label4" class="row justify-content-center h3" runat="server" Text="Fecha"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <asp:Label ID="Label5" class="row justify-content-center h2" runat="server" Text="DETALLE"></asp:Label>
        <hr />
        <asp:GridView ID="GridView2" runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField HeaderText="EDITAR" ShowEditButton="True" />
            </Columns>
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="btn_cancelar" runat="server" Text="CANCELAR" class="btn btn-lg btn-danger" />
            </div>
            <div class="col-lg-4">
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btn_guardar" runat="server" class="btn btn-lg btn-success" Text="CONFIRMAR" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
