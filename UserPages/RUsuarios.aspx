<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSistemaIntegralSoria.Master" AutoEventWireup="true" CodeBehind="RUsuarios.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.RUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="Label1" class="justify-content-center h1" runat="server">REGISTRAR UN NUEVO USUARIO</asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-4">
            <asp:Label ID="Label32" runat="server" CssClass="font-weight-normal" Text="TIPO DOCUMENTO"></asp:Label>
            <asp:DropDownList ID="DropDownList14" runat="server" CssClass="form-select text-uppercase">
                <asp:ListItem>SELECCIONE</asp:ListItem>
                <asp:ListItem Value="DNI">DOCUMENTO NACIONAL DE IDENTIDAD</asp:ListItem>
                <asp:ListItem Value="LC">LIBRETA CIVICA</asp:ListItem>
                <asp:ListItem Value="LE">LIBRETA DE ENROLAMIENTO</asp:ListItem>
                <asp:ListItem Value="PASS">PASAPORTE</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-lg-4">
            <asp:Label ID="Label33" runat="server" CssClass="font-weight-normal" Text="DOCUMENTO N°"></asp:Label>
            <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control text-uppercase" TextMode="Number" MaxLength="8" Placeholder="SIN PUNTOS NI ESPACIOS"></asp:TextBox>
        </div>
        <div class="col-lg-2 d-grid">
            <asp:Button ID="Button3" CssClass="btn btn-lg btn-info" runat="server" Text="VALIDAR" OnClick="Button3_Click" />
        </div>
    </div>
    <br />
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label2" class="justify-content-center h3" runat="server">DATOS PERSONALES</asp:Label>
            <hr />
            <br />
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" CssClass="font-weight-normal" Text="APELLIDO"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="Label4" runat="server" CssClass="font-weight-normal" Text="NOMBRE"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="Label6" runat="server" CssClass="font-weight-normal" Text="FECHA DE NACIMIENTO"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label7" runat="server" CssClass="font-weight-normal" Text="SEXO"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select text-uppercase">
                        <asp:ListItem>Seleccione</asp:ListItem>
                        <asp:ListItem>MASCULINO</asp:ListItem>
                        <asp:ListItem>FEMENINO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label8" runat="server" CssClass="font-weight-normal" Text="TELEFONO"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control text-uppercase" TextMode="Phone"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Label19" runat="server" CssClass="font-weight-normal" Text="CALLE"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label17" runat="server" CssClass="font-weight-normal" Text="N°"></asp:Label>
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label25" runat="server" CssClass="font-weight-normal" Text="PISO"></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label26" runat="server" CssClass="font-weight-normal" Text="DPTO"></asp:Label>
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-2">
                    <asp:Label ID="Label34" runat="server" CssClass="font-weight-normal" Text="MANZANA"></asp:Label>
                    <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label35" runat="server" CssClass="font-weight-normal" Text="LOTE"></asp:Label>
                    <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="Label36" runat="server" CssClass="font-weight-normal" Text="CASA"></asp:Label>
                    <asp:TextBox ID="TextBox16" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="Label37" runat="server" CssClass="font-weight-normal" Text="BARRIO"></asp:Label>
                    <asp:TextBox ID="TextBox17" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="Label27" runat="server" CssClass="font-weight-normal" Text="PROVINCIA"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select text-uppercase" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True">SELECCIONE</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label28" runat="server" CssClass="font-weight-normal" Text="DEPARTAMENTO"></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select text-uppercase" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label29" runat="server" CssClass="font-weight-normal" Text="LOCALIDAD"></asp:Label>
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select text-uppercase">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <asp:Label ID="Label5" runat="server" CssClass="font-weight-normal" Text="EMAIL"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control text-uppercase" TextMode="Email"></asp:TextBox>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label9" class="justify-content-center h3" runat="server">DATOS LABORALES</asp:Label>
            <hr />
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="Label10" runat="server" CssClass="font-weight-normal" Text="DIRECCIÓN"></asp:Label>
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-select text-uppercase" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label11" runat="server" CssClass="font-weight-normal" Text="SERVICIO/DIVISIÓN"></asp:Label>
                    <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-select text-uppercase" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label12" runat="server" CssClass="font-weight-normal" Text="UNIDAD/SECCIÓN"></asp:Label>
                    <asp:DropDownList ID="DropDownList7" runat="server" CssClass="form-select text-uppercase" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label23" runat="server" CssClass="font-weight-normal" Text="PUESTO DE TRABAJO"></asp:Label>
                    <asp:DropDownList ID="DropDownList8" runat="server" CssClass="form-select text-uppercase" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                        <asp:ListItem>ADMINISTRATIVO</asp:ListItem>
                        <asp:ListItem>JEFE DE SECTOR</asp:ListItem>
                        <asp:ListItem>SECRETARIO/SECRETARIA</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" Visible="false">
            <asp:Label ID="Label13" class="justify-content-center h3" runat="server">DATOS PROFESIONALES</asp:Label>
            <hr />
            <br />
            <asp:Label ID="Label21" class="justify-content-center h4" runat="server"></asp:Label>
            <hr />
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="Label14" runat="server" CssClass="font-weight-normal" Text="CARGO"></asp:Label>
                    <asp:DropDownList ID="DropDownList9" runat="server" CssClass="form-select text-uppercase" AutoPostBack="True" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                        <asp:ListItem>ADM</asp:ListItem>
                        <asp:ListItem>AUX</asp:ListItem>
                        <asp:ListItem>DR</asp:ListItem>
                        <asp:ListItem>DRA</asp:ListItem>
                        <asp:ListItem>TEC</asp:ListItem>
                        <asp:ListItem>LIC</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label15" runat="server" CssClass="font-weight-normal" Text="ESPECIALIDAD"></asp:Label>
                    <asp:DropDownList ID="DropDownList10" runat="server" CssClass="form-select text-uppercase">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label16" runat="server" CssClass="font-weight-normal" Text="MATRICULA N°"></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="Label18" runat="server" CssClass="font-weight-normal" Text="LEGAJO N°"></asp:Label>
                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="Label30" runat="server" CssClass="font-weight-normal" Text="SITUACIÓN DE REVISTA"></asp:Label>
                    <asp:DropDownList ID="DropDownList11" runat="server" CssClass="form-select text-uppercase"></asp:DropDownList>
                </div>
                <div class="col-lg-9">
                    <asp:Label ID="Label20" runat="server" CssClass="font-weight-normal" Text="TITULO"></asp:Label>
                    <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                </div>
            </div>

        </asp:Panel>
        <br />
        <asp:Panel ID="Panel4" runat="server" Visible="false">
            <asp:Label ID="Label22" class="justify-content-center h3" runat="server">PERMISOS DE ACCESO</asp:Label>
            <hr />
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="Label24" runat="server" CssClass="font-weight-normal" Text="SISTEMA"></asp:Label>
                    <asp:DropDownList ID="DropDownList12" runat="server" CssClass="form-select text-uppercase">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                        <asp:ListItem Value="0">GRAL COMO VISUALIZADOR</asp:ListItem>
                        <asp:ListItem Value="1">GRAL COMO ADMINISTRADOR</asp:ListItem>
                        <asp:ListItem Value="2">ADMISION DE GUARDIA</asp:ListItem>
                        <asp:ListItem Value="3">DEPOSITO</asp:ListItem>
                        <asp:ListItem Value="4">QUIROFANO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="Label31" runat="server" CssClass="font-weight-normal" Text="ROL"></asp:Label>
                    <asp:DropDownList ID="DropDownList13" runat="server" CssClass="form-select text-uppercase">
                        <asp:ListItem>SELECCIONE</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <br />
        <div class="row">
            <div class="col-lg-6 d-flex justify-content-center">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-success" Text="REGISTRAR" OnClick="Button1_Click" />
            </div>
            <div class="col-lg-6 d-flex justify-content-center">
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-danger" Text="CANCELAR" OnClick="Button2_Click" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
