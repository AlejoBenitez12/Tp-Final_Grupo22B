<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Gaming.master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TiendaGamingWebForms.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Primero acá verifico si encontré el producto --%>
    <% if (ProductoSeleccionado != null) { %>

        <%-- Acá hago un Breadcrumbs dinámico --%>
        <div class="flex flex-wrap gap-2 p-4">
            <a class="text-sm font-medium leading-normal text-[#9292c9] hover:text-white transition-colors" href="Default.aspx">Inicio</a>
            <span class="text-sm font-medium leading-normal text-[#9292c9]">/</span>
            <a class="text-sm font-medium leading-normal text-[#9292c9] hover:text-white transition-colors" href="Productos.aspx">Productos</a>
            <span class="text-sm font-medium leading-normal text-[#9292c9]">/</span>
            <span class="text-sm font-medium leading-normal text-white"><%: ProductoSeleccionado.Nombre %></span>
        </div>

        <%-- El grid Principal --%>
        <div class="grid grid-cols-1 lg:grid-cols-2 gap-8 lg:gap-16 mt-4">

            <%-- Esto sería la galería de imágenes --%>
            <div class="flex flex-col gap-4">
                
                <%-- Esto es de la imagen principal con una validación por si no encuentro imagen --%>
                <div class="w-full bg-[#111122] rounded-xl flex justify-center items-center aspect-video p-4">
                     <asp:Image ID="imgProductoPrincipal" runat="server" 
                         ImageUrl='<%# (ProductoSeleccionado.Imagenes.Count > 0) ? ProductoSeleccionado.Imagenes[0] : "https://via.placeholder.com/400x400.png?text=Sin+Imagen" %>' 
                         CssClass="max-h-full max-w-full object-contain" /> 
                         <%-- Con el object-contain hago que la imagen no se me deforme --%>
                </div>
                
                <%-- Esto son miniaturas dinámicas --%>
                <div class="grid grid-cols-4 gap-4">
                    <asp:Repeater ID="rptMiniaturas" runat="server" DataSource="<%# ProductoSeleccionado.Imagenes %>">
                        <ItemTemplate>
                            <div class="w-full bg-center bg-no-repeat aspect-square bg-cover rounded-lg opacity-60 hover:opacity-100 transition-opacity" 
                                 style='background-image: url("<%# Container.DataItem %>");'>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <%-- Esto es información y Compra --%>
            <div class="flex flex-col gap-6">
                <div class="flex flex-col gap-2">
                    <p class="text-sm font-medium text-primary"><%: ProductoSeleccionado.Marca.Descripcion %></p>
                    <h1 class="text-3xl md:text-4xl font-black leading-tight tracking-[-0.033em] text-white"><%: ProductoSeleccionado.Nombre %></h1>
                    <p class="text-base font-normal leading-normal text-[#9292c9]"><%: ProductoSeleccionado.Descripcion %></p>
                </div>
                
                <%-- Esto será para agregar reseñas, ahora puse un ejemplo estático para ver como queda --%>
                <div class="flex items-center gap-4">
                    <div class="flex items-center gap-1 text-yellow-400">
                        <span class="material-symbols-outlined fill text-lg">star</span>
                        <span class="material-symbols-outlined fill text-lg">star</span>
                        <span class="material-symbols-outlined fill text-lg">star</span>
                        <span class="material-symbols-outlined fill text-lg">star</span>
                        <span class="material-symbols-outlined fill text-lg">star_half</span>
                    </div>
                    <a class="text-sm text-[#9292c9] hover:text-white" href="#reviews">(125 reseñas)</a>
                </div>

                <%-- Los precios y el stock dinámico --%>
                <div class="p-4 bg-white/5 rounded-lg border border-white/10">
                    <p class="text-4xl font-bold text-white"><%: String.Format("{0:C}", ProductoSeleccionado.Precio) %></p>
                    <% if (ProductoSeleccionado.Stock > 0) { %>
                         <p class="text-green-400 mt-2 text-sm font-bold flex items-center gap-2"><span class="material-symbols-outlined text-base">check_circle</span> EN STOCK</p>
                    <% } else { %>
                         <p class="text-red-400 mt-2 text-sm font-bold flex items-center gap-2"><span class="material-symbols-outlined text-base">cancel</span> SIN STOCK</p>
                    <% } %>
                </div>
                
                <%-- La cantidad --%>
                <div class="flex items-center gap-2">
                    <label class="text-sm font-medium text-white" for="quantity">Cantidad:</label>
                    <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="form-select bg-background-dark border-white/20 rounded-lg text-white focus:ring-primary focus:border-primary">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 
                <%-- Botones nomas --%>
                <div class="flex flex-col sm:flex-row gap-4 mt-2">
                    <asp:Button ID="btnAgregarCarrito" runat="server" Text="Añadir al Carrito" 
                                CssClass="flex-grow flex w-full min-w-[84px] cursor-pointer items-center justify-center overflow-hidden rounded-lg h-12 px-6 bg-primary text-white text-base font-bold leading-normal tracking-[0.015em] hover:bg-primary/90 transition-colors" OnClick="btnAgregarCarrito_Click"/>
                    <asp:Button ID="btnListaDeseos" runat="server" Text="Lista de Deseos" 
                                CssClass="flex min-w-[84px] cursor-pointer items-center justify-center overflow-hidden rounded-lg h-12 px-6 bg-white/10 text-white text-base font-bold leading-normal tracking-[0.015em] hover:bg-white/20 transition-colors" />
                </div>
            </div>
        </div> 

        <%-- Tabs de Información Detallada  --%>
        <div class="mt-16">
            <div class="border-b border-white/20">
                <nav aria-label="Tabs" class="flex gap-8 -mb-px">
                    <a class="shrink-0 border-b-2 border-primary px-1 pb-4 text-sm font-medium text-primary" href="#">Descripción</a>
                    <a class="shrink-0 border-b-2 border-transparent px-1 pb-4 text-sm font-medium text-[#9292c9] hover:border-white/50 hover:text-white" href="#">Especificaciones</a>
                    <a class="shrink-0 border-b-2 border-transparent px-1 pb-4 text-sm font-medium text-[#9292c9] hover:border-white/50 hover:text-white" href="#" id="reviews">Reseñas (125)</a>
                    <a class="shrink-0 border-b-2 border-transparent px-1 pb-4 text-sm font-medium text-[#9292c9] hover:border-white/50 hover:text-white" href="#">Preguntas</a>
                </nav>
            </div>
            <div class="py-8 prose prose-invert max-w-none text-[#9292c9]">
    <%-- Acá uso para mostrar la descripción del producto--%>
    <p><%: ProductoSeleccionado.Descripcion %></p>
</div>
        </div>

        <%-- Productos Relacionados (HTML COMPLETO) --%>
        <div class="mt-16">
            <h2 class="text-2xl font-bold text-white mb-6">Clientes también compraron</h2>
            <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
                <%-- Tarjeta 1 que está de ejemplo --%>
                <div class="flex flex-col gap-4 bg-white/5 p-4 rounded-xl border border-transparent hover:border-primary/50 transition-all">
                    <div class="w-full bg-center bg-no-repeat aspect-square bg-cover rounded-lg" style='background-image: url("https://http2.mlstatic.com/D_NQ_NP_892873-MLA75591963970_042024-O.webp");'></div>
                    <div class="flex flex-col gap-1">
                        <h3 class="font-bold text-white leading-tight">Intel Core i9-13900K</h3>
                        <p class="text-sm text-[#9292c9]">Procesador de escritorio</p>
                        <p class="text-lg font-bold text-white mt-2">649,99 €</p>
                    </div>
                </div>
            </div>
        </div>

    <% } else { %>
        <%-- Esto se muestra si el ID no existe o no se pasó --%>
        <h2 class="text-3xl font-bold text-center text-red-500">Producto no encontrado</h2>
        <p class="text-center text-white/80">El producto que buscas no existe o fue eliminado.</p>
    <% } %>

</asp:Content>

<asp:Content ID="ScriptsContentDetalle" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">
</asp:Content>