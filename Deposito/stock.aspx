﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="Sistema_Integral_HPS.stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="h1 justify-content-center" runat="server">VER STOCK</asp:Label>
    <hr />
     <div class="col-lg-4">
            <Label class="font-weight-normal">
            <asp:Label ID="Label2" runat="server" Text="VER POR"></asp:Label>
            :
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" OnPreRender="DropDownList1_PreRender" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnTextChanged="DropDonList1_TextChanged">
                <asp:ListItem>NOMBRE</asp:ListItem>
                <asp:ListItem>FAMILIA</asp:ListItem>
                <asp:ListItem>ID</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="Button4" class="btn btn-lg btn-info" runat="server" OnClick="Button4_Click" Text="CARGAR" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="INGRESE EL NOMBRE DEL ARTICULO A BUSCAR:" Visible="False"></asp:Label>
            </Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" class="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button1_Click" Visible="False" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="SELECCIONE FAMILIA:" Visible="False"></asp:Label>
            <asp:DropDownList ID="DropDownList2" CssClass="form-select" runat="server" Visible="False">
            </asp:DropDownList>
&nbsp;<br />
            <br />
            <asp:Button ID="Button2" runat="server" class="btn btn-lg btn-info" Text="VER FAMILIA" OnClick="Button2_Click" Visible="False" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="INGRESE ID:" Visible="False"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Visible="False" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:Button ID="Button3"  class="btn btn-lg btn-info" runat="server" Text="BUSCAR" OnClick="Button3_Click" Visible="False" />
        </div>
    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" runat="server">
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
