using System;
using System.Collections.Generic;

namespace webforms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Usuario> nomes = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            nomes.Add(new Usuario() { Nome = "Marcos", Id = 1 });
            nomes.Add(new Usuario() { Nome = "Aline", Id = 2 });

            PreencheDropDownList();
            PreencheGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Olá asdasd"+ txtMensagem.Text);

            Response.Write("Telefone " + Request["telefone"]);

            Response.Write("<script>alert(' Olá " + txtMensagem.Text + "')</script>");
        }

        public void PreencheDropDownList()
        {

            DropDownList1.DataValueField = "Id";
            DropDownList1.DataTextField = "Nome";

            DropDownList1.DataSource = nomes;
            DropDownList1.DataBind();
        }

        public void PreencheGridView()
        {
            GridView1.DataSource = nomes;
            GridView1.DataBind();
        }


        protected void txtMensagem_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

public class Usuario
{
    public long Id { get; set; }
    public string Nome { get; set; }

}