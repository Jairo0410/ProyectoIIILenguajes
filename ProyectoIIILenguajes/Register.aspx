<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProyectoIIILenguajes.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Nombre
        <asp:TextBox ID="tbName" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div>
        Edad
        <asp:TextBox ID="tbAge" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
    </div>
    <div>
        Género
        <asp:DropDownList ID="ddlGender" class="form-control" runat="server">
            <asp:ListItem>Masculino</asp:ListItem>
            <asp:ListItem Value="F">Femenino</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        Contraseña
        <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>

        <asp:Button ID="btnRegister" class="btn btn-primary" runat="server" Text="Registrarse" OnClick="btnRegister_Click" />

    </div>
    <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    
</asp:Content>
