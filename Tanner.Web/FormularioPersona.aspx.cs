using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tanner.Web
{
    public partial class FormularioPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // btnGrabar1.Enabled = false;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Tanner.BLL.Persona p = new Tanner.BLL.Persona();
            Tanner.DTO.Persona persona = new DTO.Persona();

            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;

            p.Grabar(persona);
        }
    }
}