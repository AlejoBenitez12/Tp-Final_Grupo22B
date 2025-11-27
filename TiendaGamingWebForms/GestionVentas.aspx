<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="TiendaGamingWebForms.GestionVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-8">
        <h2 class="text-3xl font-bold mb-6 dark:text-white">Historial de Ventas</h2>

        <div class="overflow-x-auto bg-white/5 rounded-lg border border-gray-700 shadow-lg">
            <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false"
                CssClass="w-full text-sm text-left text-gray-300"
                HeaderStyle-CssClass="text-xs uppercase bg-gray-800 text-gray-200 border-b border-gray-700"
                RowStyle-CssClass="border-b border-gray-700 hover:bg-gray-700/50 transition-colors">
                
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="# Venta" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="EmailUsuario" HeaderText="Cliente" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" ItemStyle-CssClass="px-6 py-4 font-bold text-green-400" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                
                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="px-6 py-3" ItemStyle-CssClass="px-6 py-4">
            <ItemTemplate>
                <a href="DetalleVentaAdmin.aspx?id=<%# Eval("Id") %>" class="text-blue-400 hover:text-blue-300 font-bold text-sm no-underline">
                    Ver Detalle
                </a>
            </ItemTemplate>
        </asp:TemplateField>
                
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
