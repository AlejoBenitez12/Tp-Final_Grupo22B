<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TiendaGamingWebForms.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="max-w-2xl mx-auto py-10 px-4">
        <h2 class="text-3xl font-bold mb-8 dark:text-white text-center">Finalizar Compra</h2>

        <div class="bg-white/5 dark:bg-[#191933] p-8 rounded-xl border border-gray-700">
            
            <asp:Label ID="lblError" runat="server" CssClass="text-red-500 font-bold block mb-4 text-center" Visible="false"></asp:Label>

            <div class="mb-6">
                <h3 class="text-xl font-semibold mb-2 dark:text-white">Opciones de Entrega</h3>
                <label class="block text-sm font-medium text-gray-400 mb-1">¿Cómo quieres recibir tu pedido?</label>
                <asp:DropDownList ID="ddlEnvio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnvio_SelectedIndexChanged"
                    CssClass="form-select w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0">
                    <asp:ListItem Text="Retiro en Local (Gratis)" Value="Retiro" />
                    <asp:ListItem Text="Envío a Domicilio (+$15.00)" Value="Envio" />
                </asp:DropDownList>
            </div>

            <asp:Panel ID="pnlDireccion" runat="server" Visible="false" CssClass="space-y-4 mb-6 border-l-4 border-primary pl-4">
                <h4 class="text-lg font-semibold dark:text-white">Datos de Envío</h4>
                
                <div>
                    <label class="block text-sm font-medium text-gray-400 mb-1">Provincia</label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select w-full bg-background-dark border border-gray-600 rounded-lg text-white">
                        <asp:ListItem Text="Buenos Aires" />
                        <asp:ListItem Text="CABA" />
                        <asp:ListItem Text="Cordoba" />
                        <asp:ListItem Text="Santa Fe" />
                        <asp:ListItem Text="Mendoza" />
                    </asp:DropDownList>
                </div>
                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label class="block text-sm font-medium text-gray-400 mb-1">Calle y Altura</label>
                        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg text-white"></asp:TextBox>
                    </div>
                    <div>
                        <label class="block text-sm font-medium text-gray-400 mb-1">Código Postal</label>
                        <asp:TextBox ID="txtCP" runat="server" MaxLength="4" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg text-white"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>

            <div class="mb-6">
                <h3 class="text-xl font-semibold mb-2 dark:text-white">Medio de Pago</h3>
                <asp:DropDownList ID="ddlPago" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPago_SelectedIndexChanged"
                    CssClass="form-select w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0">
                    <asp:ListItem Text="Tarjeta de Crédito/Débito" Value="Tarjeta" />
                    <asp:ListItem Text="Efectivo en el Local" Value="Efectivo" />
                </asp:DropDownList>
            </div>

            <asp:Panel ID="pnlTarjeta" runat="server" Visible="true">
                <h4 class="text-lg font-semibold dark:text-white mb-2">Datos de la Tarjeta</h4>
                <div class="space-y-4">
                    <div>
                        <label class="block text-sm font-medium text-gray-400 mb-1">Número</label>
                        <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="16" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg text-white"></asp:TextBox>
                    </div>
                    <div class="grid grid-cols-2 gap-4">
                        <div>
                            <label class="block text-sm font-medium text-gray-400 mb-1">Vencimiento</label>
                            <asp:TextBox ID="txtVencimiento" runat="server" MaxLength="5" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg text-white" placeholder="MM/AA"></asp:TextBox>
                        </div>
                        <div>
                            <label class="block text-sm font-medium text-gray-400 mb-1">CVV</label>
                            <asp:TextBox ID="txtCVV" runat="server" MaxLength="3" TextMode="Password" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg text-white"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <div class="mt-8 border-t border-gray-700 pt-6">
                <div class="flex justify-between text-xl font-bold dark:text-white mb-6">
                    <span>Total a Pagar:</span>
                    <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                </div>

                <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar y Pagar" OnClick="btnConfirmarCompra_Click" 
                            CssClass="w-full bg-primary hover:bg-primary/90 text-white font-bold py-3 rounded-lg transition-colors cursor-pointer" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
