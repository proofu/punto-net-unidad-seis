using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class Usuario
    {
        //Usuario: Codigo, Nombre, Password, Email, Teléfono, Grupo, Lista de Permisos

        private int codigo;
        private string nombre, password, email, telefono;
        private Grupo grupo;
        private List<Permiso> permisos;

        public Usuario(int codigo,string nombre,string password,string email,string telefono, Grupo grupo, List<Permiso> permisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.password = password;
            this.email = email;
            this.telefono = telefono;
            this.grupo = grupo;
            this.permisos = permisos;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }   
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Grupo Grupo
        {
            get { return grupo; }
        }
        public IReadOnlyList<Permiso> Permisos
        {
            get { return permisos.AsReadOnly(); }
        }

        // Método para obtener la descripción concatenada
        public string ObtenerDescripcionesPermisos()
        {
            if (permisos == null || permisos.Count == 0)
                return "Sin permisos";

            string resultado = "";
            foreach (var permiso in permisos)
            {
                resultado += permiso.Descripcion + ", ";
            }
            // Quitar la última coma y espacio
            return resultado.TrimEnd(',', ' ');
        }
        public override string ToString()
        {
            return $"Codigo:" +
                $" {codigo} Nombre:{nombre} Password: {password} Email: {email} Telefono: {telefono} Grupo: {grupo} Lista de Permisos: [{ObtenerDescripcionesPermisos()}]";
        }
    }
}
