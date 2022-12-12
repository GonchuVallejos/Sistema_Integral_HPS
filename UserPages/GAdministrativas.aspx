<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="GAdministrativas.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.GAdministrativas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">GESTIONES ADMINISTRATIVAS</asp:Label>
    <hr />
    <div style="background-color: aqua">
        <asp:Label ID="Label2" class="justify-content-center h2" runat="server">SERVICIOS/DIVISIONES</asp:Label>
    </div>
    <hr />
    <asp:Label ID="Label3" class="justify-content-center h3" runat="server">REGISTRAR NUEVO SERVICIO/DIVISION</asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3">
            <asp:Label ID="Label4" runat="server" CssClass="font-weight-normal" Text="DIRECCION"></asp:Label>
            <asp:DropDownList ID="DropDownList1" CssClass="form-select text-uppercase" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="col-lg-7">
            <asp:Label ID="Label5" runat="server" CssClass="font-weight-normal" Text="NOMBRE DEL SERVICIO/DIVISION" Visible="False"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-uppercase" Visible="False"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:Button ID="Button1" CssClass="btn btn-success btn-lg" runat="server" Text="REGISTRAR" OnClick="Button1_Click" Visible="False" />
        </div>
    </div>
    <br />
    <hr />
    <asp:Label ID="Label6" class="justify-content-center h3" runat="server">MODIFICAR</asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3">
            <asp:Label ID="Label7" runat="server" CssClass="font-weight-normal" Text="NOMBRE DEL SERVICIO/DIVISION"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:Button ID="Button2" CssClass="btn btn-info btn-lg" runat="server" Text="BUSCAR" OnClick="Button2_Click" />
        </div>
    </div>
    <br />
    <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDSD" PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IDSD" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" />
            <asp:BoundField DataField="SERVICIO/DIVISION" HeaderText="SERVICIO/DIVISION" />
        </Columns>
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="row">
            <div class="col-3">
                <asp:Label ID="Label8" runat="server" CssClass="font-weight-normal" Text="DIRECCION"></asp:Label>
                <asp:DropDownList ID="DropDownList2" CssClass="form-select text-uppercase" runat="server"></asp:DropDownList>
            </div>
            <div class="col-lg-7">
                <asp:Label ID="Label9" runat="server" CssClass="font-weight-normal" Text="NOMBRE DEL SERVICIO/DIVISION"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
            </div>
            <div class="col-lg-2 d-grid">
                <asp:Button ID="Button3" CssClass="btn btn-warning btn-lg" runat="server" Text="ACTUALIZAR" OnClick="Button3_Click" />
            </div>
        </div>
        <br />
    </asp:Panel>
    <hr />
    <asp:Label ID="Label10" class="justify-content-center h2" runat="server">UNIDADES/SECCIONES</asp:Label>
    <hr />
    <asp:Label ID="Label11" class="justify-content-center h3" runat="server">REGISTRAR NUEVA UNIDAD/SECCION</asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-2">
            <asp:Label ID="Label12" runat="server" CssClass="font-weight-normal" Text="DIRECCION"></asp:Label>
            <asp:DropDownList ID="DropDownList3" CssClass="form-select text-uppercase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:Label ID="Label13" runat="server" CssClass="font-weight-normal" Text="SERVICIO/DIVISION"></asp:Label>
            <asp:DropDownList ID="DropDownList4" CssClass="form-select text-uppercase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-lg-6">
            <asp:Label ID="Label14" runat="server" CssClass="font-weight-normal" Text="NOMBRE DE LA UNIDAD/SECCION" Visible="False"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control text-uppercase" Visible="False"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:Button ID="Button4" CssClass="btn btn-success btn-lg" runat="server" Text="REGISTRAR" OnClick="Button4_Click" />
        </div>
    </div>
    <br />
    <hr />
    <asp:Label ID="Label15" class="justify-content-center h3" runat="server">MODIFICAR</asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3">
            <asp:Label ID="Label16" runat="server" CssClass="font-weight-normal" Text="NOMBRE DE LA UNIDAD/SECCION"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:Button ID="Button5" CssClass="btn btn-info btn-lg" runat="server" Text="BUSCAR" OnClick="Button5_Click" />
        </div>
    </div>
    <br />
    <asp:GridView ID="GridView2" runat="server" class="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IDUS" PageSize="5" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IDUS" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="IDD" HeaderText="IDD" Visible="False" />
            <asp:BoundField DataField="IDSD" HeaderText="IDSD" Visible="False" />
            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" />
            <asp:BoundField DataField="SERVICIO/DIVISION" HeaderText="SERVICIO/DIVISION" />
            <asp:BoundField DataField="UNIDAD/SECCION" HeaderText="UNIDAD/SECCION" />
        </Columns>
        <HeaderStyle BackColor="#1D7FAC" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="Label17" runat="server" CssClass="font-weight-normal" Text="DIRECCION"></asp:Label>
                <asp:DropDownList ID="DropDownList5" CssClass="form-select text-uppercase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <asp:Label ID="Label18" runat="server" CssClass="font-weight-normal" Text="SERVICIO/DIVISION"></asp:Label>
                <asp:DropDownList ID="DropDownList6" CssClass="form-select text-uppercase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-lg-6">
                <asp:Label ID="Label19" runat="server" CssClass="font-weight-normal" Text="NOMBRE DE LA UNIDAD/SECCION"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
            </div>
            <div class="col-lg-2 d-grid">
                <asp:Button ID="Button6" CssClass="btn btn-warning btn-lg" runat="server" Text="ACTUALIZAR" OnClick="Button6_Click" />
            </div>
        </div>
        <br />
    </asp:Panel>
    <br />
</asp:Content>
