<%@ Page Title="" Language="C#" MasterPageFile="~/AddUsers.master" AutoEventWireup="true" CodeBehind="PaginaVisualizar_Usuarios.aspx.cs" Inherits="Integrador_Yooyo.PaginaVisualizar_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:SqlDataSource ID="data_amigos_add" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT *
from usuario as us
WHERE us.login NOT IN(Select (seguido) FROM usuarioSeguir as se WHERE se.login = @login  )
AND us.login != 'admin' AND us.login != @login">
        <SelectParameters>
            <asp:SessionParameter Name="login" SessionField="login" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>

            <div style="display:inline-flex; width:350px; margin-left:20%; top:4%;"  class="container">
                    
                    <div class="card col" style="width: 400px">

                        <img class="card-img-top" src="ImagemPerfilUsers/<%#Eval("perfil_foto") %>.png" alt="Card image" style="width: 70%">
                        <div class="card-body">
                            <h4 class="card-title"><%#Eval("login") %></h4>
                            <p class="card-text"><%#Eval("perfil_recado") %></p>
                            <a href="PaginaPerfilVisita.aspx?user=<%#Eval("login") %>" class="btn btn-primary stretched-link">Ver Perfil</a>
                            
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
