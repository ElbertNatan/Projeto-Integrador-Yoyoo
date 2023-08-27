<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaRegistro.aspx.cs" Inherits="Integrador_Yooyo.PaginaRegistro" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" type="text/css" href="Estilo/Style.css" />
        <title></title>
    </head>

    <body>
        <form id="form1" runat="server">
            <div>
                <div style="background-color:#4A77FF !important;" id="cab">
                    <ul>
                        <li>
                            <a href="PaginaInicial.aspx"><img src="Imagem/Yoyoo W.png" /></a>
                        </li>
                    </ul>
                </div>
                <div id="comandos">
                    <img id="iyo" src="Imagem/Yoyoo B.png" />
                    <h2 style="margin-left: 10%; color:#4A77FF !important;">User:</h2>
                    <asp:TextBox  style="color:#4A77FF !important;border-color:#4A77FF !important;" ID="txtLogin" placeholder=" Usuário" runat="server"></asp:TextBox>
                    <h2 style="margin-left: 10%; color:#4A77FF !important;">Senha:</h2>
                    <asp:TextBox  style="color:#4A77FF !important;border-color:#4A77FF !important;" ID="txtSenha" placeholder=" Senha" runat="server"></asp:TextBox><br />
                    <h2 style="margin-left: 10%; color:#4A77FF !important;">Confirmar senha:</h2>
                    <asp:TextBox  style="color:#4A77FF !important;border-color:#4A77FF !important;" ID="txtConf" placeholder=" Senha" runat="server"></asp:TextBox><br />
                    <asp:Button style="background-color:#4A77FF !important;" ID="Logar" runat="server" Text="Registrar-se" OnClick="Button1_Click" /><br />
                    <asp:HyperLink style="margin-left:34%; color:#4A77FF !important;" ID="HyperLink1" runat="server" NavigateUrl="~/PaginaInicial.aspx">Voltar para o Login</asp:HyperLink>
                    <asp:Label ID="Label1" Visible="false" runat="server" Text="Você foi cadastrado com sucesso!"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT [login], [senha] FROM [Usuario]"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor colocar um nome de usuário válido" ControlToValidate="txtLogin"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Por favor colocar uma senha de usuário válido" ControlToValidate="txtSenha"></asp:RequiredFieldValidator><br />

                </div>
            </div>
        </form>
    </body>

    </html>