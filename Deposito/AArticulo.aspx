<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="AArticulo.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.AArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <p>
            REGISTRO DE UN NUEVO ARTICULO</p>
        <p>
            NOMBRE :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            DESCRIPCION ADICIONAL:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            FAMILIA:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            MEDIDA: <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            DEPOSITO:
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            STOCK MINIMO A TENER:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            STOCK MAXIMO A TENER:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            STOCK PUNTO A PEDIR:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            INVENTARIABLE:
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem Value="NO">NO</asp:ListItem>
                <asp:ListItem Value="SI">SI</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            HABILITADO? : <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem>SI</asp:ListItem>
                <asp:ListItem>NO</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            PRECIO CON EL QUE INGRESA: <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="GUARDAR ARTICULO" />
        </p>
        <p>
            <asp:Button ID="btn_cancelar" runat="server" Text="CANCELAR" OnClick="btn_cancelar_Click" />
        </p>
        <p>
            &nbsp;</p>
</asp:Content>
