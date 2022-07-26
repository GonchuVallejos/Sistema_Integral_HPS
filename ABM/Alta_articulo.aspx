<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alta_articulo.aspx.cs" Inherits="Sistema_Integral_HPS.ABM.Alta_articulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
            STOCK QUE INGRESA:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
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
    </form>
</body>
</html>
