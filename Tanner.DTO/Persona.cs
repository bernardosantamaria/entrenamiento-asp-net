using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanner.DTO
{
    public class Persona
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string rut;
        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        private string eliminado;
        public string Eliminado
        {
            get { return eliminado; }
            set { eliminado = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
