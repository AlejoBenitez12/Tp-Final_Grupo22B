<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="MisCompas.aspx.cs" Inherits="TiendaGamingWebForms.MisCompas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-8">
        <h2 class="text-3xl font-bold mb-6 dark:text-white">Mis Pedidos</h2>

        <div class="overflow-x-auto bg-white/5 rounded-lg border border-gray-700 shadow-lg">
            <asp:GridView ID="gvMisCompras" runat="server" AutoGenerateColumns="false"
                CssClass="w-full text-sm text-left text-gray-300"
                HeaderStyle-CssClass="text-xs uppercase bg-gray-800 text-gray-200 border-b border-gray-700"
                RowStyle-CssClass="border-b border-gray-700 hover:bg-gray-700/50 transition-colors">
                
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="# Pedido" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" ItemStyle-CssClass="px-6 py-4 font-bold text-green-400" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3">
    <ItemTemplate>
        <a href="DetalleVentaAdmin.aspx?id=<%# Eval("Id") %>" 
           class="bg-primary hover:bg-blue-700 text-white font-bold py-1 px-3 rounded text-xs no-underline">
            Ver Detalle
        </a>
    </ItemTemplate>
</asp:TemplateField>
                </Columns>
            </asp:GridView>
             <asp:Label ID="lblMensaje" runat="server" Text="Aún no has realizado compras." Visible="false" CssClass="block text-center py-8 text-gray-500 text-lg" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
