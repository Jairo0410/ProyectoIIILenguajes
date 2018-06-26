<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddOffer.aspx.cs" Inherits="ProyectoIIILenguajes.AddOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="itemsHolder" runat="server"></asp:PlaceHolder>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                
        </ContentTemplate>
    </asp:UpdatePanel>

    <div>
        <asp:PlaceHolder ID="footerHolder" runat="server"></asp:PlaceHolder>
    </div>
    <br />
    <br />
    <div>
        <asp:PlaceHolder ID="Messages" runat="server"></asp:PlaceHolder>
    </div>
    
</asp:Content>
