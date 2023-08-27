<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="Integrador_Yooyo.FORMULARIO1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="Estilo/Style.css" />
    <link rel="stylesheet" type="text/css" href="Estilo/Particules.css" />
    <title>Yoyoo</title>
</head>
<body >
    <form id="form1" runat="server">
        <div id="particles-js"></div>
        <div>
            <div id="cab" style="background-color:#4A77FF !important;"><ul><li><a href="PaginaInicial.aspx"><img src="Imagem/Yoyoo W.png"/></a></li></ul></div>
            <div  id="comandos">
                <img id="iyo" src="Imagem/Yoyoo B.png"/>
                <h2 style="margin-left: 10%; color:#4A77FF !important;">User:</h2>
                <asp:TextBox style="color:#4A77FF !important;border-color:#4A77FF !important;" ID="txtLogin" placeholder=" Joel" runat="server"></asp:TextBox><br />
                <h2 style="margin-left: 10%; color:#4A77FF !important;">Senha:</h2>
                <asp:TextBox style="color:#4A77FF !important;border-color:#4A77FF !important;" ID="txtSenha" textmode="Password" placeholder=" Dbest" runat="server"></asp:TextBox><br />
                <asp:Button style="background-color:#4A77FF !important;" ID="Logar" runat="server" Text="Logar" OnClick="Button1_Click" /><br />
                <asp:Button ID="Registrar" style="color:#4A77FF !important;" runat="server" Text="Registrar-se" OnClick="Button2_Click" />
                <asp:Label ID="Label1" style="color:#4A77FF !important;" Visible="false" runat="server" Text="Login ou Senha incorretos, por favor tente novamente"></asp:Label><br />
            </div>
            </div>
    </form>
           <script src="Prt/particles.js"></script>
           <script src="Prt/app.js"></script>
</body>
</html>
