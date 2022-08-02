using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS
{
    public partial class MenuP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pedidos/Pedidos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("ABM/Alta_articulo.aspx");
        }
    }
}