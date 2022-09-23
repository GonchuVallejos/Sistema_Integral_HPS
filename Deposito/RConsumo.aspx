<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="RConsumo.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.RConsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">REPORTE CONSUMO POR SERVICIOS</asp:Label>
    <hr />

    <asp:Panel runat="server" ID="Panel1">
        <asp:Label ID="Label2" runat="server" class="justify-content-center" Text="Seleccione el servicio: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
        </asp:DropDownList>




        &nbsp;<br />&nbsp;<br /><br />
        <div>
            <asp:Label ID="Label3" runat="server" Text="INICIO:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FIN:&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
        </div>
&nbsp;  
        <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-success" OnClick="Button1_Click" Text="CARGAR" Width="197px" />
        <br />
        </asp:Panel>

    
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
