using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    internal class Program
    {
        private static GestorPermiso gestorPermiso;
        private static GestorGrupo gestorGrupo;
        private static GestorUsuario gestorUsuario;
        static void Main(string[] args)
        {
            // Crear permisos iniciales
            List<Permiso> permisos = new List<Permiso>
            {
                new Permiso(1, "Lectura", "Puede ver datos"),
                new Permiso(2, "Escritura", "Puede modificar datos"),
                new Permiso(3, "Eliminación", "Puede eliminar datos")
            };
            gestorPermiso = new GestorPermiso();
            //gestorGrupo = new GestorGrupo();
            gestorUsuario = new GestorUsuario();
            gestorPermiso.agregarPermisos(permisos);

            // grupos iniciales
            Grupo grupoAdmin = new Grupo(
                codigo: 1,
                nombre: "Administradores",
                permisos: new List<Permiso>(permisos) 
            );
            Grupo grupoLectura = new Grupo(
                codigo: 2,
                nombre: "Lectura",
                permisos: new List<Permiso> { permisos[0] } 
            );
            Grupo grupoEditores = new Grupo(
                codigo: 3,
                nombre: "Editores",
                //permisos: new List<Permiso> { permisos[0], permisos[1] } 
                permisos: new List<Permiso> {} 
            );
            List<Grupo> grupos = new List<Grupo> { grupoAdmin, grupoLectura, grupoEditores };



            // usuarios iniciales
            Usuario usuario1 = new Usuario(
                codigo: 1001,
                nombre: "Ana García",
                password: "AnaPass123",
                email: "ana.garcia@ejemplo.com",
                telefono: "011-1234-5678",
                grupo: grupoAdmin,
                permisos: grupoAdmin.Permisos.ToList()
            );
            Usuario usuario2 = new Usuario(
                codigo: 1002,
                nombre: "Luis Pérez",
                password: "LuisClave456",
                email: "luis.perez@ejemplo.com",
                telefono: "011-2345-6789",
                grupo: grupoLectura,
                permisos: grupoLectura.Permisos.ToList()
            );
            //Usuario usuario3 = new Usuario(
            //    codigo: 1003,
            //    nombre: "María López",
            //    password: "Maria789!",
            //    email: "maria.lopez@ejemplo.com",
            //    telefono: "011-3456-7890",
            //    grupo: grupoEditores,
            //    permisos: grupoEditores.Permisos.ToList()
            //);
            List<Usuario> usuarios = new List<Usuario> { usuario1, usuario2 };
            //List<Usuario> usuarios = new List<Usuario> { usuario1, usuario2, usuario3 };
            gestorUsuario.agregarUsuarios( usuarios );
                        
            gestorGrupo = new GestorGrupo(permisos, usuarios, grupos);

            //Alta Permisos
            //gestorPermiso.altaPermiso();
            //gestorPermiso.altaPermiso();

            //modificación permiso
            //gestorPermiso.modificarPermiso();

            //eliminar
            //gestorPermiso.eliminarPermiso();


            //listar
            //gestorPermiso.listarPermisos();

            //GRUPO GESTOR_____            
            //listar
            gestorGrupo.ListadoGrupo();
            //alta
            //gestorGrupo.AltaGrupo();
            //modificar
            //gestorGrupo.ModificarGrupo();
           // gestorGrupo.EliminarGrupo();
            //Console.ReadKey();
            //gestorGrupo.ListadoGrupo();


            //crearSemillas();



            //Console.ReadKey();
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Primer nivel (Clases):");
                Console.WriteLine("1 - Permiso");
                Console.WriteLine("2 - Grupo");
                Console.WriteLine("3 - Usuario");
                Console.WriteLine("4 - Salir");
                Console.Write("Ingrese opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuEntidad("Permiso",grupos,permisos,usuarios);
                        break;
                    case "2":
                        MenuEntidad("Grupo", grupos, permisos,usuarios);
                        break;
                    case "3":
                        MenuEntidad("Usuario", grupos, permisos,usuarios);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //private static void crearSemillas()
        //{

        //    // 2. Creamos listas de permisos
        //    var permisosAdmin = new List<Permiso>
        //    {
        //        new Permiso(1, "Crear", "Permite crear nuevos registros en el sistema"),
        //        new Permiso(2, "Editar", "Permite modificar registros existentes"),
        //        new Permiso(3, "Eliminar", "Permite eliminar registros del sistema")
        //    };

        //    var permisosBasicos = new List<Permiso>
        //    {
        //        new Permiso(4, "Ver", "Permite visualizar los datos sin modificarlos"),
        //        new Permiso(5, "Descargar", "Permite descargar archivos o reportes del sistema")
        //    };


        //    // 1. Definimos dos grupos
        //    Grupo grupoAdmin = new Grupo(1, "Administradores", permisosAdmin);
        //    Grupo grupoUsuario = new Grupo(2, "Usuarios", permisosBasicos);

        //    // 3. Instanciamos dos usuarios
        //    Usuario usuario1 = new Usuario(
        //        codigo: 1001,
        //        nombre: "Ana García",
        //        password: "AnaPass123",
        //        email: "ana.garcia@ejemplo.com",
        //        telefono: "011-1234-5678",
        //        grupo: grupoAdmin,
        //        permisos: permisosAdmin
        //    );

        //    Usuario usuario2 = new Usuario(
        //        codigo: 1002,
        //        nombre: "Juan Pérez",
        //        password: "JuanPass456",
        //        email: "juan.perez@ejemplo.com",
        //        telefono: "011-8765-4321",
        //        grupo: grupoUsuario,
        //        permisos: permisosBasicos
        //    );

        //    // 4. Mostramos por consola
        //    //Console.WriteLine(usuario2.ToString());
        //}

        static void MenuEntidad(string entidad,List<Grupo> grupos , List<Permiso> permisos,List<Usuario> usuarios)
        {
            bool salirEntidad = false;
            while (!salirEntidad)
            {
                Console.Clear();
                Console.WriteLine($"Segundo nivel - Entidad: {entidad}");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Alta");
                Console.WriteLine("3 - Modificación");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("5 - Salir");
                Console.Write("Ingrese opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"Listar {entidad}...");
                        // método que lista la entidad
                        if (entidad.ToLower() == "permiso")
                        {
                            gestorPermiso.listarPermisos();

                        }
                        else if (entidad.ToLower() == "grupo")
                        {
                            gestorGrupo.ListadoGrupo();
                        }
                        else
                        {
                            gestorUsuario.listarUsuarios();
                        }
                        break;
                    case "2":
                        Console.WriteLine($"Alta {entidad}...");
                        // método para dar de alta la entidad
                        if (entidad.ToLower() == "permiso")
                        {
                            gestorPermiso.altaPermiso();

                        }
                        else if (entidad.ToLower() == "grupo")
                        {
                            gestorGrupo.AltaGrupo();
                        }
                        else
                        {
                            gestorUsuario.altaUsuarios(grupos,permisos);
                        }
                        break;
                    case "3":
                        Console.WriteLine($"Modificación {entidad}...");
                        // método para modificar la entidad
                        if (entidad.ToLower() == "permiso")
                        {
                            gestorPermiso.ModificarPermiso();

                        }
                        else if (entidad.ToLower() == "grupo")
                        {
                            gestorGrupo.ListadoGrupo();
                            gestorGrupo.ModificarGrupo();
                        }
                        else
                        {
                            gestorUsuario.listarUsuarios();
                            gestorUsuario.modificarUsuario(grupos,permisos);
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Eliminar {entidad}...");
                        // método para eliminar la entidad
                        if (entidad.ToLower() == "permiso")
                        {
                            gestorPermiso.eliminarPermiso(usuarios,grupos);
                        }
                        else if (entidad.ToLower() == "grupo")
                        {
                            gestorGrupo.ListadoGrupo();
                            gestorGrupo.EliminarGrupo();
                        }
                        else
                        {
                            gestorUsuario.listarUsuarios();
                            gestorUsuario.eliminarUsuario();
                        }
                        break;
                    case "5":
                        salirEntidad = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
                        break;
                }

                if (!salirEntidad)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
