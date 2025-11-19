<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Gaming.master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TiendaGamingWebForms.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="flex flex-wrap justify-between gap-4 p-4 mb-6">
        <div class="flex min-w-72 flex-col gap-3">
            <p class="text-4xl font-black leading-tight tracking-[-0.033em] dark:text-white">Carrito de Compras</p>
            <p class="text-gray-500 dark:text-[#9292c9] text-base font-normal leading-normal">Revisa los artículos en tu carrito a continuación.</p>
        </div>
    </div>


    <div class="grid grid-cols-1 lg:grid-cols-3 gap-12">

        <div class="lg:col-span-2">
            <div class="px-0 py-3">
                <div class="flex overflow-hidden rounded-lg border border-gray-200 dark:border-[#323267] bg-background-light dark:bg-background-dark">
                    <table class="flex-1">
                        <thead class="hidden md:table-header-group">
                            <tr class="bg-gray-100 dark:bg-[#191933]">
                                <th class="px-4 py-3 text-left w-2/5 text-sm font-medium leading-normal dark:text-white">Producto</th>
                                <th class="px-4 py-3 text-left w-1/5 text-sm font-medium leading-normal dark:text-white">Precio</th>
                                <th class="px-4 py-3 text-left w-1/5 text-sm font-medium leading-normal dark:text-white">Cantidad</th>
                                <th class="px-4 py-3 text-left w-1/5 text-sm font-medium leading-normal dark:text-white">Total</th>
                                <th class="px-4 py-3 text-left w-12 text-sm font-medium leading-normal"></th>
                            </tr>
                        </thead>
                        

                        <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
                            <ItemTemplate>
    <tr class="flex flex-col md:table-row border-b md:border-t border-gray-200 dark:border-t-[#323267] p-4 md:p-0">

        <td class="h-auto md:h-[96px] px-0 md:px-4 py-2 text-sm font-normal leading-normal">
            <div class="flex items-center gap-4">
                <div class="bg-center bg-no-repeat aspect-square bg-cover rounded-lg w-16 h-16 shrink-0" 
                     style='background-image: url("<%# Eval("Producto.Imagenes[0]") %>");'></div>
                <div>
                    <p class="font-bold dark:text-white"><%# Eval("Producto.Nombre") %></p>
                    <p class="text-sm text-gray-500 dark:text-[#9292c9]"><%# Eval("Producto.Marca.Descripcion") %></p>
                </div>
            </div>
        </td>
        

        <td class="h-auto md:h-[96px] px-0 md:px-4 py-2 text-gray-600 dark:text-[#9292c9] text-sm font-normal leading-normal align-middle">
            <span class="md:hidden font-medium text-black dark:text-white">Precio: </span>
            <%# Eval("Producto.Precio", "{0:C}") %>
        </td>
        

        <td class="h-auto md:h-[96px] px-0 md:px-4 py-2 text-gray-600 dark:text-[#9292c9] text-sm font-normal leading-normal align-middle">
            <div class="flex items-center">
                <asp:LinkButton ID="btnRestar" runat="server"
                    CommandName="Restar" CommandArgument='<%# Eval("Producto.Id") %>'
                    CssClass="size-8 rounded-l-md border border-gray-300 dark:border-[#323267] flex items-center justify-center">-</asp:LinkButton>
                
                <asp:Label ID="lblCantidad" runat="server" 
                    Text='<%# Eval("Cantidad") %>' 
                    CssClass="w-12 h-8 text-center border-y border-gray-300 dark:border-[#323267] bg-transparent dark:text-white flex items-center justify-center" />
                
                <asp:LinkButton ID="btnSumar" runat="server"
                    CommandName="Sumar" CommandArgument='<%# Eval("Producto.Id") %>'
                    CssClass="size-8 rounded-r-md border border-gray-300 dark:border-[#323267] flex items-center justify-center">+</asp:LinkButton>
            </div>
        </td>
        

        <td class="h-auto md:h-[96px] px-0 md:px-4 py-2 text-gray-600 dark:text-[#9292c9] text-sm font-normal leading-normal align-middle">
            <span class="md:hidden font-medium text-black dark:text-white">Total: </span>
            <%# String.Format("{0:C}", (decimal)Eval("Producto.Precio") * (int)Eval("Cantidad")) %>
        </td>
        

        <td class="h-auto md:h-[96px] px-0 md:px-4 py-2 text-sm font-bold leading-normal tracking-[0.015em] align-middle text-center">
            <asp:LinkButton ID="btnEliminarItem" runat="server"
                CssClass="text-gray-500 dark:text-[#9292c9] hover:text-red-500"
                CommandName="Eliminar" 
                CommandArgument='<%# Eval("Producto.Id") %>'>
                
                <span class="material-symbols-outlined">delete</span>
            </asp:LinkButton>
        </td>

    </tr> 
