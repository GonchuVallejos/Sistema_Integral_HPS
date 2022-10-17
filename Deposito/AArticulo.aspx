<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="AArticulo.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.AArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label3" class="justify-content-center h1" runat="server">REGISTRAR UN NUEVO ARTICULO</asp:Label>
    <hr />
    <div class="row">
        <div class="col-lg-4">
            <Label class="font-weight-normal">INGRESE UN NUEVO ARTICULO:</Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-lg btn-info" Text="Buscar" />
        </div>
    </div>
    <div class="col-lg-8">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive" PageSize="10" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
            <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
    <div class="col-lg-4">
        <asp:Button ID="Button2" runat="server" Text="Agregar Nuevo" visible="false" CssClass="btn btn-lg btn-warning" OnClick="Button2_Click"/>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="form-control" Visible="false">
        <Label class="font-weight-normal">DESCRIPCION ADICIONAL:</Label>
        <asp:TextBox ID="TextBox2" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">FAMILIA:</Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        <br />
        <Label class="font-weight-normal">UNIDAD:</Label>
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
            </asp:DropDownList>
        <br />
        <Label class="font-weight-normal">DEPOSITO:</Label>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select">
            </asp:DropDownList>
        <br />
        <Label class="font-weight-normal">STOCK:</Label>
        <asp:TextBox ID="TextBox7" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">MINIMO A TENER:</Label>
        <asp:TextBox ID="TextBox4" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">MAXIMO A TENER:</Label>
        <asp:TextBox ID="TextBox5" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">STOCK PUNTO A PEDIR:</Label>
        <asp:TextBox ID="TextBox6" runat="server" class="form-control" required="True"></asp:TextBox>
        <br />
        <Label class="font-weight-normal">INVENTARIABLE:</Label>
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select">
                <asp:ListItem Value="NO">NO</asp:ListItem>
                <asp:ListItem Value="SI">SI</asp:ListItem>
                <asp:ListItem Value="PENDIENTE">PENDIENTE</asp:ListItem>
            </asp:DropDownList>
        <br />
        <Label class="font-weight-normal">HABILITADO?:</Label>
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-select">
                <asp:ListItem>SI</asp:ListItem>
                <asp:ListItem>NO</asp:ListItem>
            </asp:DropDownList>
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
