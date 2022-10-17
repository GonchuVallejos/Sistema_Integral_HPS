<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="Ajustes.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.Ajustes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label3" runat="server" class="justify-content-center h1">AJUSTES</asp:Label>
    <hr />
     <div class="col-lg-4">
            <Label class="font-weight-normal">INGRESE NOMBRE DEL ARTICULO A AJUSTAR:</Label>
        </div>
       <div class="col-lg-2">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button1" class="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button1_Click" />
            <br />
        </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label4" runat="server" Text="INGRESE EL TIPO DE AJUSTE:" Visible="False"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" Visible="False" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="Positivo">Positivo</asp:ListItem>
        <asp:ListItem Value="Negativo">Negativo</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="ID ARTICULO SELECCIONADO:" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="CANTIDAD:" Visible="False"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="OBSERVACIONES:" Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox3" runat="server" Height="63px" Visible="False" Width="723px"></asp:TextBox>
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDeleted="GridView2_RowDeleted" OnRowDeleting="GridView2_RowDeleting">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <asp:Button ID="Button2" class="btn btn-lg btn-info" runat="server" Text="Agregar al Ajuste" OnClick="Button2_Click" Visible="False" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="Button3" class="btn btn-lg btn-info" runat="server" OnClick="Button3_Click" Text="Finalizar el Ajuste" />
</asp:Content>
