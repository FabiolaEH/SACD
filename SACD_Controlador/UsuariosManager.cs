using System;
using SACD_Modelo;
using SACD_AccesoDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

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
                if(usuario.getCorreo().Equals(pCorreo) && usuario.getPassword().Equals(MD5Hash(pPassword)))
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

        //Generar código random
        public static string generarCodigoRandom(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Verificar código
        public static String verificarCodigo(string pCorreo)
        {
            String codigo = DatosManager.verificarCodigo(pCorreo);
            return codigo;
        }

        //Verificar que el correo sea válido
        public static Boolean verificarCorreo(string pCorreo)
        {
            Boolean isValido = DatosManager.verificarCorreo(pCorreo);
            return isValido;
        }

        //Enviar correo
        public static Boolean enviarCorreo(string pDestinatario)
        {
            String codigo = generarCodigoRandom(4);
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(pDestinatario);
            msg.From = new MailAddress("noreplysacd@gmail.com", "Proyecto SACD", System.Text.Encoding.UTF8);
            msg.Subject = "Actualización de la contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su código de contraseña es el siguiente: " + codigo;
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
                //Actualizar en la BD el código del usuario
                DatosManager.generarCodigo(codigo, pDestinatario);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return false;
        }


        //Actualizar contraseña
        public static Boolean actualizarPassword(string pCorreo, string pPassword)
        {
            Boolean isValido = DatosManager.actualizarPassword(pCorreo, MD5Hash(pPassword));
            return isValido;
        }

        //Registrar Usuario
        public static Boolean registrarUsuario(string pNombre, string pCorreo, string pPassword)
        {
            Boolean isValido = DatosManager.registrarUsuario(pNombre, pCorreo,MD5Hash(pPassword));
            return isValido;
        }

        //Algoritmo MD5
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
