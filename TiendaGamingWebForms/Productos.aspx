<%@ Page Title="" Language="C#" MasterPageFile="~/Gaming.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TiendaGamingWebForms.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2 class="text-3xl font-bold mb-6 dark:text-white">Nuestros Productos</h2>

    <%-- Contenedor de la Cuadrícula con Tailwind --%>
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">

        <%-- Aca uso el Repeater que va a generar cada tarjeta --%>
        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                 <%-- La estructura de la tarjeta --%>
                <div class="bg-white/5 dark:bg-[#191933] rounded-lg overflow-hidden flex flex-col group transition-all duration-300 hover:transform hover:-translate-y-1 hover:shadow-2xl hover:shadow-primary/20 border border-transparent hover:border-primary/50">
                    
                    <%-- Acá meto la imagen del Producto --%>
                    <div class="bg-cover bg-center aspect-square" 
                         style='background-image: url("<%# Eval("Imagenes[0]") %>");'> 
                    </div>

                    <%-- Acá meto la info debajo de la imagen --%>
                    <div class="p-4 flex flex-col flex-grow">
                        <h3 class="text-white font-bold text-lg leading-tight truncate"><%# Eval("Nombre") %></h3>
                        <p class="text-white/70 dark:text-[#9292c9] text-sm mt-1"><%# Eval("Categoria.Descripcion") %></p>
                        <div class="flex-grow"></div> <%-- Empujo el precio y el botón hacia abajo --%>
                        <div class="flex items-center justify-between mt-4">
                            <p class="text-white text-xl font-bold"><%# String.Format("{0:C}", Eval("Precio")) %></p> <%-- El precio lo meto en formato moneda --%>
                             <%-- El botón añadir, le agrego funcionalidad ma adelante --%>
                            <button type="button" class="flex items-center justify-center h-10 w-10 rounded-full bg-primary/20 text-primary group-hover:bg-primary group-hover:text-white transition-colors">
                                <span class="material-symbols-outlined text-xl">add_shopping_cart</span>
                            </button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater> 
        <%-- Acá termina el repeater --%>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
