using System;
using SACD_Modelo;
using SACD_AccesoDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SACD_Controlador
{
    public class UsuariosManager
    {
        //Crear Usuario
        public static void crear()
        {

        }

        public static Boolean verificarUsuario(string pCorreo, string pPassword)
        {
            List<Usuario> usuariosList = listar();
            foreach (Usuario usuario in usuariosList)
            {
                if(usuario.getCorreo().Equals(pCorreo) && usuario.getPassword().Equals(pPassword))
                {
                    return true;
                }
            }
            return false;

        }

        //Obtener lista de usuarios registrados
        public static List<Usuario> listar()
        {
            List<Object[]> usuariosListObject = new List<Object[]>();
            List<Usuario> usuariosList = new List<Usuario>();
            Usuario usuario;

            usuariosListObject = DatosManager.getUsuariosList();

            foreach (Object[] obj in usuariosListObject)
            {
                usuario = new Usuario((string)obj[0], (string)obj[1], (string)obj[2]);
                usuariosList.Add(usuario);
            }

            return usuariosList;
        }

        //Verificar que el correo sea válido
        public static Boolean verificarCorreo(string pCorreo)
        {
            Boolean isValido = DatosManager.verificarCorreo(pCorreo);
            return isValido;
        }

        public static Boolean enviarCorreo()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("noreplysacd@gmail.com");
            msg.From = new MailAddress("noreplysacd@gmail.com", "Proyecto SACD", System.Text.Encoding.UTF8);
            msg.Subject = "Actualización de la contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su código de contraseña es el siguiente: ";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("noreplysacd@gmail.com", "Proyecto2016");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return false;
        }
    }
}
