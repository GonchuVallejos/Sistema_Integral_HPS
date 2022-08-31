<%@ Page Title="" Language="C#" MasterPageFile="~/RexyReport/MasterRexy.Master" AutoEventWireup="true" CodeBehind="Vista.aspx.cs" Inherits="Sistema_Integral_HPS.RexyReport.Vista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:Label ID="Label1" class="justify-content-center h1" runat="server">REXY REPORT</asp:Label>
    <hr />
      <br />
      <br />
      <br />
      <br />
      NOMBRE
      PACIENTE:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
      <asp:Button ID="Button1"  class="btn btn-lg btn-info" runat="server" Text="BUSCAR" />
      <br />
      <br />
      DNI PACIENTE:<asp:TextBox ID="TextBox2" class="btn btn-lg btn-info" runat="server"></asp:TextBox>
&nbsp;
      <asp:Button ID="Button2" class="btn btn-lg btn-info" runat="server" Text="Button" />
      <br />
      <br />
      H. CLINICA:
      <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;
      <asp:Button ID="Button3" class="btn btn-lg btn-info" runat="server" Text="Button" />
      <br />
      <asp:GridView ID="GridView1" style="margin-top: 6px; text-align: center; width:90%" runat="server">
      </asp:GridView>
</asp:Content>
