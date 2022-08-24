<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="VMovimiento.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VMovimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" class="h1 justify-content-center" runat="server">VER TODOS LOS MOVIMIENTOS</asp:Label>
    <hr />
     <asp:GridView ID="GridView1"  runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="id_movimiento" FooterText="Holaaaa" HeaderText="ID" />
             <asp:BoundField DataField="usuario" HeaderText="APROBADO POR" />
             <asp:BoundField DataField="estado" HeaderText="ESTADO" />
             <asp:BoundField DataField="fecha_alta" HeaderText="FECHA DE APROBACIÓN" />
             <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
             <asp:BoundField DataField="fk_pedido" HeaderText="fk_pedido" Visible="False" />
         </Columns>
         <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
     </asp:GridView>
</asp:Content>
