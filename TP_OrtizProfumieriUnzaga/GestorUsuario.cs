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

            Grupo grupoSeleccion = grupos.FirstOrDefault(g => g.Codigo == codigoGrupo);

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
            Console.WriteLine("Ingreso los codigos separados por coma");
            string entradaCodigo = Console.ReadLine();

            if (!string.IsNullOrEmpty(entradaCodigo))
            {
                string[] codigos = entradaCodigo.Split(',');
                foreach (var cod in codigos)
                {
                    if (int.TryParse(cod.Trim(), out int codPermisos))
                    {

                        Permiso permisosList = permisos.FirstOrDefault(permisosNuevos => permisosNuevos.Codigo == codPermisos);
                        if (permisosList != null)
                        {
                            permisosSeleccionados.Add(permisosList);
                        }
                    }

                }
            }

            Usuario nuevo = new Usuario(codigo, nombre, password, email, telefono, grupoSeleccion, permisosSeleccionados);
            usuarios.Add(nuevo);

            Console.WriteLine("Usuario Agregado");


        }


        //MODIFICACIÓN USUARIO


        public void modificarUsuario(List<Grupo> grupos, List<Permiso> permisos)
        {
            Console.Clear();
            Console.WriteLine("=====Modificar Usuario =====");

            Console.WriteLine("Codigo de Usuario: ");
            int codigo = Validador.PedirEntero();


            Usuario usuario = usuarios.FirstOrDefault(u => u.Codigo == codigo);

            if (usuario == null)
            {
                Console.WriteLine("No se encuentra el usuario");
                return;
            }

            Console.WriteLine("Datos Del Usuario: ");

            Console.WriteLine(usuario.ToString());

            Console.WriteLine("Nuevo Nombre: ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                usuario.Nombre = nuevoNombre;

            }

            Console.WriteLine("Nueva Contraseña: ");
            string nuevoContrasenia = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoContrasenia))
            {
                usuario.Password = nuevoContrasenia;

            }

            Console.WriteLine("Nuevo Email: ");
            string nuevoEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoEmail))
            {
                usuario.Email = nuevoEmail;

            }

            Console.WriteLine("Nuevo Telefono: ");
            string nuevoTelefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                usuario.Telefono = nuevoTelefono;

            }

            //Modificación de grupo 
            Console.WriteLine("==== Grupos disponibles ====");
            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Codigo: {grupo.Codigo} --- Nombre: {grupo.Nombre}");
            }
            //Salteo de modificación Grupo - Apretar " 0 "

            Console.WriteLine("Ingrese el numero del grupo (0 para no modificar): ");
            int nuevoCodigoGrupo = Validador.PedirEntero();
            if (nuevoCodigoGrupo != 0)
            {
                Grupo grupoSeleccionado = grupos.FirstOrDefault(g => g.Codigo == nuevoCodigoGrupo);

                if (grupoSeleccionado != null)
                {
                    typeof(Usuario).GetField("grupo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(usuario, grupoSeleccionado);
                }
                else
                {
                    Console.WriteLine("Grupo no encontrado. Se mantiene el grupo");
                }

            }

            //Modificación de grupo 
            Console.WriteLine("==== Permisos disponibles ====");
            foreach (var permiso in permisos)
            {
                Console.WriteLine(permiso.ToString());
            }
            //Salteo de modificación Permiso - escribir " ABC "

            Console.WriteLine("Ingreso los codigos separados por coma (escribir ABC para no modificar");
            string permisosReadLine = Console.ReadLine();


            if (permisosReadLine != "ABC")
            {

                List<Permiso> nuevosPermisos = new List<Permiso>();
                string[] codigos = permisosReadLine.Split(',');
                foreach (var cod in codigos)
                {
                    if (int.TryParse(cod.Trim(), out int codPermisos))
                    {

                        Permiso permisoEncontrado = permisos.FirstOrDefault(p => p.Codigo == codPermisos);
                        if (permisoEncontrado != null)
                        {
                            nuevosPermisos.Add(permisoEncontrado);
                        }
                    }

                }

                typeof(Usuario).GetField("permisos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(usuario, nuevosPermisos);
            }


            Console.WriteLine("Usuario Modificado");
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
