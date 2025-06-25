using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class GestorPermiso
    {

        //Permiso: Codigo, Nombre, Descripcion

        private List<Permiso> permisos;

        public GestorPermiso()
        {
            permisos = new List<Permiso>();
        }
        public void listarPermisos()
        {
            Console.Clear();
            Console.WriteLine("Listado de Permisos: ");

            if (permisos==null || permisos.Count == 0)
            {
                Console.WriteLine("No hay permisos cargados");
                return;
            }

            foreach (var permiso in permisos)
            {
                Console.WriteLine(permiso.ToString());
            }
        }

        public void altaPermiso()
        {
            int codigo;
            string nombre,descripcion;
            Console.Clear();
            Console.WriteLine("===== Alta de Permiso =====");
            Console.WriteLine("Codigo: ");
            codigo = Validador.PedirEntero();
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Descripcion: ");
            descripcion = Console.ReadLine();

            Permiso nuevo = new Permiso(codigo,nombre,descripcion);
            permisos.Add(nuevo);
            Console.WriteLine("Permiso agregado con exito");
        }


    }
}
