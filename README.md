# Projeto WebForms

Este projeto é um exemplo simples de uma aplicação ASP.NET WebForms

## Índice

- [ Conceitos Demonstrados](#-conceitos-demonstrados)
- [ Componentes HTML](#componentes-html)
- [ Componentes C#](#componentes-c)
- [ Cadastro em memória](#cadastro-em-memória)
    - [ http](#http-form-e-query)
    - [ Request](#request)
    - [ runat server](#runat-server)

# Cadastro em memória
# http (.form e .query)
# Request 
# runat server

##  Conceitos Demonstrados

- Manipulação de eventos com `Button_Click`
- Leitura de valores via `Request`
- Diferenças entre componentes WebForms e elementos HTML puros
- Exibição de mensagens com `Response.Write`

## Estrutura do Código

```html
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webforms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtMensagem" runat="server" OnTextChanged="txtMensagem_TextChanged"></asp:TextBox>

        <input type="text" name="telefone" id="telefone" runat="server" />

        <asp:Button ID="Button1" runat="server" Text="Mostrar mensagem" OnClick="Button1_Click" />
    </form>
</body>
</html> 
```


```csharp
protected void Button1_Click(object sender, EventArgs e)
{
    Response.Write("Olá " + txtMensagem.Text);
    Response.Write("Telefone " + Request["telefone"]);
}
```

Tudo que estiver dentro de um `<form>` com submit será enviado como `Request`.

Podemos utilizar tanto os controles ASP.NET quanto elementos HTML, porém ao usar elementos HTML, deve-se tratar os dados manualmente com `Request["nome"]` no lado do servidor.

---

## Componentes HTML

```html
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webforms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>

        <input type="text" name="telefone" id="telefone" runat="server" />
            <asp:TextBox ID="txtMensagem" runat="server" OnTextChanged="txtMensagem_TextChanged"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Mostrar mensagem" OnClick="Button1_Click" />
        </div>
        <br>
        <br>
        <br>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        <br>
        <br />
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </form>

</body>
</html> 
```

Elementos HTML padrão (como `<input>`, `<div>`, etc.) podem ser utilizados no WebForms, mas **precisam do atributo `runat="server"`** para serem acessíveis no *code-behind*.

### Exemplo:

```html
<input type="text" name="telefone" id="telefone" runat="server" />
```

No C# (`.aspx.cs`), é possível acessar o valor desse campo diretamente:

```csharp
Response.Write("Telefone " + Request["telefone"]);
```

Sem `runat="server"`, o elemento será tratado apenas como um HTML comum, e você só poderá acessar seus valores via `Request`.

---

## Componentes C#

```csharp
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
```

Controles do ASP.NET como `TextBox`, `Button`, `DropDownList` e `GridView` **já possuem `runat="server"` por padrão**, e são automaticamente reconhecidos no *code-behind*.

### Exemplo:

```html
<asp:TextBox ID="txtMensagem" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" />
```

A interação é direta:

```csharp
Response.Write("Olá " + txtMensagem.Text);
```

---

## Data Source

O *data source* define a fonte de dados que será usada para alimentar componentes como `DropDownList` ou `GridView`.

No exemplo abaixo, é utilizada uma lista de objetos `Usuario` para popular esses controles.

```csharp
public List<Usuario> nomes = new List<Usuario>();

protected void Page_Load(object sender, EventArgs e)
{
    nomes.Add(new Usuario() { Nome = "Marcos", Id = 1 });
    nomes.Add(new Usuario() { Nome = "Aline", Id = 2 });

    PreencheDropDownList();
    PreencheGridView();
}
```

---

## Data Bind

O método `DataBind()` aplica os dados do `DataSource` aos controles visuais.

### DropDownList

```csharp
DropDownList1.DataValueField = "Id";
DropDownList1.DataTextField = "Nome";
DropDownList1.DataSource = nomes;
DropDownList1.DataBind();
```

### GridView

```csharp
GridView1.DataSource = nomes;
GridView1.DataBind();
```

Esses métodos fazem com que os dados da lista `nomes` sejam exibidos automaticamente nos controles.

---

## HTML Dinâmico

É possível gerar conteúdo HTML dinâmico no lado do servidor usando `Response.Write`.

### Exemplo:

```csharp
Response.Write("<script>alert('Olá " + txtMensagem.Text + "')</script>");
```

Esse comando injeta um `alert()` diretamente no HTML retornado ao navegador, exibindo o conteúdo do campo `txtMensagem`.

---

## Interação Code Behind x HTML

A principal característica do WebForms é a forte integração entre a camada de apresentação (HTML/ASP.NET) e o *code-behind* (C#).

- Controles com `runat="server"` são acessados diretamente como objetos em C#.
- Eventos como `OnClick`, `OnTextChanged` ou `OnSelectedIndexChanged` disparam métodos no servidor.

### Exemplo:

```html
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" />
```

```csharp
protected void Button1_Click(object sender, EventArgs e)
{
    Response.Write("Olá " + txtMensagem.Text);
}
```

Essa abordagem permite uma separação clara de responsabilidades, mantendo a lógica de negócio no *code-behind* e a interface no `.aspx`.

## Cadastro em Memória
Nesta seção, demonstramos como um cadastro pode ser gerenciado em memória, sem a necessidade de persistir os dados em um banco. Em nosso exemplo, os dados do usuário (nome e telefone) são coletados, encapsulados em um objeto `Usuario` e adicionados a uma lista interna. Essa lista é utilizada para popular um controle do tipo `GridView`, permitindo a visualização dos registros cadastrados durante a execução da aplicação.

Exemplo de código no *code-behind*:

```csharp
protected void btnSalvar_Click(object sender, EventArgs e)
{
    // Cria um novo usuário com os dados dos campos de entrada
    Usuario usuario = new Usuario();
    usuario.Nome = txtNome.Text;
    usuario.Telefone = txtTelefone.Text;
    usuario.Salvar();
    
    // Após salvar, exibe a lista atualizada
    MostrarLista();
}
```

No método `MostrarLista()`, o painel de cadastro é ocultado e o painel de resultado é exibido, vinculando a lista de usuários ao controle `GridView`:

```csharp
private void MostrarLista()
{
    pnlCampoCadastro.Visible = false;
    pnlResultado.Visible = true;

    gridResultado.DataSource = Usuario.Lista;
    gridResultado.DataBind();
}
```

---

## http (.form e .query)

Em aplicações ASP.NET WebForms, o envio dos dados para o servidor ocorre através do elemento `<form>`. Ao incluir o atributo `runat="server"` no `<form>`, o ASP.NET gerencia automaticamente os dados submetidos tanto via *form* quanto via *query string*.

No exemplo, o formulário é definido assim:

```aspx
<form id="form1" runat="server">
    <div>
        <!-- Painel para cadastro -->
        <asp:Panel ID="pnlCampoCadastro" runat="server">
            <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox>
            <br />
            <asp:Label ID="lblTelefone" runat="server" Text="Telefone"></asp:Label>
            <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </asp:Panel>
    </div>
    <asp:Panel ID="pnlResultado" runat="server">
        <asp:Button ID="btnIrCadastro" runat="server" Text="Novo Cadastro" OnClick="btnIrCadastro_Click" />
        <asp:GridView ID="gridResultado" runat="server">
        </asp:GridView>
    </asp:Panel>
</form>
```

O formulário envia os dados dos controles que possuem o atributo `runat="server"`, permitindo que estes sejam manipulados diretamente no *code-behind*.

---

## Request

O objeto `Request` é utilizado para capturar os dados enviados pelo cliente, seja através de formulários (*form*) ou pela *query string*. Em WebForms, apesar de termos controles que já vinculam seus valores automaticamente, é possível acessar dados enviados diretamente via `Request["nomeCampo"]`.

Embora no exemplo fornecido os dados sejam manipulados via controles ASP.NET, a lógica do `Request` é importante quando se trabalha com elementos HTML puros ou precisa processar dados de forma personalizada.

Exemplo (em cenários onde você utiliza elementos HTML sem o processamento automático):

```csharp
// Exemplo de como acessar um dado enviado via Request
string telefone = Request["telefone"];
Response.Write("Telefone: " + telefone);
```

Nesse cenário, mesmo que o campo esteja declarado com `runat="server"`, o uso do `Request` pode ser útil para manipulações específicas ou para acessar valores enviados via query string.

---

## runat server

O atributo `runat="server"` é essencial no ASP.NET WebForms para que os elementos HTML e controles ASP.NET sejam processados pelo servidor. Ao definir esse atributo:

- **Controles ASP.NET:** Já vêm preparados com esse atributo e permitem a manipulação direta no *code-behind*. Exemplos: `<asp:TextBox>`, `<asp:Button>`, `<asp:GridView>`.
  
- **Elementos HTML puros:** Precisam do atributo `runat="server"` para que se tornem acessíveis no servidor. Sem ele, os dados desses elementos não são automaticamente processados pelo framework e só podem ser acessados via `Request`.

Exemplo de declaração:

```aspx
<asp:Panel ID="pnlCampoCadastro" runat="server">
    <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
    <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox>
</asp:Panel>
```

Essa integração entre a camada de apresentação e o *code-behind* permite que a lógica de negócio seja implementada em C# enquanto a interface é definida em HTML/ASP.NET, promovendo uma separação clara das responsabilidades.

