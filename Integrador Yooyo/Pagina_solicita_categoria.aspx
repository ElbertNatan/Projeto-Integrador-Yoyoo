<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaterTeste.Master" AutoEventWireup="true" CodeBehind="Pagina_solicita_categoria.aspx.cs" Inherits="Integrador_Yooyo.Pagina_solicita_categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="divSub" class="card d-flex ml-auto mr-auto" style="width:500px;">
        <h4>Solicitar Categoria</h4>
        <asp:TextBox class="input-group-text" style="background-color:white;" ID="TextBox1" placeholder="Nome da Categoria" runat="server"></asp:TextBox><br />
        <asp:ListBox id="listbx1" runat="server" DataSourceID="SqlDataSource1" DataTextField="sub_categoria" DataValueField="sub_categoria"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT DISTINCT(sub_categoria) from categoria"></asp:SqlDataSource>
       <br /><div style="margin-left:5px;">
        <asp:Button ID="btnconfirma" OnClick="btnconfirma_Click" Width="490px" style="margin-bottom:3px;" runat="server" class="btn btn-success" Text="Confirmar" />
        <asp:Button ID="btnCancela" runat="server" width="490px" class="btn btn-danger" PostBackUrl="~/PaginaInicialPostagem.aspx" Text="Cancelar" />
           </div>
    </div>
    
</asp:Content>

