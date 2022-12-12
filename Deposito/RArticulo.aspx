<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="RArticulo.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.RArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Label ID="Label1" class="justify-content-center h1" runat="server">REPORTE CONSUMO POR ARTICULO</asp:Label>
    <hr />
    <asp:Label ID="Label2" runat="server" class="justify-content-center" Text="Ingrese el ID del producto: "></asp:Label>
     <asp:TextBox ID="TextBox1" runat="server" required="True" OnTextChanged="TextBox1_TextChanged" TextMode="Number"></asp:TextBox>

    &nbsp;

    <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-success" OnClick="Button1_Click" Text="BUSCAR" Width="197px" />


     <br />
     <br />
     <div>
         <asp:Label ID="Label3" runat="server" Text="INICIO:"></asp:Label>
         <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FIN:&nbsp;
         <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
     </div>
     <br />

    
        <asp:GridView ID="GridView1" style="margin-top: 6px; text-align: center; width:90%" HorizontalAlign="Center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>




  
</asp:Content>
