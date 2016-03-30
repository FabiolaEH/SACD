using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Usuario
    {
        private string nombre;
        private string correo;
        private string password;
        
        public Usuario(string pNombre, string pCorreo, string pPassword)
        {
            nombre = pNombre;
            correo = pCorreo;
            password = pPassword;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getCorreo()
        {
            return correo;
        }

        public string getPassword()
        {
            return password;
        }

        public void setNombre(string pNombre)
        {
            nombre = pNombre;
        }

        public void setCorreo(string pCorreo)
        {
            nombre = pCorreo;
        }
        public void setPassword(string pPassword)
        {
            nombre = pPassword;
        }
    }
}
