<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="webforms.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlCampoCadastro" runat="server">
                <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox>
                <br />
                <asp:Label ID="lblTelefone" runat="server" Text="Telefone"></asp:Label>
                <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            </asp:Panel>
        </div>
        <asp:Panel ID="pnlResultado" runat="server">
            <asp:Button ID="btnIrCadastro" runat="server" Text="Novo Cadastro" OnClick="btnIrCadastro_Click" />
            <asp:GridView ID="gridResultado" runat="server">
            </asp:GridView>
        </asp:Panel>
    </form>
</body>
</html>
