<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VPedidos.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            POR ID:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            <br />
            <br />
&nbsp;
            <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="Button2" runat="server" Text="REALIZAR SUMINISTRO" />
    </form>
</body>
</html>
