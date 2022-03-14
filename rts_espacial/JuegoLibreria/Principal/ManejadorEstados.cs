using JuegoLibreria.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JuegoLibreria.Principal
{
    public class ManejadorEstados
    {

        private Opciones _estadoOpciones;
        private Menu _estadoMenu;
        private Partida _estadoPartida;
        private EnumEstado _estados;


        public ManejadorEstados()
        {

        }


        public Opciones EstadoOpciones 
        {
            get
            {
                return _estadoOpciones;
            }
            set
            {
                _estadoOpciones = value;
            }
        }
        public Menu EstadoMenu
        {
            get
            {
                return _estadoMenu;
            }
            set
            {
                _estadoMenu = value;
            }
        }
        public Partida EstadoPartida
        {
            get
            {
                return _estadoPartida;
            }
            set
            {
                _estadoPartida = value;
            }
        }

    }
}
