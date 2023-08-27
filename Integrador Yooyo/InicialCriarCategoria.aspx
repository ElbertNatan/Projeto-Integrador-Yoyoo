<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicialCriarCategoria.aspx.cs" Inherits="Integrador_Yooyo.InicialCriarCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="Estilo/Style.css" />
    <title>Categoria</title>
</head>
<body>

    <form id="form1" runat="server">
        <div id="cabb2">
            <div id="cabCC">
                <div id="cabi"><a href="PaginaAdmin.aspx"><img src="Imagem/Yoyoo W.png"/></a></div>   
                    <div id="cabE">
                        <div><asp:Label ID="txtlabel" runat="server" Text="Label"></asp:Label>
                        <asp:HyperLink ID="Hl" runat="server" NavigateUrl="~/PaginaInicial.aspx"> Sair</asp:HyperLink></div>
                        
                    </div>   
                </div>
         </div>
            <div id="cat">
                
                <ul>
                    <li><a><asp:TextBox ID="descricaoTXT" placeholder="Nome da Categoria" runat="server"></asp:TextBox></a></li>
                    <li><asp:Button ID="Button1" runat="server" Text="Criar Categoria" OnClick="Button_Click" /></li>
                  
                    
                </ul>
            </div>
        
        <div class="kk">
            
            
            <div id="post1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="categoria_id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" GridLines="Horizontal" CssClass="gridview52" AllowPaging="True" PageSize="5">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="categoria_id" HeaderText="Identificador" InsertVisible="False" ReadOnly="True" SortExpression="categoria_id" />
                    <asp:BoundField DataField="descricao" HeaderText="Nome da Categoria" SortExpression="descricao" />
                    <asp:ButtonField CommandName="Editar" HeaderText="Editar" Text="Editar" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton onclientclick="return confirm('Deseja exlcuir a categoria selecionada?')" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Excluir"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
                    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource2" DataTextField="sub_categoria" DataValueField="sub_categoria"></asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Ver_sub_categoria %>" SelectCommand="SELECT distinct[sub_categoria] FROM [Categoria]"></asp:SqlDataSource>
            </div>
            <asp:Label ID="Label1" Visible="false" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT [categoria_id], [descricao] FROM [Categoria]" DeleteCommand="DELETE FROM categoria WHERE categoria_id = @categoria_id">
            <DeleteParameters>
                <asp:Parameter Name="categoria_id" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
