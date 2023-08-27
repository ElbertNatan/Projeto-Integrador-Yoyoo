<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarCategoria.aspx.cs" Inherits="Integrador_Yooyo.FORMULARIO2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="Estilo/Style.css" />
    <title>Editar categoria</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="cab"><ul><li><a href="IncialCriarPostagem.aspx"><img src="Imagem/Yoyoo W.png"/></a></li></ul></div>
            <div id="mm">
                <ul>
                    <li>
                        <div id="edit">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#3F0259" BorderWidth="3px" CellPadding="4" CssClass="detailsview" OnItemCommand="DetailsView1_ItemCommand" OnItemUpdated="DetailsView1_ItemUpdated">
                <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <Fields>
                    <asp:BoundField DataField="categoria_id" HeaderText="categoria_id" SortExpression="categoria_id" />
                    <asp:BoundField DataField="descricao" HeaderText="descricao" SortExpression="descricao" />
                    <asp:CommandField ShowEditButton="True" />
                </Fields>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" BorderColor="black" BorderStyle="Solid" BorderWidth="2px"/>
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
            </asp:DetailsView>
                </div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Integrador_Yooyo.Modelo.ModeloCategoria" SelectMethod="Select" TypeName="Integrador_Yooyo.DAL.DALCategoria" UpdateMethod="Update">
                <SelectParameters>
                    <asp:SessionParameter Name="categoria_id" SessionField="categoria_id" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
                
    
                    </li>
                </ul>
                <asp:Button ID="Button1" runat="server" Text="Voltar" PostBackUrl="~/InicialCriarCategoria.aspx" />
            </div>
            </div>
        </form>

</body>
    </html>
