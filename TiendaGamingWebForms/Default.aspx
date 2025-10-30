<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Gaming.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaGamingWebForms._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="mb-12 md:mb-16">
        <div class="w-full">
            <div class="p-0 md:p-4">
                <div class="flex min-h-[480px] flex-col gap-6 bg-cover bg-center bg-no-repeat rounded-xl items-start justify-end px-6 pb-10 md:px-10" 
                     style='background-image: linear-gradient(rgba(0, 0, 0, 0.1) 0%, rgba(0, 0, 0, 0.6) 100%), url("https://images.unsplash.com/photo-1555680202-c86f0e12f086?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=MnwzNjUyOXwwfDF8c2VhcmNofDN8fGdhbWluZyUyMHBlcmlwaGVyYWxzfGVufDB8fHx8MTY4Mzk0NzYxMg&ixlib=rb-4.0.3&q=80&w=1080");'>

                    <div class="flex flex-col gap-2 text-left max-w-2xl">
                        <h1 class="text-white text-4xl font-bold leading-tight tracking-[-0.033em] md:text-5xl">Semana del Gaming: Hasta 30% en Periféricos</h1>
                        <p class="text-white/90 text-sm font-normal leading-normal md:text-base">Descubre las mejores ofertas en teclados, ratones y auriculares para llevar tu juego al siguiente nivel.</p>
                    </div>
                    <button type="button" class="flex min-w-[84px] max-w-[480px] cursor-pointer items-center justify-center overflow-hidden rounded-lg h-10 px-4 md:h-12 md:px-5 bg-primary hover:bg-primary/90 transition-colors text-white text-sm font-bold leading-normal tracking-[0.015em] md:text-base">
                        <span class="truncate">Ver Ofertas</span>
                    </button>
                </div>
            </div>
        </div>
    </section>


</asp:Content>

<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>
