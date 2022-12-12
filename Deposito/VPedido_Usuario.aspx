<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="VPedido_Usuario.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VPedido_Usuario" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">CONSULTAR PEDIDOS</asp:Label>
    <hr />
    <asp:Panel ID="Panel11" runat="server">
        <asp:Label ID="Label7" class="justify-content-center h3" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView11" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView11_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="VER" ShowSelectButton="True" ButtonType="Button">
                    <ControlStyle CssClass="form-control" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE Y APELLIDO" HeaderText="USUARIO QUE SOLICITA" />
                <asp:BoundField DataField="descripcion" HeaderText="SECTOR" />
                <asp:BoundField DataField="fecha" HeaderText="FECHA DE PEDIDO" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel12" runat="server" Visible="False">
        <asp:Label ID="Label2" class="justify-content-center h2" runat="server" Text="PEDIDO"></asp:Label>
        <hr />
        <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="Label3" class="font-weight-normal" runat="server" Text="Usuario solicitante:"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TextBox11" class="form-control" runat="server" OnTextChanged="TextBox11_TextChanged"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:Label ID="Label4" class="font-weight-normal" runat="server" Text="Fecha de solicitud:"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TextBox12" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1">
                <asp:Label ID="Label6" class="font-weight-normal" runat="server" Text="Retira:"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <asp:Label ID="Label5" class="row justify-content-center h2" runat="server" Text="DETALLE"></asp:Label>
        <hr />

        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" DataKeyNames="iddetalle" OnSelectedIndexChanged="GridView2_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField HeaderText="Editar" ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="form-control" />
                </asp:CommandField>
                <asp:BoundField DataField="fk_articulo" HeaderText="ID ARTICULO" />
                <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION DEL ARTICULO" />
                <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" />
                <asp:BoundField DataField="unidad_medida" HeaderText="UNIDAD DE MEDIDA" />
                <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
                <asp:BoundField DataField="iddetalle" Visible="False" />
                <asp:BoundField DataField="idpedido" Visible="False" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <div class="row">
            <div class="col-lg-2">
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btn_verpedidos" runat="server" class="btn btn-lg btn-success" OnClick="btn_verpedidos_Click" Text="VER PEDIDOS" />
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btn_guardar" runat="server" class="btn btn-lg btn-success" Text="CONFIRMAR" OnClick="btn_guardar_Click" Visible="False"/>
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btn_cancelar" runat="server" class="btn btn-lg btn-danger" Text="CANCELAR" OnClick="btn_cancelar_Click" />
            </div>
            <br />
            <br />
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Imprimir" Visible="False" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Imprimir Adriel" Visible="False" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
