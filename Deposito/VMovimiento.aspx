<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="VMovimiento.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VMovimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" class="h1 justify-content-center" runat="server">VER TODOS LOS MOVIMIENTOS</asp:Label>
    <hr />
    <div class="row">
            <div class="col-lg-3">
                <asp:Label ID="Label3" class="row justify-content-center h3" runat="server" Text="Seleccione movimiento:"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataTextField="descripcion" DataValueField="id">
                </asp:DropDownList>
            </div>
            <div class="col-lg-3">
                <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-info" Text="BUSCAR" OnClick="Button1_Click" />
            </div>
    </div>
     <asp:GridView ID="GridView1"  runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False" DataKeyNames="fk_pedido, fk_ajuste, fk_adquisicion">
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="id_movimiento" FooterText="Holaaaa" HeaderText="ID" />
             <asp:BoundField DataField="usuario" HeaderText="APROBADO POR" />
             <asp:BoundField DataField="estado" HeaderText="ESTADO" />
             <asp:BoundField DataField="fecha_alta" HeaderText="FECHA DE APROBACIÓN" />
             <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
             <asp:BoundField DataField="fk_pedido" HeaderText="fk_pedido" Visible="False" />
             <asp:BoundField DataField="fk_ajuste" HeaderText="fk_ajuste" Visible="False" />
             <asp:BoundField DataField="fk_tipo_movimiento" HeaderText="fk_tipo_movimiento" Visible="False" />
             <asp:BoundField DataField="fk_adquisicion" HeaderText="fk_adquisicion" Visible="False" />
             <asp:BoundField DataField="unidad_seccion" HeaderText="DESTINO" />
         </Columns>
         <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
     </asp:GridView>
     <asp:GridView ID="GridView3"  runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Visible="False" DataKeyNames="fk_pedido,fk_ajuste,fk_adquisicion">
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="id_movimiento" FooterText="Holaaaa" HeaderText="ID" />
             <asp:BoundField DataField="usuario" HeaderText="APROBADO POR" />
             <asp:BoundField DataField="estado" HeaderText="ESTADO" />
             <asp:BoundField DataField="fecha_alta" HeaderText="FECHA DE APROBACIÓN" />
             <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
             <asp:BoundField DataField="fk_pedido" HeaderText="fk_pedido" Visible="False" />
             <asp:BoundField DataField="fk_ajuste" HeaderText="fk_ajuste" Visible="False" />
             <asp:BoundField DataField="fk_tipo_movimiento" HeaderText="fk_tipo_movimiento" Visible="False" />
             <asp:BoundField DataField="fk_adquisicion" HeaderText="fk_adquisicion" Visible="False" />
         </Columns>
         <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
     </asp:GridView>
     <asp:GridView ID="GridView4"  runat="server" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" Visible="False" DataKeyNames="fk_pedido,fk_ajuste,fk_adquisicion">
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="id_movimiento" FooterText="Holaaaa" HeaderText="ID" />
             <asp:BoundField DataField="usuario" HeaderText="APROBADO POR" />
             <asp:BoundField DataField="estado" HeaderText="ESTADO" />
             <asp:BoundField DataField="fecha_alta" HeaderText="FECHA DE APROBACIÓN" />
             <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
             <asp:BoundField DataField="fk_pedido" HeaderText="fk_pedido" Visible="False" />
             <asp:BoundField DataField="fk_ajuste" HeaderText="fk_ajuste" Visible="False" />
             <asp:BoundField DataField="fk_tipo_movimiento" HeaderText="fk_tipo_movimiento" Visible="False" />
             <asp:BoundField DataField="fk_adquisicion" HeaderText="fk_adquisicion" Visible="False" />
         </Columns>
         <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
     </asp:GridView>
    <br />
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    <br />
</asp:Content>
