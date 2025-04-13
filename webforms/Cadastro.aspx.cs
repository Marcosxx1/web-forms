using System;

namespace webforms
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarLista();
        }

        private void MostrarLista()
        {
            pnlCampoCadastro.Visible = false;
            pnlResultado.Visible = true;

            gridResultado.DataSource = Usuario.Lista;
            gridResultado.DataBind();
        }

        private void MostrarCadastro()
        {
            pnlCampoCadastro.Visible = true;
            pnlResultado.Visible = false;
        }
        protected void btnIrCadastro_Click(object sender, EventArgs e)
        {
            MostrarCadastro();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Nome = txtNome.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.Salvar();

            MostrarLista();
        }
    }
}