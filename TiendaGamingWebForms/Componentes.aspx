<%@ Page Title="Componentes" Language="C#" MasterPageFile="~/Gaming.master" AutoEventWireup="true" CodeBehind="Componentes.aspx.cs" Inherits="TiendaGamingWebForms.Componentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-3xl font-bold mb-6 dark:text-white">Componentes</h2>

    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">

        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>

                <asp:HyperLink ID="lnkTarjetaProducto" runat="server" NavigateUrl='<%# "~/DetalleProducto.aspx?id=" + Eval("Id") %>'>
                    <div class="bg-white/5 dark:bg-[#191933] rounded-lg overflow-hidden flex flex-col group transition-all duration-300 hover:transform hover:-translate-y-1 hover:shadow-2xl hover:shadow-primary/20 border border-transparent hover:border-primary/50">
                        <div class="bg-cover bg-center aspect-square" style='background-image: url("<%# Eval("Imagenes[0]") %>");'></div>
                        <div class="p-4 ...">
                             <h3 class="text-white font-bold text-lg leading-tight truncate"><%# Eval("Nombre") %></h3>
 <p class="text-white/70 dark:text-[#9292c9] text-sm mt-1"><%# Eval("Categoria.Descripcion") %></p>
 <div class="flex-grow"></div> 
 <div class="flex items-center justify-between mt-4">
     <p class="text-white text-xl font-bold"><%# String.Format("{0:C}", Eval("Precio")) %></p>
     <button type="button" class="flex items-center justify-center h-10 w-10 rounded-full bg-primary/20 text-primary group-hover:bg-primary group-hover:text-white transition-colors">
         <span class="material-symbols-outlined text-xl">add_shopping_cart</span>
     </button>
 </div>
                        </div>
                    </div>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>

    </div> 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
