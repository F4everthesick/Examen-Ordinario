using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Examen_Ordinario.Controller
{
    public class Correo
    {
        // Método para generar el PDF en memoria
        private MemoryStream GenerarPdf()
        {
            // Crear un flujo de memoria para almacenar el PDF generado
            MemoryStream pdfStream = new MemoryStream();

            // Crear un documento PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, pdfStream);



            // Retornar el flujo de memoria que contiene el PDF
            pdfStream.Position = 0; // Reiniciar la posición para leer el archivo desde el principio
            return pdfStream;
        }

        // Método para enviar el correo con el PDF adjunto
        public void EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                // Generar el archivo PDF en memoria
                MemoryStream archivoPdfStream = GenerarPdf();

                // Configuración del servidor SMTP de Outlook
                SmtpClient smtpCliente = new SmtpClient("smtp.office365.com")
                {
                    Port = 587, // Puerto SMTP de Outlook (587 es para TLS)
                    Credentials = new NetworkCredential("111844@alumnouninter.mx", "KevLop1300"), // Credenciales de Outlook
                    EnableSsl = true // Activar la conexión segura TLS
                };

                // Crear el mensaje de correo
                MailMessage correo = new MailMessage
                {
                    From = new MailAddress("111844@alumnouninter.mx"), // Dirección de remitente
                    Subject = asunto, // Asunto del correo
                    Body = cuerpo, // Cuerpo del correo
                    IsBodyHtml = true // Si el cuerpo es HTML
                };

                // Agregar destinatario
                correo.To.Add(destinatario);

                // Adjuntar el archivo PDF desde el flujo de memoria
                Attachment adjunto = new Attachment(archivoPdfStream, "Recibo.pdf", "application/pdf");
                correo.Attachments.Add(adjunto);

                // Enviar el correo
                smtpCliente.Send(correo);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}