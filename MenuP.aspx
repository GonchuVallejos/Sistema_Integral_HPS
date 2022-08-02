<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuP.aspx.cs" Inherits="Sistema_Integral_HPS.MenuP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            MENU PRINCIPAL<br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ALTA ARTICULO" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="HACER PEDIDO" />
    </form>
</body>
</html>
