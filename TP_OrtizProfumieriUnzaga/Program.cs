using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorPermiso gestorPermiso = new GestorPermiso();

            //Alta Permisos
            //gestorPermiso.altaPermiso();
            //gestorPermiso.altaPermiso();

            //modificación permiso
            //gestorPermiso.modificarPermiso();

            //eliminar
            //gestorPermiso.eliminarPermiso();


            //listar
            //gestorPermiso.listarPermisos();


            

            crearSemillas();



            Console.ReadKey();

        }

        private static void crearSemillas()
        {

            // 2. Creamos listas de permisos
            var permisosAdmin = new List<Permiso>
            {
                new Permiso(1, "Crear", "Permite crear nuevos registros en el sistema"),
                new Permiso(2, "Editar", "Permite modificar registros existentes"),
                new Permiso(3, "Eliminar", "Permite eliminar registros del sistema")
            };

            var permisosBasicos = new List<Permiso>
            {
                new Permiso(4, "Ver", "Permite visualizar los datos sin modificarlos"),
                new Permiso(5, "Descargar", "Permite descargar archivos o reportes del sistema")
            };


            // 1. Definimos dos grupos
            Grupo grupoAdmin = new Grupo(1, "Administradores", permisosAdmin);
            Grupo grupoUsuario = new Grupo(2, "Usuarios", permisosBasicos);

            // 3. Instanciamos dos usuarios
            Usuario usuario1 = new Usuario(
                codigo: 1001,
                nombre: "Ana García",
                password: "AnaPass123",
                email: "ana.garcia@ejemplo.com",
                telefono: "011-1234-5678",
                grupo: grupoAdmin,
                permisos: permisosAdmin
            );

            Usuario usuario2 = new Usuario(
                codigo: 1002,
                nombre: "Juan Pérez",
                password: "JuanPass456",
                email: "juan.perez@ejemplo.com",
                telefono: "011-8765-4321",
                grupo: grupoUsuario,
                permisos: permisosBasicos
            );

            // 4. Mostramos por consola
            Console.WriteLine(usuario2.ToString());
        }

        static void MenuEntidad(string entidad)
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
                        // Aquí llamás al método que lista la entidad
                        break;
                    case "2":
                        Console.WriteLine($"Alta {entidad}...");
                        // Aquí llamás al método para dar de alta la entidad
                        break;
                    case "3":
                        Console.WriteLine($"Modificación {entidad}...");
                        // Aquí llamás al método para modificar la entidad
                        break;
                    case "4":
                        Console.WriteLine($"Eliminar {entidad}...");
                        // Aquí llamás al método para eliminar la entidad
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
