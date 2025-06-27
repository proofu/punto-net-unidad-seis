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


        //LISTADO DE GRUPO
        public void listadoGrupo()
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
        }/*
        public void altaGrupo()
        {
            Console.Clear();
            Console.WriteLine("======= Alta de grupo =======");
            Console.WriteLine("Código: ");

            int codigo = Validador.PedirEntero();
            if (grupos.Any(g => g.Codigo == codigo))
            {
                Console.WriteLine("Ya existe ese grupo!");
                return;
            }

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            if (permisos.Count > 0)
            {
                Console.WriteLine("========== Permisos Disponibles======");
                foreach (var permiso in permisos)
                {
                    Console.WriteLine(permiso.ToString());
                }
            }
            Console.WriteLine("Ingrese el codigo");
            string entradaCodigo = Console.ReadLine();

        }*/

    }
}
