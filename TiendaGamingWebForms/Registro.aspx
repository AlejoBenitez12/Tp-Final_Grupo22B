<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaGamingWebForms.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="flex justify-center items-center py-10">
        <div class="w-full max-w-md p-8 space-y-6 bg-gray-100 dark:bg-[#191933] rounded-xl shadow-lg border border-gray-200 dark:border-[#323267]">
            <h2 class="text-3xl font-bold text-center text-primary dark:text-white">Crear Cuenta</h2>

            <div class="space-y-4">
                <div>
                    <asp:Label ID="lblEmailRegistro" runat="server" AssociatedControlID="txtEmailRegistro" CssClass="block text-sm font-medium text-gray-700 dark:text-[#9292c9] mb-1">Email</asp:Label>
                    <asp:TextBox ID="txtEmailRegistro" runat="server" TextMode="Email" CssClass="form-input block w-full px-4 py-2 mt-1 text-base rounded-lg text-black dark:text-white bg-background-light dark:bg-background-dark border border-gray-300 dark:border-[#323267] focus:outline-none focus:ring-primary focus:border-primary" placeholder="tu_correo@ejemplo.com"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblPasswordRegistro" runat="server" AssociatedControlID="txtPasswordRegistro" CssClass="block text-sm font-medium text-gray-700 dark:text-[#9292c9] mb-1">Contraseña</asp:Label>
                    <asp:TextBox ID="txtPasswordRegistro" runat="server" TextMode="Password" CssClass="form-input block w-full px-4 py-2 mt-1 text-base rounded-lg text-black dark:text-white bg-background-light dark:bg-background-dark border border-gray-300 dark:border-[#323267] focus:outline-none focus:ring-primary focus:border-primary" placeholder="••••••••"></asp:TextBox>
                </div>
                 <div>
                    <asp:Label ID="lblConfirmarPassword" runat="server" AssociatedControlID="txtConfirmarPassword" CssClass="block text-sm font-medium text-gray-700 dark:text-[#9292c9] mb-1">Confirmar Contraseña</asp:Label>
                    <asp:TextBox ID="txtConfirmarPassword" runat="server" TextMode="Password" CssClass="form-input block w-full px-4 py-2 mt-1 text-base rounded-lg text-black dark:text-white bg-background-light dark:bg-background-dark border border-gray-300 dark:border-[#323267] focus:outline-none focus:ring-primary focus:border-primary" placeholder="••••••••"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="w-full flex justify-center py-3 px-4 border border-transparent rounded-lg shadow-sm text-base font-bold text-white bg-primary hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary transition-colors cursor-pointer" />
                </div>
            </div>
             <p class="text-sm text-center text-gray-500 dark:text-[#9292c9]">
                ¿Ya tienes cuenta? 
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" CssClass="font-medium text-primary hover:underline">Inicia sesión aquí</asp:HyperLink>
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
