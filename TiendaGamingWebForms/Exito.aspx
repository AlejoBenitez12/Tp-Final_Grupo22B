<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TiendaGamingWebForms.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex justify-center items-center min-h-[60vh]">
        <div class="bg-white/5 dark:bg-[#191933] p-10 rounded-2xl border border-green-500/30 shadow-lg text-center max-w-lg w-full">
            
            <div class="flex justify-center mb-6">
                <div class="w-20 h-20 bg-green-500/20 rounded-full flex items-center justify-center">
                    <span class="material-symbols-outlined text-6xl text-green-500">check_circle</span>
                </div>
            </div>

            <h2 class="text-3xl font-bold text-white mb-4">¡Gracias por tu compra!</h2>
            <p class="text-gray-400 text-lg mb-8">
                Tu pedido ha sido procesado correctamente. Te enviamos un email con los detalles.
            </p>

            <div class="space-y-4">
                <a href="Default.aspx" class="block w-full bg-primary hover:bg-primary/90 text-white font-bold py-3 rounded-lg transition-colors">
                    Volver al Inicio
                </a>
                <%-- Futuro: Ver mis pedidos --%>
                <%-- <a href="MisCompras.aspx" class="block text-primary hover:underline">Ver el estado de mi pedido</a> --%>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
