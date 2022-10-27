<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="CPedidos.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.CPedidos" %>
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
            <asp:TextBox ID="TextBox1" CssClass="form-control text-uppercase" required=true runat="server" TextMode="Date" Visible="false"></asp:TextBox>
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
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-select text-uppercase" Visible="false">
            </asp:DropDownList>
        </div>
    </div>
    <br />
        <div class="col-lg-2 d-grid justify-content-center">
            <asp:Button ID="Button1" CssClass="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button1_Click" Visible="false"/>
        </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Label ID="Label5" runat="server" class="font-weight-normal" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDPEDIDO" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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

</asp:Content>