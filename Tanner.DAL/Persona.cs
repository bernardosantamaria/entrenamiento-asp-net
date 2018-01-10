using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace Tanner.DAL
{
    public class Persona
    {
        /// <summary>
        /// Funcion para buscar persona por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static List<Tanner.DTO.Persona> Buscar_por_nombre(string nombre)
        {
            List<Tanner.DTO.Persona> colleccion = new List<DTO.Persona>();
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;

                SqlConnection cnx = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "buscar_by_name";
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Connection = cnx;
                cnx.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Tanner.DTO.Persona persona = new DTO.Persona();
                    persona.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    persona.Apellido = ds.Tables[0].Rows[i]["apellido"].ToString();
                    persona.Rut = ds.Tables[0].Rows[i]["rut"].ToString();
                    persona.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    colleccion.Add(persona);
                }
                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
            return colleccion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public static Tanner.DTO.Persona ListarPorRut(string rut)
        {
            Tanner.DTO.Persona persona = new DTO.Persona() ;
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;

                SqlConnection cnx = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "select_persona_by_rut";
                cmd.Parameters.AddWithValue("@rut",rut);
                cmd.Connection = cnx;
                cnx.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);

                persona.Nombre = ds.Tables[0].Rows[0]["nombre"].ToString();
                persona.Apellido = ds.Tables[0].Rows[0]["apellido"].ToString();
                persona.Rut = ds.Tables[0].Rows[0]["rut"].ToString();
                persona.Eliminado = ds.Tables[0].Rows[0]["eliminado"].ToString();
                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
            return persona;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Tanner.DTO.Persona> Listar()
        {
            List<Tanner.DTO.Persona> colleccion = new List<DTO.Persona>();
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;

                SqlConnection cnx = new SqlConnection(con);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "select_persona";
                cmd.Connection = cnx;
                cnx.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Tanner.DTO.Persona persona = new DTO.Persona();
                    persona.Nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
                    persona.Apellido = ds.Tables[0].Rows[i]["apellido"].ToString();
                    persona.Rut = ds.Tables[0].Rows[i]["rut"].ToString();
                    persona.Eliminado = ds.Tables[0].Rows[i]["eliminado"].ToString();
                    colleccion.Add(persona);
                }
                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
            return colleccion;

        }
        /// <summary>
        /// metodo que graba una nueva persona mediante query
        /// </summary>
        /// <param name="persona"></param>
        public static void Grabar(Tanner.DTO.Persona persona)
        {
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;
                //string con = ConfigurationManager.AppSettings["miprueba"];

                SqlConnection cnx = new SqlConnection(con);

                //SqlDataAdapter da = new SqlDataAdapter("select * from persona", cnx);
                //ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT into persona (nombre,apellido) VALUES ('" + persona.Nombre + "', '" + persona.Apellido + "')";
                cmd.Connection = cnx;
                cnx.Open();
                cmd.ExecuteNonQuery();

                //da.Fill(ds,"persona");

                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
            ///conectar a la BD 
            ///realizar una operacion

        }
        /// <summary>
        /// metodo que graba una nueva persona y le asocia un nombre
        /// </summary>
        /// <param name="persona ">clase de tipo persona</param>
        /// <param name="nomre">nombre que documento</param>
        public static void GrabarConStoreProcedure(Tanner.DTO.Persona persona)
        {
            ///conectar a la BD 
            ///realizar una operacion
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;
                //string con = ConfigurationManager.AppSettings["miprueba"];

                SqlConnection cnx = new SqlConnection(con);

                //SqlDataAdapter da = new SqlDataAdapter("select * from persona", cnx);
                //ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "insert_persona";
                cmd.Parameters.Add("@Nombre", persona.Nombre);
                cmd.Parameters.Add("@Apellido", persona.Apellido);
                cmd.Connection = cnx;
                cnx.Open();
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                //da.Fill(ds,"persona");

                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
        }

        public static void Eliminar_Persona(int id)
        {
            ///conectar a la BD 
            ///realizar una operacion
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;
                //string con = ConfigurationManager.AppSettings["miprueba"];

                SqlConnection cnx = new SqlConnection(con);

                //SqlDataAdapter da = new SqlDataAdapter("select * from persona", cnx);
                //ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[eliminar_persona_by_id]";
                cmd.Parameters.Add("@id", id);
                cmd.Connection = cnx;
                cnx.Open();
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                //da.Fill(ds,"persona");

                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
        }

        /*public static void Actualiza_persona(int id, string nombre, string apellido, string rut)
        {
            ///conectar a la BD 
            ///realizar una operacion
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;
                //string con = ConfigurationManager.AppSettings["miprueba"];

                SqlConnection cnx = new SqlConnection(con);

                //SqlDataAdapter da = new SqlDataAdapter("select * from persona", cnx);
                //ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "update_persona";
                cmd.Parameters.Add("@Nombre", nombre);
                cmd.Parameters.Add("@Apellido", apellido);
                cmd.Parameters.Add("@Rut", rut);
                cmd.Parameters.Add("@Id", id);
                cmd.Connection = cnx;
                cnx.Open();
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                //da.Fill(ds,"persona");

                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
        }
        */

        public static void Actualiza_persona(Tanner.DTO.Persona persona)
        {
            ///conectar a la BD 
            ///realizar una operacion
            try
            {
                var con = ConfigurationManager.ConnectionStrings["miprueba"].ConnectionString;
                //string con = ConfigurationManager.AppSettings["miprueba"];

                SqlConnection cnx = new SqlConnection(con);

                //SqlDataAdapter da = new SqlDataAdapter("select * from persona", cnx);
                //ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "update_persona";
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@Rut", persona.Rut);
                cmd.Parameters.AddWithValue("@Id", persona.Id);
                cmd.Connection = cnx;
                cnx.Open();
                cmd.ExecuteNonQuery();
                //cmd.ExecuteReader();
                //da.Fill(ds,"persona");

                cnx.Close();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.StackTrace.ToString()+ "');</script>");
                System.Web.HttpContext.Current.Response.Write("El error es: " + ex.StackTrace.ToString());
            }
        }
    }
}
