<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="GestionProducto.aspx.cs" Inherits="TiendaGamingWebForms.GestionProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-8">
        <div class="flex justify-between items-center mb-6">
            <h2 class="text-3xl font-bold dark:text-white">Gestión de Productos</h2>
            <a href="FormularioProducto.aspx" class="bg-green-600 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
                + Nuevo Producto
            </a>
        </div>

        <div class="overflow-x-auto bg-white/5 rounded-lg">
            <asp:GridView ID="gvGestionProductos" runat="server" AutoGenerateColumns="false"
                CssClass="w-full text-sm text-left text-gray-400"
                HeaderStyle-CssClass="text-xs uppercase bg-gray-700 text-gray-200"
                RowStyle-CssClass="border-b border-gray-700 bg-gray-800 hover:bg-gray-600"
                OnSelectedIndexChanged="gvGestionProductos_SelectedIndexChanged"
                OnRowDeleting="gvGestionProductos_RowDeleting"
                DataKeyNames="Id"> 

                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" ItemStyle-CssClass="px-6 py-4" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-CssClass="px-6 py-4 font-medium text-white" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" ItemStyle-CssClass="px-6 py-4" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" ItemStyle-CssClass="px-6 py-4" />
                    
                    <asp:CommandField ShowSelectButton="true" SelectText="✏️" ControlStyle-CssClass="text-blue-500 text-xl mr-2" HeaderText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="🗑️" ControlStyle-CssClass="text-red-500 text-xl" HeaderText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
