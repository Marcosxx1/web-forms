using System.Collections.Generic;

namespace webforms
{
    public class Usuario
    {
        public Usuario() { }

        public string Nome { get; set; }
        public string Telefone { get; set; }

        public static List<Usuario> Lista = new List<Usuario>();

        public List<Usuario> Todos()
        {
            return Usuario.Lista;
        }

        public void Salvar()
        {
            Lista.Add(this);
        }
    }
}