<%@ Page Title="Gestión de Ventas" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="TiendaGamingWebForms.GestionVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mx-auto py-8">
        <h2 class="text-3xl font-bold mb-6 dark:text-white">Historial de Ventas</h2>

        <div class="overflow-x-auto bg-white/5 rounded-lg border border-gray-700 shadow-lg">
            <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false"
                CssClass="w-full text-sm text-left text-gray-300"
                HeaderStyle-CssClass="text-xs uppercase bg-gray-800 text-gray-200 border-b border-gray-700"
                RowStyle-CssClass="border-b border-gray-700 hover:bg-gray-700/50 transition-colors"
                OnRowCommand="gvVentas_RowCommand">
                
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="# Venta" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="EmailUsuario" HeaderText="Cliente" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" ItemStyle-CssClass="px-6 py-4 font-bold text-green-400" HeaderStyle-CssClass="px-6 py-3" />
                    
                    <asp:BoundField DataField="Estado" HeaderText="Estado Actual" ItemStyle-CssClass="px-6 py-4" HeaderStyle-CssClass="px-6 py-3" />

                    <asp:TemplateField HeaderText="Actualizar Estado" HeaderStyle-CssClass="px-6 py-3" ItemStyle-CssClass="px-6 py-4">
                        <ItemTemplate>
                            <div class="flex items-center gap-2">
                                <asp:DropDownList ID="ddlEstadoGrid" runat="server" CssClass="text-black text-xs p-1 rounded bg-gray-200 border-none focus:ring-primary">
                                    <asp:ListItem>Pendiente</asp:ListItem>
                                    <asp:ListItem>Pagado</asp:ListItem>
                                    <asp:ListItem>En Preparación</asp:ListItem>
                                    <asp:ListItem>Enviado</asp:ListItem>
                                    <asp:ListItem>Entregado</asp:ListItem>
                                </asp:DropDownList>
                                
                                <asp:LinkButton ID="btnActualizar" runat="server" 
                                    CommandName="ActualizarEstado" 
                                    CommandArgument='<%# Eval("Id") %>'
                                    CssClass="text-green-500 hover:text-green-400 text-lg flex items-center" ToolTip="Guardar Cambio">
                                    <span class="material-symbols-outlined">save</span>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="px-6 py-3" ItemStyle-CssClass="px-6 py-4">
                        <ItemTemplate>
                            <a href="DetalleVentaAdmin.aspx?id=<%# Eval("Id") %>" class="text-blue-400 hover:text-blue-300 font-bold text-sm no-underline flex items-center gap-1">
                                <span class="material-symbols-outlined text-base">visibility</span>
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