<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TiendaGamingWebForms.FormularioProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-10 px-4 max-w-2xl">
    <h2 class="text-3xl font-bold mb-8 dark:text-white text-center">
        <asp:Label ID="lblTitulo" runat="server" Text="Nuevo Producto"></asp:Label>
    </h2>

    <div class="bg-white/5 dark:bg-[#191933] p-8 rounded-xl border border-gray-700 shadow-lg space-y-6">
        
        <div class="grid grid-cols-1 gap-6 md:grid-cols-2">
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0"></asp:TextBox>
            </div>
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0"></asp:TextBox>
            </div>
        </div>

        <div class="grid grid-cols-1 gap-6 md:grid-cols-2">
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0">
                </asp:DropDownList>
            </div>
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0">
                </asp:DropDownList>
            </div>
        </div>

        <div class="grid grid-cols-1 gap-6 md:grid-cols-2">
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Precio ($)</label>
                <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0"></asp:TextBox>
            </div>
            <div>
                <label class="block text-sm font-medium text-gray-400 mb-1">Stock</label>
                <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0"></asp:TextBox>
            </div>
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-400 mb-1">Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-textarea w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0"></asp:TextBox>
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-400 mb-1">URL de Imagen</label>
            <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0" placeholder="https://..."></asp:TextBox>
            
        </div>

        <div class="mb-4">
               <asp:Label ID="lblError" runat="server" Text="" Visible="false" 
               CssClass="text-red-500 text-sm font-bold text-center block" />
        </div>
        <div class="flex justify-end gap-4 mt-8 pt-4 border-t border-gray-700">
            <a href="GestionProducto.aspx" class="px-6 py-2 rounded-lg border border-gray-500 text-gray-300 hover:bg-gray-700 transition-colors no-underline flex items-center justify-center">Cancelar</a>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" 
                        CssClass="px-6 py-2 rounded-lg bg-primary text-white font-bold hover:bg-primary/90 transition-colors cursor-pointer border-none" />
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
