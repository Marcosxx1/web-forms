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