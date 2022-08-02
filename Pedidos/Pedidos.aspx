﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Sistema_Integral_HPS.Pedidos.Pedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REGISTRAR UN PEDIDO<br />
            <br />
            <br />
            INGRESE NOMBRE DEL ARTICULO A PEDIR:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="BUSCAR" />
            <br />
            <br />
            SELECCIONAR ARTICULO<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-top: 6px" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="descripcion_adicional" HeaderText="Descripcion_adicional" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            CANTIDAD : <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="AGREGAR AL PEDIDO" Visible="False" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            OBSERVACIONES:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id articulo" HeaderText="ID ARTICULO" />
                    <asp:BoundField HeaderText="ARTICULO" DataField="articulo" />
                    <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="CANCELAR" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="FINALIZAR" OnClick="Button4_Click" />
        </div>
    </form>
</body>
</html>