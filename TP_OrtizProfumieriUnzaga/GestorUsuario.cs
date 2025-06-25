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
        

        public void listarUsuarios()
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
        }
        public void modificarUsuario()
        {

        }
    }
}
