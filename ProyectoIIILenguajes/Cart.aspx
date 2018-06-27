<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProyectoIIILenguajes.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:PlaceHolder ID="cartHolder" runat="server"></asp:PlaceHolder>
    </div>
    <div>
        <asp:PlaceHolder ID="messageHolder" runat="server"></asp:PlaceHolder>
    </div>
    </asp:Content>
