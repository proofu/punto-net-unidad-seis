using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class GestorUsuario
    {

        private List<Usuario> usuarios;

        public GestorUsuario()
        {
            usuarios = new List<Usuario>();
        }
        public void listarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("==== Lista de Usuario ====");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay Usuarios cargados");
                return;
            }

            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
        }

        //ALTA USUARIO

        public void altaUsuarios(List<Grupo> grupos, List<Permiso> permisos)
        {
            Console.Clear();
            Console.WriteLine("=====ALta Usuario =====");

            Console.WriteLine("Codigo: ");

            int codigo = Validador.PedirEntero();

            if (usuarios.Any(u => u.Codigo == codigo))
            {
                Console.WriteLine("Ya existe el usuario");
                return;
            }
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Telefono: ");
            string telefono = Console.ReadLine();


            //Seleccionador de grupo 
            Console.WriteLine("==== Grupos disponibles ====");
            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Codigo: {grupo.Codigo} --- Nombre: {grupo.Nombre}");
            }

            Console.WriteLine("Ingrese el grupo: ");

            int codigoGrupo = Validador.PedirEntero();

            Grupo grupoSeleccion = grupos.FirstOrDefault(g => g.Codigo == codigo);

            if (grupoSeleccion == null)
            {
                Console.WriteLine("No se encuentra Grupo");
                return;
            }


            //PERMISOS

            List<Permiso> permisosSeleccionados = new List<Permiso>();
            if (permisos.Count > 0)
            {
                Console.WriteLine("====== Permisos disponibles ====)");

                foreach (var permiso in permisos)
                {
                    Console.WriteLine(permiso.ToString());
                }




            }

        }
        //ELIMINAR USUARIO
        public void eliminarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=====ELIMinar USUARIO =========");

            Console.WriteLine("Ingrese el codigo para eliminar el usuario");
            int codigo = Validador.PedirEntero();

            Usuario usuario = usuarios.FirstOrDefault(u => u.Codigo == codigo);
            if (usuario == null)
            {
                Console.WriteLine("No se encontro el usuario");
                return;
            }
            usuarios.Remove(usuario);
            Console.WriteLine("Usuario Eliminado");
        }

    }
}
