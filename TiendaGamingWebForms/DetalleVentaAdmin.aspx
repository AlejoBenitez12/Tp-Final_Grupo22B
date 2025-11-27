<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="DetalleVentaAdmin.aspx.cs" Inherits="TiendaGamingWebForms.DetalleVentaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-8 max-w-4xl">
        <div class="flex justify-between items-center mb-6">
            <h2 class="text-3xl font-bold dark:text-white">Detalle de Venta #<asp:Label ID="lblIdVenta" runat="server" /></h2>
            <a href="GestionVentas.aspx" class="text-gray-400 hover:text-white">Volver al listado</a>
        </div>

        <%-- Datos de Cabecera --%>
        <div class="bg-white/5 p-6 rounded-lg border border-gray-700 mb-8 grid grid-cols-2 gap-4 text-gray-300">
            <div>
                <p class="text-sm text-gray-500">Cliente</p>
                <p class="font-bold text-white"><asp:Label ID="lblCliente" runat="server" /></p>
            </div>
            <div>
                <p class="text-sm text-gray-500">Fecha</p>
                <p class="font-bold text-white"><asp:Label ID="lblFecha" runat="server" /></p>
            </div>
            <div>
                <p class="text-sm text-gray-500">Estado</p>
                <p class="font-bold text-white"><asp:Label ID="lblEstado" runat="server" /></p>
            </div>
            <div>
                <p class="text-sm text-gray-500">Total</p>
                <p class="text-2xl font-bold text-green-400"><asp:Label ID="lblTotal" runat="server" /></p>
            </div>
        </div>

        <h3 class="text-xl font-bold text-white mb-4">Productos</h3>
        <div class="overflow-x-auto bg-white/5 rounded-lg border border-gray-700">
            <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="false"
                CssClass="w-full text-sm text-left text-gray-300"
                HeaderStyle-CssClass="text-xs uppercase bg-gray-800 text-gray-200 border-b border-gray-700"
                RowStyle-CssClass="border-b border-gray-700">
                <Columns>
                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto" ItemStyle-CssClass="px-6 py-4 font-medium text-white" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cant." ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unit." DataFormatString="{0:C}" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                     <asp:TemplateField HeaderText="Subtotal" HeaderStyle-CssClass="px-6 py-3" ItemStyle-CssClass="px-6 py-4 text-right">
                        <ItemTemplate>
                            <%# string.Format("{0:C}", (decimal)Eval("PrecioUnitario") * (int)Eval("Cantidad")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
