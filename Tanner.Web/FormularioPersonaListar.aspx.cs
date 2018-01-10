using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tanner.Web
{
    public partial class FormularioPersonaListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grdPersona.DataSource = Tanner.BLL.Persona.Listar();
                grdPersona.DataBind();
            }
        }
    }
}