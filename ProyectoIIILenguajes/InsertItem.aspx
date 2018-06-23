<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="InsertItem.aspx.cs" Inherits="ProyectoIIILenguajes.InsertItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-lg-6 col-lg-offset-3">
                <div>
                    <h3> Insertar Categoría </h3>
                </div>
                <div>
                    Nombre de la categoría
                    <asp:TextBox ID="tbCategoryName" class="form-control" runat="server"></asp:TextBox>
                </div>
                <br/>
                <div>
                    <asp:Button ID="btnAddCategory" class="btn btn-default" runat="server" Text="Añadir Categoría" OnClick="btnAddCategory_Click" />
                    <div>
                        <asp:Label ID="lblMessageCategoria" runat="server"></asp:Label>
                    </div>
                    <h3>Insertar Artículo</h3>
                    <div>
                        Categoría
                    </div>
                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                        </asp:DropDownList>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <div class="col-lg-6 col-lg-offset-3">
        <div>
        </div>
        <div>
            Nombre
            <asp:TextBox ID="tbName" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            Precio
            (en dólares)
            <asp:TextBox ID="tbPrice" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <div>
            Descripción
            <asp:TextBox ID="tbDescription" class="form-control" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            Imagen
            <asp:FileUpload ID="ImageUpload" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
        </div>
        <div>
            <asp:Label ID="lblMessageAdd" runat="server"></asp:Label>
        </div>
    </div>
    
</asp:Content>