</ItemTemplate>
                        </asp:Repeater>


                    </table>
                </div>
            </div>

            <div class="flex justify-between items-center mt-6 px-4">
                <asp:LinkButton ID="lnkSeguirComprando" runat="server" CssClass="flex items-center gap-2 text-primary hover:underline" PostBackUrl="~/Productos.aspx">
                    <span class="material-symbols-outlined">arrow_back</span>
                    Seguir Comprando
                </asp:LinkButton>
                <asp:LinkButton ID="lnkVaciarCarrito" runat="server" CssClass="flex items-center gap-2 text-gray-500 dark:text-[#9292c9] hover:text-red-500" OnClick="lnkVaciarCarrito_Click">
                    <span class="material-symbols-outlined">delete_sweep</span>
                    Vaciar Carrito
                </asp:LinkButton>
            </div>
        </div>


        <div class="lg:col-span-1">
    <div class="bg-gray-100 dark:bg-[#191933] rounded-lg p-6 sticky top-10">
        <h3 class="text-2xl font-bold mb-6 dark:text-white">Resumen del Pedido</h3>
        <div class="space-y-3 mb-6">
            <div class="flex justify-between gap-x-6 py-2">
                <p class="text-gray-500 dark:text-[#9292c9] text-sm font-normal leading-normal">Subtotal</p>
                <asp:Label ID="litSubtotal" runat="server" Text="$0.00" CssClass="text-sm font-medium leading-normal text-right dark:text-white" />
            </div>

            <div class="flex justify-between gap-x-6 py-2">
        <p class="text-gray-500 dark:text-[#9292c9] text-sm font-normal leading-normal">Costos de envío</p>
        <asp:Label ID="litEnvio" runat="server" Text="$0.00" CssClass="text-sm font-medium leading-normal text-right dark:text-white" />
    </div>
    <div class="flex justify-between gap-x-6 py-2">
        <p class="text-gray-500 dark:text-[#9292c9] text-sm font-normal leading-normal">Impuestos</p> 
        <asp:Label ID="litImpuestos" runat="server" Text="$0.00" CssClass="text-sm font-medium leading-normal text-right dark:text-white" />
    </div>
            <div class="flex justify-between gap-x-6 py-2 mb-6">
        <p class="text-lg font-bold dark:text-white">Total</p>
        <asp:Label ID="litTotal" runat="server" Text="$0.00" CssClass="text-lg font-bold leading-normal text-right dark:text-white" />
    </div>
    </div>

        <div class="flex flex-col gap-4 mb-6">
            <p class="text-base font-medium leading-normal pb-2 dark:text-white">¿Tienes un código de descuento?</p>
            <div class="flex items-stretch">
                <asp:TextBox ID="txtCodigoDescuento" runat="server" CssClass="form-input flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-l-lg dark:text-white focus:outline-0 focus:ring-0 border border-gray-300 dark:border-[#323267] bg-background-light dark:bg-background-dark focus:border-primary h-12 placeholder:text-gray-400 dark:placeholder:text-[#9292c9] p-[15px] text-base font-normal leading-normal" placeholder="Ingresa tu código"></asp:TextBox>
                <asp:LinkButton ID="btnAplicarDescuento" runat="server" Text="Aplicar" 
                       CssClass="bg-gray-300 dark:bg-[#323267] text-gray-700 dark:text-white px-4 rounded-r-lg font-semibold text-sm hover:bg-gray-400 dark:hover:bg-[#4a4a8a] flex items-center justify-center" />
            </div>
        </div>


        <asp:LinkButton ID="btnProcederPago" runat="server" OnClick="btnProcederPago_Click" 
            CssClass="w-full flex cursor-pointer items-center justify-center overflow-hidden rounded-lg h-14 bg-primary text-white gap-2 text-lg font-bold leading-normal tracking-[0.015em] hover:bg-primary/90 transition-colors">
            Proceder al Pago
            <span class="material-symbols-outlined">arrow_forward</span> 
        </asp:LinkButton>

    </div>
</div> 
</asp:Content>
