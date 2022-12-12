<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sistema_Integral_HPS.UserPages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=devide-width, initial-scale=1.0" />
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous" />
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="Users.css" />
    <title>LOGIN SISTEMA INTEGRAL HPS</title>
</head>
<body style="display: grid; min-height: 100vh; grid-template-rows: auto 1fr auto;">
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center">
            <div class="col-6">
                <div class="form-control card card-body" id="login">
                    <div class="row justify-content-center">
                        <asp:Label ID="Label1" class="row justify-content-center h1" runat="server">INICIAR SESION</asp:Label>
                        <hr class="hr" />
                        <p></p>
                        <asp:Label ID="Label2" class="row justify-content-center h3" runat="server">USUARIO</asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Ingrese usuario" required="True"></asp:TextBox>
                        <p></p>
                        <asp:Label ID="Label3" class="row justify-content-center h3" runat="server">CONTRASEÑA</asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Ingrese contraseña" TextMode="Password" required="True"></asp:TextBox>
                        <p></p>
                        <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary" Text="INGRESAR" OnClick="Button1_Click" OnClientClick="Alerta" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap core JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>

    <!-- Footer -->
    <footer class="py-2" style="background-color: #1D7FAC; margin-top: 1em; position:absolute; bottom:0; width:100%">
        <div class="container">
            <p class="m-0 text-center text-white" id="clfooter">&copy; HOSPITAL PABLO SORIA - 2022</p>
        </div>
    </footer>
</body>
</html>
