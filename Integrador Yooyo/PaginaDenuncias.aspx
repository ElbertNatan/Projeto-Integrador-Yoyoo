<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaterTeste.Master" AutoEventWireup="true" CodeBehind="PaginaDenuncias.aspx.cs" Inherits="Integrador_Yooyo.PaginaDenuncias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {

            $('.star').on('click', function () {
                $(this).toggleClass('star-checked');
            });

            $('.ckbox label').on('click', function () {
                $(this).parents('tr').toggleClass('selected');
            });

            $('.btn-filter').on('click', function () {
                var $target = $(this).data('target');
                if ($target != 'all') {
                    $('.table tr').css('display', 'none');
                    $('.table tr[data-status="' + $target + '"]').fadeIn('slow');
                } else {
                    $('.table tr').css('display', 'none').fadeIn('slow');
                }
            });

        });
    </script>
    <style>
        body {
            font-family: 'Open Sans', sans-serif;
            color: #353535;
        }

        .content h1 {
            text-align: center;
        }

        .content .content-footer p {
            color: #6d6d6d;
            font-size: 12px;
            text-align: center;
        }

            .content .content-footer p a {
                color: inherit;
                font-weight: bold;
            }

        /*	--------------------------------------------------
	:: Table Filter
	-------------------------------------------------- */
        .panel {
            border: 1px solid #ddd;
            background-color: #fcfcfc;
        }

            .panel .btn-group {
                margin: 15px 0 30px;
            }

                .panel .btn-group .btn {
                    transition: background-color .3s ease;
                }

        .table-filter {
            background-color: #fff;
            border-bottom: 1px solid #eee;
        }

            .table-filter tbody tr:hover {
                cursor: pointer;
                background-color: #eee;
            }

            .table-filter tbody tr td {
                padding: 10px;
                vertical-align: middle;
                border-top-color: #eee;
            }

            .table-filter tbody tr.selected td {
                background-color: #eee;
            }

            .table-filter tr td:first-child {
                width: 38px;
            }

            .table-filter tr td:nth-child(2) {
                width: 35px;
            }

        .ckbox {
            position: relative;
        }

            .ckbox input[type="checkbox"] {
                opacity: 0;
            }

            .ckbox label {
                -webkit-user-select: none;
                -moz-user-select: none;
                -ms-user-select: none;
                user-select: none;
            }

                .ckbox label:before {
                    content: '';
                    top: 1px;
                    left: 0;
                    width: 18px;
                    height: 18px;
                    display: block;
                    position: absolute;
                    border-radius: 2px;
                    border: 1px solid #bbb;
                    background-color: #fff;
                }

            .ckbox input[type="checkbox"]:checked + label:before {
                border-color: #2BBCDE;
                background-color: #2BBCDE;
            }

            .ckbox input[type="checkbox"]:checked + label:after {
                top: 3px;
                left: 3.5px;
                content: '\e013';
                color: #fff;
                font-size: 11px;
                font-family: 'Glyphicons Halflings';
                position: relative;
            }

        .table-filter .star {
            color: #ccc;
            text-align: center;
            display: block;
        }

            .table-filter .star.star-checked {
                color: #F0AD4E;
            }

            .table-filter .star:hover {
                color: #ccc;
            }

            .table-filter .star.star-checked:hover {
                color: #F0AD4E;
            }

        .table-filter .media-photo {
            margin-right: 10px;
            width: 35px;
        }

        .table-filter .media-body {
            display: block;
            /* Had to use this style to force the div to expand (wasn't necessary with my bootstrap version 3.3.6) */
        }

        .table-filter .media-meta {
            font-size: 11px;
            color: #999;
        }

        .table-filter .media .title {
            color: #2BBCDE;
            font-size: 14px;
            font-weight: bold;
            line-height: normal;
            margin: 0;
        }

            .table-filter .media .title span {
                font-size: .8em;
                margin-right: 20px;
            }

                .table-filter .media .title span.pagado {
                    color: #5cb85c;
                }

                .table-filter .media .title span.pendiente {
                    color: #f0ad4e;
                }

                .table-filter .media .title span.cancelado {
                    color: #d9534f;
                }

        .table-filter .media .summary {
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  
    
       
    <div class="container">
        <div style="margin-left:18%; margin-top:40px;">
        <asp:Button runat="server" class="btn btn-info" Text="Solicitações de Categoria" OnClick="solicita_cat_click"></asp:Button>
    <asp:Button runat="server" class="btn btn-info" Text="Denuncias de Postagem" OnClick="denuncia_post_click"></asp:Button>
              <asp:Button runat="server" class="btn btn-info" Text="Denuncias de Usuario" OnClick="denun_perfil_click"></asp:Button>
            </div>
        <div class="row">
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_postagem where status = 'Postagem Excluida'  AND login = @login">  <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
              
   

            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_postagem  where status = 'pendente' AND login = @login">
                <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
       
  
            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_postagem  where status = 'Solicitação negada' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from solicita_categoria where status = 'Aprovado' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>     
   

            <asp:SqlDataSource runat="server" ID="SqlDataSource5" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from solicita_categoria  where status = 'pendente' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
       
  
            <asp:SqlDataSource runat="server" ID="SqlDataSource6" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from solicita_categoria  where status = 'Recusada' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:SqlDataSource runat="server" ID="SqlDataSource7" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_usuario where status = 'Aprovado' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
   

            <asp:SqlDataSource runat="server" ID="SqlDataSource8" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_usuario  where status = 'pendente' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
  
            <asp:SqlDataSource runat="server" ID="SqlDataSource9" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from denuncia_usuario where status = 'Recusada' AND login = @login"> <SelectParameters>
                    <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
                


              <section id="denun_user" runat="server" class="content justify-content-center" style="display:none;">
              
                <div class="col-md-8 col-md-offset-2">
                    <div style="width: 900px;" class="panel panel-default">
                        <div class="panel-body">
                            <div style="margin-top:30px; margin-bottom:-55px; margin-left:10px;">
                               
                            <h3>Denuncias de Perfil</h3>
                                </div>
                            <div class="pull-right">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-success btn-filter" data-target="pagado2">Aprovado</button>
                                    <button type="button" class="btn btn-warning btn-filter" data-target="pendiente2">Em Análise</button>
                                    <button type="button" class="btn btn-danger btn-filter" data-target="cancelado2">Cancelado</button>
                                    <button type="button" class="btn btn-default btn-filter" data-target="all">Todos</button>
                                </div>
                            </div>
                            <div class="table-container">
                                <table class="table table-filter">
                                    <tbody>
                                        <asp:Repeater ID="Repeater7" DataSourceID="SqlDataSource7" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pagado2">

                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title">Denuncia por <%# Eval("login") %>
													
                                                            <span class="pull-right pagado">(Aprovado)</span>
                                                                </h4>
                                                                <p class="summary">Perfil Denunciado: <%# Eval("denunciado") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater8" DataSourceID="SqlDataSource8" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pendiente2">
                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title"> Denuncia por <%# Eval("login") %>
													
                                                            <span class="pull-right pendiente">(Pendente)</span>
                                                                </h4>
                                                                <p class="summary">Perfil Denunciado: <%# Eval("denunciado") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater9" DataSourceID="SqlDataSource9" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="cancelado2">


                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title"> Denuncia por <%# Eval("login") %>
													
                                                            <span class="pull-right cancelado">(Cancelado)</span>
                                                                </h4>
                                                                <p class="summary">Perfil Denunciado: <%# Eval("denunciado") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    
                    </div>
                </div>
            </section>


            <section id="solicita_cat_sec" runat="server" class="content justify-content-center" style="display:none;">
              
                <div class="col-md-8 col-md-offset-2">
                    <div style="width: 900px;" class="panel panel-default">
                        <div class="panel-body">
                            <div style="margin-top:30px; margin-bottom:-55px; margin-left:10px;">
                               
                            <h3>Solicitações de Categoria</h3>
                                </div>
                            <div class="pull-right">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-success btn-filter" data-target="pagado2">Aprovado</button>
                                    <button type="button" class="btn btn-warning btn-filter" data-target="pendiente2">Em Análise</button>
                                    <button type="button" class="btn btn-danger btn-filter" data-target="cancelado2">Cancelado</button>
                                    <button type="button" class="btn btn-default btn-filter" data-target="all">Todos</button>
                                </div>
                            </div>
                            <div class="table-container">
                                <table class="table table-filter">
                                    <tbody>
                                        <asp:Repeater ID="Repeater4" DataSourceID="SqlDataSource4" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pagado2">

                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title">Solicitação de Nova Categoria 
													
                                                            <span class="pull-right pagado">(Aprovado)</span>
                                                                </h4>
                                                                <p class="summary">Solicitação da Nova Categoria: <%# Eval("descricao") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater5" DataSourceID="SqlDataSource5" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pendiente2">
                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title"> Solicitação de Nova Categoria 
													
                                                            <span class="pull-right pendiente">(Pendente)</span>
                                                                </h4>
                                                                <p class="summary">Solicitação da Nova Categoria: <%# Eval("descricao") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater6" DataSourceID="SqlDataSource6" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="cancelado2">


                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title">Solicitação de Nova Categoria 
													
                                                            <span class="pull-right cancelado">(Cancelado)</span>
                                                                </h4>
                                                                <p class="summary">Solicitação da Nova Categoria: <%# Eval("descricao") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    
                    </div>
                </div>
            </section>

            <section id="denuncia_post_sec" runat="server" style="display:none;" class="content justify-content-center">
         
                <div class="col-md-8 col-md-offset-2">
                    <div style="width: 900px;" class="panel panel-default">
                        <div class="panel-body">
                             <div style="margin-top:30px; margin-bottom:-55px; margin-left:10px;">
                               
                            <h3>Denuncias de Postagem</h3>
                                </div>
                            <div class="pull-right">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-success btn-filter" data-target="pagado">Aprovado</button>
                                    <button type="button" class="btn btn-warning btn-filter" data-target="pendiente">Em Análise</button>
                                    <button type="button" class="btn btn-danger btn-filter" data-target="cancelado">Cancelado</button>
                                    <button type="button" class="btn btn-default btn-filter" data-target="all">Todos</button>
                                </div>
                            </div>
                            <div class="table-container">
                                <table class="table table-filter">
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" DataSourceID="SqlDataSource1" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pagado">

                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title">Postagem de <%# Eval("postagem_dono") %> denunciada
													
                                                            <span class="pull-right pagado">(Aprovado)</span>
                                                                </h4>
                                                                <p class="summary"><%# Eval("motivo_denuncia") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater2" DataSourceID="SqlDataSource2" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="pendiente">
                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title"> Postagem de <%# Eval("postagem_dono") %> denunciada
													
                                                            <span class="pull-right pendiente">(Pendente)</span>
                                                                </h4>
                                                                <p class="summary"><%# Eval("motivo_denuncia") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <asp:Repeater ID="Repeater3" DataSourceID="SqlDataSource3" runat="server">
                                            <ItemTemplate>
                                                <tr data-status="cancelado">


                                                    <td>
                                                        <div class="media">
                                                            <a href="#" class="pull-left">
                                                                <img src="https://s3.amazonaws.com/uifaces/faces/twitter/fffabs/128.jpg" class="media-photo">
                                                            </a>
                                                            <div class="media-body">
                                                                
                                                                <h4 class="title">Postagem de <%# Eval("postagem_dono") %> denunciada
													
                                                            <span class="pull-right cancelado">(Cancelado)</span>
                                                                </h4>
                                                                <p class="summary"<%# Eval("motivo_denuncia") %></p>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </section>

        </div>
    </div>
</asp:Content>
