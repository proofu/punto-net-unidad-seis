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

            if (permisos.Count == 0)
            {
                Console.WriteLine("No hay permisos cargados");
                return;
            }

            foreach (var permiso in permisos)
            {
                Console.WriteLine(permiso.ToString());
            }
        }
        //ALTA PERMISO
        public void altaPermiso()
        {
            int codigo;
            string nombre, descripcion;
            Console.Clear();
            Console.WriteLine("===== Alta de Permiso =====");
            Console.WriteLine("Codigo: ");
            codigo = Validador.PedirEntero();
            if (permisos.Any(permisos => permisos.Codigo == codigo))
            {
                Console.WriteLine("Ya existe un codigo con ese permiso!!");
                return;
            }

            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();

            Console.WriteLine("Descripcion: ");
            descripcion = Console.ReadLine();

            Permiso nuevo = new Permiso(codigo, nombre, descripcion);
            permisos.Add(nuevo);


            Console.WriteLine("Permiso agregado con exito");
        }
        //MODIFICAR PERMISO
        public void ModificarPermiso()
        {
            Console.Clear();
            Console.WriteLine("===== Modificar Permiso ====== ");
            Console.WriteLine("Ingrese el codigo del permiso para modificar");
            int codigo = Validador.PedirEntero();

            var permiso = permisos.FirstOrDefault(p => p.Codigo == codigo);
            if (permiso == null)
            {
                Console.WriteLine("No se encuentra el permiso.");
                return;
            }
            Console.WriteLine($"Codigo Actual: {permiso}");
            Console.WriteLine("Nuevo nombre: ");
            string nuevoNombreCodigo = Console.ReadLine();
            Console.WriteLine("Nueva descripción: ");
            string nuevaDescripcionCodigo = Console.ReadLine(); ;

            permiso.Nombre = nuevoNombreCodigo;
            permiso.Descripcion = nuevaDescripcionCodigo;

            Console.WriteLine("Permiso Modificado");



        }

        //ELIMINAR PERMISO
        public void eliminarPermiso()
        {
            Console.Clear();
            Console.WriteLine("========= Eliminar Permiso ========");
            Console.WriteLine("Ingrese el codigo para eliminarlo");


            int codigo = Validador.PedirEntero();

            var permiso = permisos.FirstOrDefault(p => p.Codigo == codigo);
            if (permiso == null)
            {
                Console.WriteLine("No se encuentra el permiso");
                return;
            }

            permisos.Remove(permiso);

            Console.WriteLine("Permiso Eliminado");

        }

    }
}
