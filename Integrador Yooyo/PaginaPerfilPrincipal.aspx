<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaterTeste.Master" AutoEventWireup="true" CodeBehind="PaginaPerfilPrincipal.aspx.cs" Inherits="Integrador_Yooyo.PaginaPerfilPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script type="text/javascript" src="test.js"></script>
    <style>
        body {
            background: #F1F3FA;
        }

        /* Profile container */
        .profile {
            margin: 20px 0;
        }

        /* Profile sidebar */
        .profile-sidebar {
            padding: 20px 0 10px 0;
            background: #fff;
        }

        .profile-userpic img {
            float: none;
            margin: 0 auto;
            width: 50%;
            height: 50%;
            -webkit-border-radius: 50% !important;
            -moz-border-radius: 50% !important;
            border-radius: 50% !important;
        }

        .profile-usertitle {
            text-align: center;
            margin-top: 20px;
        }

        .profile-usertitle-name {
            color: #5a7391;
            font-size: 16px;
            font-weight: 600;
            margin-bottom: 7px;
        }

        .profile-usertitle-job {
            text-transform: uppercase;
            color: #5b9bd1;
            font-size: 12px;
            font-weight: 600;
            margin-bottom: 15px;
        }

        .profile-userbuttons {
            text-align: center;
            margin-top: 10px;
        }

            .profile-userbuttons .btn {
                text-transform: uppercase;
                font-size: 11px;
                font-weight: 600;
                padding: 6px 15px;
                margin-right: 5px;
            }

                .profile-userbuttons .btn:last-child {
                    margin-right: 0px;
                }

        .profile-usermenu {
            margin-top: 30px;
        }

            .profile-usermenu ul li {
                border-bottom: 1px solid #f0f4f7;
            }

                .profile-usermenu ul li:last-child {
                    border-bottom: none;
                }

                .profile-usermenu ul li a {
                    color: #93a3b5;
                    font-size: 14px;
                    font-weight: 400;
                }

                    .profile-usermenu ul li a i {
                        margin-right: 8px;
                        font-size: 14px;
                    }

                    .profile-usermenu ul li a:hover {
                        background-color: #fafcfd;
                        color: #5b9bd1;
                    }

                .profile-usermenu ul li.active {
                    border-bottom: none;
                }

                    .profile-usermenu ul li.active a {
                        color: #5b9bd1;
                        background-color: #f6f9fb;
                        border-left: 2px solid #5b9bd1;
                        margin-left: -2px;
                    }

        /* Profile Content */
        .profile-content {
            padding: 20px;
            background: #fff;
            min-height: 460px;
        }
    </style>
    <script>
        function reply_click(e) {
            alert("teste")
            console.log("teste")
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div class="modal" id="ModalEdit">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">Editando Perfil</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        
        <!-- Modal body -->
        <div class="modal-body">
            <asp:TextBox ID="EditNomeTXT" class="input-group-text" placeholder="Nome" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="EditEmailTXT" class="input-group-text" placeholder="Email" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="EditRecadoTXT" class="input-group-text" placeholder="Recado" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnconfirmaedit" Width="200px" class="btn btn-success" OnClick="btnconfirmaedit_Click" runat="server" Text="Confirmar Edição"  />
           
            <asp:Button ID="btncancelaedit" Width="200px"  class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
        </div>
        
      </div>
    </div>
  </div>
    <div class="container">
        <div class="row profile">
            <div class="col-md-3">
                <div class="profile-sidebar">
                    <!-- SIDEBAR USERPIC -->
                    <div class="profile-userpic d-flex justify-content-center">
                        <img id="image_perfil" runat="server" class="img-responsive" alt="">
                    </div>
                    <!-- END SIDEBAR USERPIC -->
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <asp:Label ID="labelLogin" runat="server"></asp:Label>

                        </div>
                        <div class="profile-usertitle-job">
                            <asp:Label ID="labelNome" runat="server"></asp:Label>

                        </div>
                    </div>

                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR BUTTONS -->
                    <div class="profile-userbuttons">
                        <asp:Button ID="btnEditar" data-toggle="modal" data-target="#ModalEdit" OnClientClick="return false;" class="btn btn-success btn-sm" runat="server" Text="Editar Perfil" />


                    </div>
                    <!-- END SIDEBAR BUTTONS -->
                    <!-- SIDEBAR MENU -->
                    <div class="profile-usermenu">
                        <div class="container">

                            <div class="list-group">
                                <asp:Button ID="btnRecado" OnClick="btnRecado_Click" class="list-group-item list-group-item-action list-group-item-primary" runat="server" Text="Recado" />
                                <asp:Button ID="btnEmail" OnClick="btnEmail_Click" class="list-group-item list-group-item-action list-group-item-primary" runat="server" Text="E-mail" />


                            </div>
                        </div>

                    </div>
                    <!-- END MENU -->
                </div>

                <div style="background-color: white; margin-top: 5px;">
                    <asp:Label ID="labelTexto" runat="server"></asp:Label>
                </div>
            </div>

            <div class="col-md-9">
                <div class="profile-content" style="width: 1000px;">
                    <asp:Repeater ID="repeater1" runat="server" OnItemCommand="EditarPosta_ItemCommand" DataSourceID="SqlDataSource1">
                        <ItemTemplate>
                            <div class="modal" id="myModal2">
                                <div class="modal-dialog">
                                    <div class="modal-content">

                                        <!-- Modal Header -->
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title">Edição de postagem</h4>
                                            </div>
                                            <div class="modal-body">

                                                <%-- TextBox de Ediçao do titulo --%>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("titulo")%>'></asp:TextBox>

                                                <%-- TextBox de Ediçao da avaliação_dvantagem --%>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("avaliacao_vantagem")%>' Visible="True"></asp:TextBox>

                                                <%-- TextBox de Ediçao da avaliação_desvantagem --%>
                                                <asp:TextBox ID="TextBox6" runat="server" data="editDesVanta" Text='<%#Eval("avaliacao_desvantagem")%>'></asp:TextBox>

                                                <asp:Button ID="Button1" runat="server" CommandName="Salvar" Text="Salvar" />
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 950px;" class="container mt-3 card">
                                <div class="">
                                    <%-- Dono da postagem --%>
                                    <a href="PaginaPerfilVisita.aspx?user=<%#Eval("login") %>">
                                        <h4 id="loginTXT" runat="server" style="border: none; background-color: white; color: purple; font-size: medium; cursor: pointer"><%# Eval("login") %></h4>
                                    </a>
                                    <h2 style="width: 300px;" id="tituloH2" runat="server" visible="True"><%#Eval("titulo")%></h2>


                                    <!--Botões de opcões na postagem-->
                                    <div style="margin-top: -45px;" class="d-flex justify-content-end">
                                        <div class="toast">
                                            <div class="toast-header">
                                                Toast Header
                                            </div>
                                            <div class="toast-body">
                                                Some text inside the toast body
                                            </div>
                                        </div>
                                        <div id="dropdownOP2" class="dropdown">
                                            <button style="font-size: 14px; margin-right: 20px;" class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            </button>
                                            <ul class="dropdown-menu" id="dropdown" aria-labelledby="dropdownMenuButton">
                                                <li>
                                                    <%-- Botão Editar --%>
                                                    <asp:Button Width="160px" runat="server" ID="Button2" CommandArgument='<%# Eval("postagem_id") %>' CommandName="Editar" class="btn btn-light" Text="Editar" />
                                                </li>
                                                <li>
                                                    <%-- Botão Exuclir --%>
                                                    <asp:Button Width="160px" OnClientClick="return confirm('Deseja Realmente Excluir Esta Postagem?')" CssClass="btn btn-light" ID="Button3" runat="server" Text="Excluir" CommandArgument='<%# Eval("postagem_id") %>' OnClick="Button3_Click" />
                                                </li>
                                            </ul>

                                        </div>
                                    </div>
                                </div>
                                <br>
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs">
                                    <li class="nav-item">
                                        <a id="<%#Eval("postagem_id") %>" class="nav-link active" data-toggle="tab" href="#van<%#Eval("postagem_id") %>">Vantagem</a>
                                    </li>
                                    <li class="nav-item">
                                        <a id="btnDesvantagem" class="nav-link" data-toggle="tab" href="#des<%# Eval("postagem_id") %>">Desvantagem</a>
                                    </li>
                                </ul>
                                <asp:Button ID="Button4" Visible="false" runat="server" Text="Salvar" />

                                <asp:HiddenField runat="server" ID="HfieldID" Value='<%# Eval("postagem_id")%>' />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT * FROM [comentario] WHERE [postagem_id] = @postagem_id">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="postagem_id" PropertyName="Value" ControlID="HfieldID" DbType="String" />

                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <!-- Tab panes -->

                                <div class="tab-content card" style="width: 400px;">
                                    <div id="van<%# Eval("postagem_id") %>" class="container tab-pane active">
                                        <br>

                                        <p><%# Eval("avaliacao_vantagem") %></p>
                                    </div>
                                    <div id="des<%# Eval("postagem_id") %>" class="container tab-pane fade">
                                        <br>
                                        <p><%# Eval("avaliacao_desvantagem") %></p>
                                    </div>
                                </div>

                                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT * FROM tblImages as tbl WHERE postagem_id = @postagemid">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="postagemid" PropertyName="Value" ControlID="HfieldID" DbType="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <section class="awSlider d-flex justify-content-end">
                                    <div id="carro<%# Eval("postagem_id") %>" class="carousel slide carousel-fade" data-ride="carousel">
                                        <div class="carousel-inner" style="width: 500px;">
                                            <div class="carousel-item active">
                                                <img src="Imagem/Yoyoo B.png" alt="Chicago" width="500px" height="350px">
                                            </div>

                                            <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource5">
                                                <ItemTemplate>

                                                    <div runat="server" id="divIMGID" class="carousel-item">

                                                        <img src='<%# getimage(Eval("postagem_id"), Eval("imagedata")) %>' alt="Chicago" width="500pxpx" height="350px" style="margin-right: 10px;">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <a class="carousel-control-prev" style="background-color: lightgray;" href="#carro<%# Eval("postagem_id") %>" role="button" data-slide="prev">
                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                            <span class="sr-only">Anterior</span>
                                        </a>
                                        <a class="carousel-control-next" style="background-color: lightgray;" href="#carro<%# Eval("postagem_id") %>" role="button" data-slide="next">
                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                            <span class="sr-only">Próximo</span>
                                        </a>
                                    </div>

                                </section>



                                <!--Media -->

                                <!--Repeater de Comentário(repetindo os mesmos comentários para todas as postagens) -->
                                <p style="border-bottom: 1px solid #eee;">Comentários</p>

                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT * FROM comentario WHERE postagem_id = @postagemid">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="postagemid" PropertyName="Value" ControlID="HfieldID" DbType="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>

                               <asp:TextBox ID="comentarTXT" MaxLength="50" placeholder="Comentar" class="form-control border-success text-success " runat="server" Width="509px"></asp:TextBox>
                <asp:Button ID="btncomentar" runat="server" Width="100px" Text="Comentar" CommandName="Comentar" CommandArgument='<%#Eval("postagem_id")  %>' class="btn btn-success ml-sm-auto mr-auto" style="margin-top:-38px !important; margin-left:56% !important;" />

                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource6">


                    <ItemTemplate>

                        <table style="border: none;">
                            <tr>
                                <td style="width: 200px">
                                    <table style="border: none;">
                                        <tr>

                                            <td>
                                                <asp:Label Font-Size="15.7px" Font-Bold="true" ID="lblName"
                                                    runat="server"
                                                    Text='<%#Eval("login") %>'>
                                                </asp:Label>
                                                <asp:Label Font-Size="11px" ID="Label1"
                                                    runat="server"
                                                    Text='<%#Eval("data_hora") %>'>
                                                </asp:Label>
                                            </td>
                                        </tr>


                                        <tr>

                                            <td>
                                                <div style="margin-left: 6px;">
                                                    <asp:Label Font-Size="14.5px" ID="lblGender"
                                                        runat="server"
                                                        Text='<%#Eval("descricao") %>'>
                                                    </asp:Label>
                                                </div>
                                            </td>
                                            <Div style="margin-left:30% !important;">
                                            <td>
                                                <asp:LinkButton ID="Button1" class="btn btn-danger fa fa-trash" OnClick="Button1_Click" OnClientClick="return confirm('Deseja Realmente Excluir este comentário?')" CommandArgument='<%# Eval("comentario_id") %>' Visible='<%# String.Equals(Session["login"], Eval("login"))%>' runat="server"></asp:LinkButton>
                                               
                                            </td>
                                            </Div>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />

                    </ItemTemplate>
                </asp:Repeater>

                                <!--Botões-->




                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="width: 900px;" class="alert alert-warning ml-lg-auto mr-lg-auto">
                        <div class="justify-content-lg-center">
                            <strong>Atenção!</strong> Este Usuário não possui mais Publicações
                        </div>
                    </div>

                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from Postagem as us WHERE us.login = @login order by data_hora desc">

                        <SelectParameters>
                            <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
