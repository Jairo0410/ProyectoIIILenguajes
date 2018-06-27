<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ProyectoIIILenguajes.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal" id="checkModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"> Cambiar Fecha </h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label1" runat="server" Text="Nueva Fecha:"></asp:Label>
                    <asp:TextBox ID="tbDate" class="form-control" TextMode="Date" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCheckout" class="btn btn-primary pull-left" runat="server" Text="Checkout" OnClick="btnCheckoutClicked"/>
                </div>
            </div>
        </div>
    </div>

    <div>
        <asp:PlaceHolder ID="cartHolder" runat="server"></asp:PlaceHolder>
    </div>
    <div>
        <asp:PlaceHolder ID="messageHolder" runat="server"></asp:PlaceHolder>
    </div>
    
</asp:Content>
