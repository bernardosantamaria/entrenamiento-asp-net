using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tanner.Web
{
    public partial class FormularioPersonaListarPorRut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Llenar_DropDownList();
            }
            
            //ddlPersona.SelectedItem.ToString
        }

        public void Llenar_DropDownList()
        {
            ddlPersona.DataSource = Tanner.BLL.Persona.Listar() ;
            ddlPersona.DataTextField = "nombre";
            ddlPersona.DataValueField = "rut";
            ddlPersona.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Tanner.DTO.Persona resultado;
            resultado = Tanner.BLL.Persona.ListarPorRut(this.ddlPersona.SelectedValue);
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + resultado.Nombre + " " + resultado.Apellido + "')</script>");
        }

        protected void ddlPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Tanner.DTO.Persona resultado;
            resultado = Tanner.BLL.Persona.ListarPorRut(this.ddlPersona.SelectedValue);
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + resultado.Nombre + "')</script>");*/
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //System.Web.HttpContext.Current.Response.Write("<script>alert('hola')</script>");

            grdBuscar.DataSource = Tanner.BLL.Persona.Buscar_por_nombre(txtNombre.Text.ToString());
            grdBuscar.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //this.GridView1_RowDeleting(this,e);
            //grdBuscar.DataSourceID
            //System.Web.HttpContext.Current.Response.Write("<script>alert('Botón Eliminar')</script>");
        }

        public void refreshdata()
        {
            grdBuscar.DataSource = Tanner.BLL.Persona.Buscar_por_nombre(txtNombre.Text.ToString());
            grdBuscar.DataBind();
        }
        protected void grdBuscar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBuscar.EditIndex = e.NewEditIndex;
            refreshdata();
        }
        protected void grdBuscar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");

            TextBox nombre = grdBuscar.Rows[e.RowIndex].FindControl("TextBoxNombre") as TextBox;
            TextBox apellido = grdBuscar.Rows[e.RowIndex].FindControl("TextBoxApellido") as TextBox;
            TextBox rut = grdBuscar.Rows[e.RowIndex].FindControl("TextBoxRut") as TextBox;
            int id = Convert.ToInt16(grdBuscar.DataKeys[e.RowIndex].Values["ID"].ToString());

            Tanner.DTO.Persona p = new Tanner.DTO.Persona();

            p.Nombre = nombre.Text.ToString();
            p.Apellido = apellido.Text.ToString();
            p.Rut = rut.Text.ToString();
            p.Id = id;

            Tanner.BLL.Persona.Actualizar_persona(p);

            //con.Open();
            //SqlCommand cmd = new SqlCommand("sp_updatedata", con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("name", txtname.Text);
            //cmd.Parameters.AddWithValue("city", txtcity.Text);
            //cmd.Parameters.AddWithValue("id", id);

            //int i = cmd.ExecuteNonQuery();
            //con.Close();
            
            grdBuscar.EditIndex = -1;
            refreshdata();
        }

        protected void grdBuscar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(grdBuscar.DataKeys[e.RowIndex].Values["ID"].ToString());
            Tanner.BLL.Persona.Eliminar_Persona(id);
            refreshdata();
        }

        protected void grdBuscar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBuscar.EditIndex = -1;
            refreshdata();
        }
    }
}