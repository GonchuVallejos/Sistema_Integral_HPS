<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="CPedidos.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.CPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">CONSULTAR PEDIDOS REALIZADOS</asp:Label>
    <hr />
    <div class="row">
        <div class="col-lg-2">
            <asp:Label ID="Label2" runat="server" class="font-weight-normal" Text="SELECCIONE"></asp:Label>
        </div>
        <div class="col-lg-2">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select text-uppercase" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>SELECCIONE</asp:ListItem>
                <asp:ListItem Value="ID PEDIDO">ID PEDIDO</asp:ListItem>
                <asp:ListItem Value="FECHA">FECHA</asp:ListItem>
                <asp:ListItem Value="TIPO DE PEDIDO">TIPO DE PEDIDO</asp:ListItem>
                <asp:ListItem Value="USUARIO ESPECIFICO">USUARIO ESPECIFICO</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select text-uppercase" Visible="false">
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" class="font-weight-normal" Text="" Visible="false"></asp:Label>
            <asp:TextBox ID="TextBox1" CssClass="form-control text-uppercase" required=true runat="server" TextMode="Date" Visible="false" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select text-uppercase" Visible="false">
            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" class="font-weight-normal" Text="" Visible="false"></asp:Label>
            <asp:TextBox ID="TextBox2" CssClass="form-control text-uppercase" runat="server" TextMode="Date" Visible="false"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select text-uppercase" Visible="false">
            </asp:DropDownList>
            
        </div>
        <div class="col-lg-2 d-grid">
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-select text-uppercase" Visible="false" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    
        <div class="d-flex justify-content-center">
            <asp:Button ID="Button1" CssClass="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button1_Click" Visible="false"/>
        </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Label ID="Label5" runat="server" class="font-weight-normal" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDPEDIDO" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="IDPEDIDO" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE Y APELLIDO" HeaderText="USUARIO QUE SOLICITA" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="SECTOR" />
                <asp:BoundField DataField="FECHA" HeaderText="FECHA DE PEDIDO" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <asp:Panel ID="Panel3" runat="server" Visible="false">
            <asp:Label ID="Label12" class="justify-content-center h2" runat="server" Text="PEDIDO"></asp:Label>
        <hr />
        <div class="row">
            <div class="col-lg-1">
                <asp:Label ID="Label13" class="font-weight-normal" runat="server" Text="RETIRO:"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox3" class="form-control text-uppercase" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-lg-3"></div>
            <div class="col-lg-2">
                <asp:Label ID="Label14" class="font-weight-normal" runat="server" Text="CONFIRMADO POR:"></asp:Label>
            </div>
            <div class="col-lg-3">
                <asp:TextBox ID="TextBox4" class="form-control text-uppercase" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </div>
        </asp:Panel>
        <br />
        <asp:Label ID="Label15" class="row justify-content-center h2" runat="server" Text="DETALLE"></asp:Label>
        <hr />
    <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="iddetalle" OnSelectedIndexChanged="GridView2_SelectedIndexChanged1">
            <Columns>

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
        </asp:Panel>
</asp:Content>