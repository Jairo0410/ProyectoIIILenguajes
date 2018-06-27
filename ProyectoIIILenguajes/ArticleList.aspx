<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="ProyectoIIILenguajes.ArticleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:PlaceHolder ID="itemsHolder" runat="server"></asp:PlaceHolder>
            </div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>

            <asp:PlaceHolder ID="messageHolder" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
