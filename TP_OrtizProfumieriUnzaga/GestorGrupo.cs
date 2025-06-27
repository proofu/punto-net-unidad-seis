using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_OrtizProfumieriUnzaga
{
    public class GestorGrupo
    {
        private List<Grupo> grupos;
        private List<Permiso> permisosDisponibles;

        public GestorGrupo(List<Permiso> permisosDisponibles)
        {
            this.grupos = new List<Grupo>();
            this.permisosDisponibles = permisosDisponibles ?? new List<Permiso>();
        }


        //LISTADO DE GRUPO
        public void ListadoGrupo()
        {
            Console.Clear();
            Console.WriteLine("======== LIstado de Grupos ======== ");

            if (grupos.Count == 0)
            {
                Console.WriteLine("No hay grupos");
                return;
            }

            foreach (var grupo in grupos)
            {
                Console.WriteLine(grupo.ToString());

            }
        }
        public void AltaGrupo()
        {
            Console.Clear();
            Console.WriteLine("===== Alta de Grupo =====");

            int codigo;
            do
            {
                Console.Write("Código: ");
                codigo = Validador.PedirEntero();

                if (grupos.Any(g => g.Codigo == codigo))
                {
                    Console.WriteLine("Ya existe un grupo con ese código. Intente nuevamente.");
                }
                else
                {
                    break; // válido, salimos del bucle
                }

            } while (true);

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            List<Permiso> permisosAsignados = SeleccionarPermisos();

            Grupo nuevoGrupo = new Grupo(codigo, nombre, permisosAsignados);
            grupos.Add(nuevoGrupo);

            Console.WriteLine("Grupo agregado con éxito");
        }
        public void ModificarGrupo()
        {
            Console.Clear();
            Console.WriteLine("===== Modificar Grupo =====");
            Console.Write("Ingrese el código del grupo a modificar: ");
            int codigo = Validador.PedirEntero();

            var grupo = grupos.FirstOrDefault(g => g.Codigo == codigo);

            if (grupo == null)
            {
                Console.WriteLine("No se encontró el grupo");
                return;
            }

            Console.WriteLine($"Grupo actual: {grupo}");
            Console.Write("Nuevo nombre  ");
            string nuevoNombre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                grupo.Nombre = nuevoNombre;
            }

            Console.WriteLine("Modificar permisos asignados? (s/n): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "s")
            {
                List<Permiso> nuevosPermisos = SeleccionarPermisos();
                

                ActualizarPermisosGrupo(grupo, nuevosPermisos);
            }

            Console.WriteLine("Grupo modificado con éxito");
        }
        private void ActualizarPermisosGrupo(Grupo grupo, List<Permiso> nuevosPermisos)
        {
            grupo.SetPermisos(nuevosPermisos);
        }

        private List<Permiso> SeleccionarPermisos()
        {
            List<Permiso> seleccionados = new List<Permiso>();

            if (permisosDisponibles.Count == 0)
            {
                Console.WriteLine("No hay permisos disponibles para asignar.");
                return seleccionados;
            }

            Console.WriteLine("Permisos disponibles:");
            foreach (var permiso in permisosDisponibles)
            {
                Console.WriteLine($"{permiso.Codigo} - {permiso.Nombre}");
            }

            Console.WriteLine("Ingrese los códigos de los permisos a asignar separados por comas (ejemplo: 1,3): ");
            string entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entrada)) return seleccionados;

            var codigos = entrada.Split(',').Select(c => c.Trim());

            foreach (var codStr in codigos)
            {
                if (int.TryParse(codStr, out int codigo))
                {
                    var permiso = permisosDisponibles.FirstOrDefault(p => p.Codigo == codigo);
                    if (permiso != null)
                    {
                        seleccionados.Add(permiso);
                    }
                }
            }

            return seleccionados;
        }
        // Método para cargar grupos de ejemplo
        public void CargarGruposIniciales()
        {
            grupos.Add(new Grupo(1, "Administradores", permisosDisponibles.ToList()));
            grupos.Add(new Grupo(2, "Usuarios", new List<Permiso> { permisosDisponibles.FirstOrDefault() }));
            grupos.Add(new Grupo(3, "Invitados", new List<Permiso>()));
        }
        

    }
}
