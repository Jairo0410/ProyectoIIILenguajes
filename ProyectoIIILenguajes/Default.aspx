<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoIIILenguajes.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6 col-lg-offset-3">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="tbUsername" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <br/>
        <div>
            <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" OnClick="btnLogin_Click" Text="Ingresar" />
        </div>
        <br />
        <div>
            <asp:PlaceHolder ID="messageHolder" runat="server"></asp:PlaceHolder>
        </div>
        
    </div>
</asp:Content>
