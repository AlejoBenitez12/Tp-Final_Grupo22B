<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TiendaGamingWebForms.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="max-w-2xl mx-auto py-10 px-4">
        <h2 class="text-3xl font-bold mb-8 dark:text-white text-center">Finalizar Compra</h2>

        <div class="bg-white/5 dark:bg-[#191933] p-8 rounded-xl border border-gray-700">
            <h3 class="text-xl font-semibold mb-4 dark:text-white">Datos de Pago</h3>
            
            <asp:Label ID="lblError" runat="server" CssClass="text-red-500 font-bold block mb-4 text-center" Visible="false"></asp:Label>

            <div class="space-y-4">
                <div>
                    <label class="block text-sm font-medium text-gray-400 mb-1">Número de Tarjeta</label>
                    <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="16" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0" placeholder="0000 0000 0000 0000"></asp:TextBox>
                    <p class="text-xs text-gray-500 mt-1">16 dígitos sin espacios</p>
                </div>

                <div class="grid grid-cols-2 gap-4">
                    <div>
                        <label class="block text-sm font-medium text-gray-400 mb-1">Vencimiento (MM/AA)</label>
                        <asp:TextBox ID="txtVencimiento" runat="server" MaxLength="5" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0" placeholder="MM/AA"></asp:TextBox>
                    </div>
                    <div>
                        <label class="block text-sm font-medium text-gray-400 mb-1">Código de Seguridad</label>
                        <asp:TextBox ID="txtCVV" runat="server" MaxLength="3" TextMode="Password" CssClass="form-input w-full bg-background-dark border border-gray-600 rounded-lg px-4 py-2 text-white focus:border-primary focus:ring-0" placeholder="123"></asp:TextBox>
                    </div>
                </div>
            </div>

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
