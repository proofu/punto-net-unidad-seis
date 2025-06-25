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
            gestorPermiso.altaPermiso();
            gestorPermiso.altaPermiso();
            gestorPermiso.altaPermiso();
            gestorPermiso.listarPermisos();
            Console.ReadKey();









            //bool salir = false;
            //while (!salir)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Primer nivel (Clases):");
            //    Console.WriteLine("1 - Permiso");
            //    Console.WriteLine("2 - Grupo");
            //    Console.WriteLine("3 - Usuario");
            //    Console.WriteLine("4 - Salir");
            //    Console.Write("Ingrese opción: ");
            //    string opcion = Console.ReadLine();

            //    switch (opcion)
            //    {
            //        case "1":
            //            MenuEntidad("Permiso");
            //            break;
            //        case "2":
            //            MenuEntidad("Grupo");
            //            break;
            //        case "3":
            //            MenuEntidad("Usuario");
            //            break;
            //        case "4":
            //            salir = true;
            //            break;
            //        default:
            //            Console.WriteLine("Opción inválida. Presione una tecla para continuar.");
            //            Console.ReadKey();
            //            break;
            //    }
            //}
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
