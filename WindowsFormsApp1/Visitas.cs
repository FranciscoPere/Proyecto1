using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Visitas
    {
        private string link;
        private int contador;
       
        public Visitas(String link, int contador)
        {
            this.link = link;
            this.contador = contador;

        }

        public String Link() {
            return link;
        
        }

       
        public int contados()
        {

            return contador;
        }
    }
}
