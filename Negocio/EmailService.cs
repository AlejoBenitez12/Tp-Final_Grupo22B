using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("projectgroup22b@gmail.com", "qaho uhax seyn hnce");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("no-responder@tiendagaming.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
            email.IsBodyHtml = true;

            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el email: " + ex.Message);
            }
        }

        public void EnviarConfirmacionCompra(Venta venta, string emailUsuario)
        {
            string asunto = $"Confirmación de Compra - Pedido #{venta.Id}";

            string cuerpo = "<h1>¡Gracias por tu compra!</h1>";
            cuerpo += "<p>Hemos recibido tu pedido correctamente.</p>";
            cuerpo += "<h3>Resumen:</h3>";
            cuerpo += "<ul>";

            foreach (var item in venta.Items)
            {
                cuerpo += $"<li>{item.NombreProducto} - Cantidad: {item.Cantidad} - $ {item.PrecioUnitario}</li>";
            }

            cuerpo += "</ul>";
            cuerpo += $"<h3>Total Pagado: $ {venta.Total}</h3>";
            cuerpo += "<br/><p>Saludos, el equipo de Tienda Gaming.</p>";

            ArmarCorreo(emailUsuario, asunto, cuerpo);
        }
    }
}
