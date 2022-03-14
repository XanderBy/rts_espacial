using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoLibreria.Principal
{
    public class Juego
    {

        private int _anchoPantalla;
        private int _altoPantalla;
        private ManejadorEstados _estado;


        public Juego(int anchoPantalla, int altoPantalla)
        {
            AnchoPantalla = anchoPantalla;
            AltoPantalla=altoPantalla;
            Estado = null;//, ManejadorEstados estado

        }


        public int AnchoPantalla {
            get { 
                return _anchoPantalla;
            }
            set
            {
                _anchoPantalla = value;
            }
        }
        public int AltoPantalla
        {
            get
            {
                return _altoPantalla;
            }
            set
            {
                _altoPantalla = value;
            }
        }
        public ManejadorEstados Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }



        public bool inicializacion()
        {

            return false;

        }
        public bool buclePrincipal()
        {



            return false;
        }
        public void eventos()
        {

        }
        public void eleccionEstados()
        {

        }


    }
}
