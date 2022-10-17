<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="APedido_Provision.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.APedido_Provision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label3" class="justify-content-center h1" runat="server">REGISTRAR UN PEDIDO PROVISION</asp:Label>
    <hr />
    <div class="row">
        <div class="col-lg-4">
            <Label class="font-weight-normal">INGRESE NOMBRE DEL ARTICULO A PEDIR:<br />
            </Label>
        &nbsp;</div>
        <div class="col-lg-2">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-info" OnClick="Button1_Click" Text="BUSCAR" />
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        &nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="id" HorizontalAlign="Center">
            <Columns>
                <asp:CommandField ShowSelectButton="True" HeaderText="SELECCIONAR" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                <asp:BoundField DataField="descripcion_adicional" HeaderText="DESCRIPCIÓN ADICIONAL" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <br />
        <asp:Button ID="Button_NoExisteA" runat="server" Text="No existe el articulo" CssClass="btn btn-lg btn-warning" OnClick="Button_NoExisteA_Click" />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
        <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="Label4" class="font-weight-normal" runat="server" Text="CANTIDAD:" Visible="False"></asp:Label>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="TextBox2"  class="form-control" runat="server" Visible="False" required="True"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" class="btn btn-lg btn-primary" OnClick="Button2_Click" Text="AGREGAR" Visible="False" />
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" HorizontalAlign="Center" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id articulo" HeaderText="ID ARTICULO" />
                <asp:BoundField HeaderText="ARTICULO" DataField="articulo" />
                <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" />
                <asp:CommandField ShowEditButton="True" HeaderText="EDITAR" />
                <asp:CommandField ShowDeleteButton="True" HeaderText="ELIMINAR" />
            </Columns>
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <br />
        <div class="row">
            <div class="col-lg-2">

            </div>
            <div class="col-lg-4">
                <asp:Button ID="Button3" class="btn btn-lg btn-danger" runat="server" Text="CANCELAR" OnClick="Button3_Click" />
            </div>
            <div class="col-lg-2">

            </div>
            <div class="col-lg-4">
                <asp:Button ID="Button4" class="btn btn-lg btn-success" runat="server" Text="FINALIZAR" OnClick="Button4_Click" />
            </div>
        </div>
    </asp:Panel>
<asp:Panel ID="Panel2" runat="server" CssClass="form-control" Visible="false">
       
            <Label class="font-weight-normal">INGRESE DESCRIPCION COMPLETA DEL ARTICULO A PEDIR:</Label>
        
        
            <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
       <br />
        <Label class="font-weight-normal">DESCRIPCION ADICIONAL:</Label>
        <asp:TextBox ID="TextBox4" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">FAMILIA:</Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        <br />
        <Label class="font-weight-normal">UNIDAD:</Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
            </asp:DropDownList>
        <br />
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="btn_cancelar" runat="server" Text="CANCELAR" class="btn btn-lg btn-danger" OnClick="btn_cancelar_Click" />
            </div>
            <div class="col-lg-4">
            </div>
            <div class="col-lg-4">
                <asp:Button ID="btn_guardar" runat="server" class="btn btn-lg btn-success" OnClick="btn_guardar_Click" Text="GUARDAR ARTICULO" />
            </div>
        </div>
    </asp:Panel>
    
</asp:Content>
