using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanner.BLL
{
    public class Persona
    {
        public void Grabar(string nombre, string apellido)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public void Grabar(Tanner.DTO.Persona p)
        {
            //Tanner.DAL.Persona.Grabar(p);
            Tanner.DAL.Persona.GrabarConStoreProcedure(p);
            //Tanner.DAL.Persona.Grabar(p, "hol mundo");
            //   Tanner.DAL.Persona persona = new DAL.Persona();
            //   persona.Grabar(p);

        }
        public static List<Tanner.DTO.Persona> Buscar_por_nombre(string nombre)
        {
            return Tanner.DAL.Persona.Buscar_por_nombre(nombre);
        }

        public static Tanner.DTO.Persona ListarPorRut(string rut)
        {
            //Tanner.DAL.Persona.Grabar(p);
            return Tanner.DAL.Persona.ListarPorRut(rut);
            //Tanner.DAL.Persona.Grabar(p, "hol mundo");
            //   Tanner.DAL.Persona persona = new DAL.Persona();
            //   persona.Grabar(p);

        }
        /// <summary>
        /// metodo que elimina una persona y modifica su estado a eliminado 1
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar_Persona(int id)
        {
            Tanner.DAL.Persona.Eliminar_Persona(id);
        }

        public static List<Tanner.DTO.Persona> Listar()
        {
            return Tanner.DAL.Persona.Listar();
        }

        /*public static void Actualizar_persona(int id, string nombre, string apellido, string rut)
        {
            Tanner.DAL.Persona.Actualiza_persona(id, nombre, apellido, rut);
        }*/

        public static void Actualizar_persona(Tanner.DTO.Persona p)
        {
            Tanner.DAL.Persona.Actualiza_persona(p);
        }
    }
}
