<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="Adquisicion.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.Adquisicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" runat="server" class="justify-content-center h1">ADQUISICIONES</asp:Label>
    <br />
    <br />
    TIPO:
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>PROPIA</asp:ListItem>
        <asp:ListItem>DONACION</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="CARGAR" />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <Label class="font-weight-normal">INGRESE EL AÑO:</Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
        <br />
        SELECCIONE PROVEEDOR:
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        INGRESE ORDEN DE COMPRA:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
        N° EXPEDIENTE:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <br />
        N° REMITO:
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Visible="false">

         INGRESE NOMBRE DE DONADOR/PRESTADOR:&nbsp;<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </asp:Panel>
    

    <asp:Panel ID="Panel2" runat="server" Visible="false">




          <div class="col-lg-4">
            
             
              <br />
              <Label class="font-weight-normal">
              <br />
              INGRESE NOMBRE DEL ARTICULO A ADQUIRIR:</Label>
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              &nbsp;<br />
            <asp:Button ID="Button1" class="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button1_Click" />
            <br />
            <br />
    </div>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
          <br />
          ARTICULO:
          <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
          <br />
          <br />
          CANTIDAD:
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    OBSERVACIONES:<br />
    <br />
    <asp:TextBox ID="TextBox4" runat="server" Height="96px" Width="544px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button2" class="btn btn-lg btn-info" runat="server" Text="AGREGAR ITEM" OnClick="Button2_Click" />
    <br />
<br />
<asp:GridView ID="GridView2" runat="server" OnRowDeleting="GridView2_RowDeleting">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" />
    </Columns>
</asp:GridView>
    <br />
    <br />
    <asp:Button ID="Button3"  class="btn btn-lg btn-info" runat="server" Text="FINALIZAR ADQUISICION" OnClick="Button3_Click" />



    </asp:Panel>
  
</asp:Content>
