using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class Grupo
    {
        //Grupo: Codigo, Nombre, Lista de Permisos

        private int codigo;
        private string nombre;
        private List<Permiso> permisos;

        public Grupo(int codigo,string nombre,List<Permiso> permisos) 
        {
            this.codigo = codigo;
            this.nombre = nombre;
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
            set {  nombre = value; }
        }
        public IReadOnlyList<Permiso> Permisos
        {
            get { return permisos.AsReadOnly(); }
        }

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
            return $"             Codigo: {codigo} Nombre: {nombre} Lista de Permisos: [{ObtenerDescripcionesPermisos()}]";
        }
    }
}
