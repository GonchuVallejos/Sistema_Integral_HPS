<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="VAlertas.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.VAlertas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <HeaderStyle BackColor="#f8d7da" ForeColor="#842029" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <asp:Panel ID="Panel2" runat="server">
            <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <HeaderStyle BackColor="#cff4fc" ForeColor="#04414d" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
            <asp:Panel ID="Panel3" runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Volver " />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
