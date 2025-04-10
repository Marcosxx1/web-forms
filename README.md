# Projeto WebForms

Este projeto é um exemplo simples de uma aplicação ASP.NET WebForms

## Índice

- [ Conceitos Demonstrados](#-conceitos-demonstrados)


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
