<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="ProyectoIIILenguajes.ArticleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="itemsHolder" runat="server"></asp:PlaceHolder>
                <asp:ScriptManager runat="server"></asp:ScriptManager>

                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>
    
</asp:Content>
