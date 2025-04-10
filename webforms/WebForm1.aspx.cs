using System;

namespace webforms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Olá asdasd"+ txtMensagem.Text);

            Response.Write("Telefone " + Request["telefone"]);

            Response.Write("<script>alert(' Olá " + txtMensagem.Text + "')</script>");
        }

        protected void txtMensagem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}