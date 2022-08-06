﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="APedido.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.APedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" class="justify-content-center h1" runat="server">REGISTRAR UN PEDIDO</asp:Label>
    <hr />
    <div class="row">
        <div class="col-lg-3">
            <Label class="font-weight-normal">INGRESE NOMBRE DEL ARTICULO A PEDIR:</Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" required="True"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-info" OnClick="Button1_Click" Text="BUSCAR" />
        </div>
    </div>
    <Label class="font-weight-normal">SELECCIONAR ARTICULO</Label>
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
    <div class="row">
        <div class="col-lg-3">
            <Label class="font-weight-normal">CANTIDAD:</Label>
        </div>
        <div class="col-lg-2">
            <asp:TextBox ID="TextBox2"  class="form-control" runat="server" Visible="False" required="True"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <asp:Button ID="Button2" runat="server" class="btn btn-lg btn-primary" OnClick="Button2_Click" Text="AGREGAR AL PEDIDO" Visible="False" />
        </div>
    </div>
    
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3">
            <Label class="font-weight-normal">OBSERVACIONES:</Label>
        </div>
        <div class="col-lg-9">
            <asp:TextBox ID="TextBox3" class="form-control" runat="server" required="True"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDeleting="GridView2_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id articulo" HeaderText="ID ARTICULO" />
            <asp:BoundField HeaderText="ARTICULO" DataField="articulo" />
            <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-2">

        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button3" class="btn btn-lg btn-danger" runat="server" Text="CANCELAR" />
        </div>
        <div class="col-lg-2">

        </div>
        <div class="col-lg-4">
            <asp:Button ID="Button4" class="btn btn-lg btn-success" runat="server" Text="FINALIZAR" OnClick="Button4_Click" />
        </div>
    </div>
    
</asp:Content>
