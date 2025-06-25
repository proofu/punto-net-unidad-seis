using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class Permiso
    {
        //Permiso: Codigo, Nombre, Descripcion
        private int codigo;
        private string nombre;
        private string descripcion;

        public Permiso(int codigo,string nombre,string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
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
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public override string ToString()
        {
            //return $"             Codigo: {codigo} Nombre: {nombre} Descripcion: {descripcion}";

            return $"Código: {codigo.ToString().PadRight(5)}  Nombre: {nombre.PadRight(15)}  Descripción: {descripcion}";
        }
    }
}
