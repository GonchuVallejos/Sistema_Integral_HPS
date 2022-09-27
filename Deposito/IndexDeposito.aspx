<%@ Page Title="" Language="C#" MasterPageFile="~/Deposito/MasterDeposito.Master" AutoEventWireup="true" CodeBehind="IndexDeposito.aspx.cs" Inherits="Sistema_Integral_HPS.Deposito.IndexDeposito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center d-flex justify-content-center align-items-center my-lg-5">
        <asp:Image ID="Image1" runat="server" Width="40%" ImageAlign="Middle" ImageUrl="~/Images/Logo HPS.svg"/>

    </div>
    <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
  <symbol id="check-circle-fill" fill="currentColor" viewBox="0 0 16 16">
    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z"/>
  </symbol>
  <symbol id="info-fill" fill="currentColor" viewBox="0 0 16 16">
    <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z"/>
  </symbol>
  <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
    <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
  </symbol>
</svg>

    <asp:Panel ID="Panel1" runat="server" Visible="False" >
       <div class="alert alert-danger d-flex align-items-center" role="alert">
              <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:"><use xlink:href="#exclamation-triangle-fill"/></svg>
             <div>
                 <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Red" OnClick="LinkButton3_Click">EXISTEN ARTICULOS POR DEBAJO DEL MINIMO DE STOCK ! </asp:LinkButton>
             </div>
       </div>
       <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False" >
        <HeaderStyle BackColor="#f8d7da" ForeColor="#842029" HorizontalAlign="Center" VerticalAlign="Middle" />
       </asp:GridView>
    </asp:Panel>

     <asp:Panel ID="Panel2" runat="server" Visible="False" >
        <div class="alert alert-warning d-flex align-items-center" role="alert">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Warning:"><use xlink:href="#exclamation-triangle-fill"/></svg>
            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue" OnClick="LinkButton2_Click">ALGUNOS ARTICULOS DEBERIAN REPONERSE</asp:LinkButton>
            
        </div>
         <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-condensed table-responsive" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False" >
            <HeaderStyle BackColor="#cff4fc" ForeColor="#04414d" HorizontalAlign="Center" VerticalAlign="Middle" />
         </asp:GridView>
          
     </asp:Panel>

    
        
     
   
</asp:Content>

