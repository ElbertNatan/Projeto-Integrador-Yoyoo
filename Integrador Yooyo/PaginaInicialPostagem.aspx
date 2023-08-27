<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaterTeste.Master" AutoEventWireup="true" CodeBehind="PaginaInicialPostagem.aspx.cs" Inherits="Integrador_Yooyo.PaginaInicialPostagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <script src="https://code.jquery.com/jquery-3.4.1.js"></script>
    <script>


        function star(x) {


            x.src = "/Imagem/star_full.png";

        }

        function starQ(x) {
            x.src = "/Imagem/star 1.png";

        }

        $(document).ready(function () {
            $("#btn_denunciar").click(function () {
                $('.toast').toast('show');
            });
        });

        function display(obj) {
            //Faz o titulo, no H2, a avaliação_vantagem e avaliação_desvantagem,nos TextBoxs, sumirem para darem lugar aos de Edição logo abaixo
            $(obj).parent().parent().parent().parent().parent().children('h2').toggleClass('d-none');
            $(obj).parent().parent().parent().parent().parent().children('.container tab-pane active').toggleClass('d-none');

            //Faz as TextBoxs de Edição aparecer
            $(obj).parent().parent().parent().parent().parent().children('input[ data="editTitu"]').toggleClass('d-none');
            $(obj).parent().parent().parent().parent().parent().children('input[ data="editAvaVanta"]').toggleClass('d-none');
            $(obj).parent().parent().parent().parent().parent().children('input[ data="editDesVanta"]').toggleClass('d-none');
            $(obj).parent().parent().parent().parent().parent().children('input[ data="SalveEdicao"]').toggleClass('d-none');

        }

        $('section.awSlider .carousel').carousel({
            pause: "hover",
            interval: 2000
        });

        var startImage = $('section.awSlider .item.active > img').attr('src');
        $('section.awSlider').append('<img src="' + startImage + '">');

        $('section.awSlider .carousel').on('slid.bs.carousel', function () {
            var bscn = $(this).find('.item.active > img').attr('src');
            $('section.awSlider > img').attr('src', bscn);
        });

        function ConfirmaExclusao() {
            return confirm('Deseja realmente denunciar esta postagem?');
        }


    </script>
    <style>
        section.awSlider .carousel {
            display: table;
            z-index: 2;
            -moz-box-shadow: 0 0 4px #444;
            -webkit-box-shadow: 0 0 4px #444;
            box-shadow: 0 0 15px rgba(1,1,1,.5);
        }

        section.awSlider {
            top: -49px;
            position: relative;
            display: table;
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            section.awSlider:hover > img {
                -ms-transform: scale(1.2);
                -webkit-transform: scale(1.2);
                transform: scale(1.2);
                opacity: 1;
            }

            section.awSlider img {
                pointer-events: none;
            }

            section.awSlider > img {
                position: absolute;
                top: 30px;
                z-index: 1;
                transition: all .3s;
                filter: blur(1.8vw);
                -webkit-filter: blur(2vw);
                -moz-filter: blur(2vw);
                -o-filter: blur(2vw);
                -ms-filter: blur(2vw);
                -ms-transform: scale(1.1);
                -webkit-transform: scale(1.1);
                transform: scale(1.1);
                opacity: .5;
            }

        #FileUpload1 input {
            width: 1px;
        }

        .btn-primary {
            background-color: #4A77FF;
        }

            .btn-primary:hover {
                background-color: #3F0259;
            }

        #dropdownOP {
        }

        #vantagemTXT {
            resize: none;
        }

        #desvantagemTXT {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="body">



    <div class="container d-flex justify-content-center">

        <!-- Button to Open the Modal -->
        <button type="button" style="margin-top:20px !important;" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
            Criar Publicação
        </button>

        <!-- The Modal -->
        <div class="modal" id="myModal">
            <div class="modal-dialog modal-lg">
                <div class="modal-content d-flex justify-content-lg-start">

                    <!-- Modal Header -->
                    <div class="modal-header" >
                        <h2 class="modal-title">Nova Publicação</h2>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>

                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">

                        <div id="posti" runat="server">


                            <asp:TextBox ID="tituloTXT" MaxLength="50" placeholder="Título" class="form-control border-success text-success" runat="server" Width="664px"></asp:TextBox>
                            <asp:FileUpload class="btn btn-info" ID="FileUpload1" runat="server" AllowMultiple="True" EnableViewState="True" ClientIDMode="Inherit" />


                            <br />
                            <!--Vantagem da Publicação-->
                            <!--Desvantagem da Publicação-->

                            <asp:TextBox Style="resize: none;" ID="vantagemTXT" class="form-control border-success text-success d-flex d-inline-flex" MaxLength="500" placeholder="Vantagens" runat="server" TextMode="MultiLine" Height="100px" Width="577px"></asp:TextBox>
                            <asp:TextBox Style="resize: none;" ID="desvantagemTXT" class="form-control border-success text-success" MaxLength="500" placeholder="Desvantagens" runat="server" TextMode="MultiLine" Height="100px" Width="577px"></asp:TextBox>

                            <!--Selecionar imagens-->
                            <h3>Selecionar Categoria</h3>
                            <br />
                            <asp:ListBox Width="400px" Height="200px" ID="ListboxCategoria" class="custom-control-label" runat="server" DataSourceID="SqlDataSource4" DataTextField="descricao" DataValueField="descricao"></asp:ListBox>


                            <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:Ver_Categorias %>' SelectCommand="SELECT distinct([descricao]) FROM [Categoria] order by [descricao] asc"></asp:SqlDataSource>
                            <div>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Ver_Categorias %>" SelectCommand="SELECT [descricao] FROM [Categoria]"></asp:SqlDataSource>
                                <br />
                                <asp:Button class="btn btn-success" ID="Postar" OnClick="Postar_Click" runat="server" Text="Postar Publicação" /><br />
                                <asp:Label ID="Label1" Visible="false" CssClass="red" runat="server" Text="Label">Por favor Preencha as caixas de texto e selecione uma categoria(somente "Escolher arquivos" pode ser vazio).</asp:Label>
                                <br />
                                <br />

                                <!--Selecionar categoria-->
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString4 %>" SelectCommand="SELECT [descricao] FROM [Categoria]"></asp:SqlDataSource>
                            </div>

                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                    </div>

                </div>
            </div>
        </div>

    </div>



    <asp:Repeater ID="repeater1" OnItemCommand="Repeater1_ItemCommand" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>

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
                                    <%-- Botão Denunciar --%>
                                    <asp:Button Width="160px" class="btn btn-light" ID="btn_denunciar" OnClientClick="return confirm('Deseja Realmente denunciar a postagem?');" runat="server" CommandArgument='<%# Eval("postagem_id") + ";" + Eval("login") %>' Text="Denunciar" OnClick="denuncia_click" />
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
                            <div id="estrela">
                            </div>

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
                <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="select AVG(nota) as nota from avaliacao_postagem as ava where ava.postagem_id = @postagemid">
                    <SelectParameters>
                        <asp:ControlParameter Name="postagemid" PropertyName="Value" ControlID="HfieldID" DbType="String" />
                    </SelectParameters>
                </asp:SqlDataSource> 


                <asp:Repeater runat="server" DataSourceID="SqlData">
                    <ItemTemplate>
                        <div class="d-inline-flex ml-auto">
                            <h5 style="margin-right: 22px;">Média Geral: </h5>
                            <h5 style="margin-right: 20px;"><%# Eval("nota") %></h5>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


                <div id="starsdiv" class="d-inline-flex ml-auto">
                    <asp:ImageButton ID="ImageButton1" Width="50px" Height="50px" class="primeiro" runat="server" ImageUrl="~/Imagem/star 1.png" OnClick="ImageButton1_Click" CommandArgument='<%# Eval("postagem_id") %>' onmouseover="star(this)" onmouseout="starQ(this)" />
                    <asp:ImageButton ID="ImageButton2" Width="50px" Height="50px" CssClass="teste" runat="server" ImageUrl="~/Imagem/star 1.png" OnClick="ImageButton2_Click" CommandArgument='<%# Eval("postagem_id") %>' onmouseover="star(this)" onmouseout="starQ(this)" />
                    <asp:ImageButton ID="ImageButton3" Width="50px" Height="50px" CssClass="teste" runat="server" ImageUrl="~/Imagem/star 1.png" OnClick="ImageButton3_Click" CommandArgument='<%# Eval("postagem_id") %>' onmouseover="star(this)" onmouseout="starQ(this)" />
                    <asp:ImageButton ID="ImageButton4" Width="50px" Height="50px" CssClass="teste" runat="server" ImageUrl="~/Imagem/star 1.png" OnClick="ImageButton4_Click" CommandArgument='<%# Eval("postagem_id") %>' onmouseover="star(this)" onmouseout="starQ(this)" />
                    <asp:ImageButton ID="ImageButton5" Width="50px" Height="50px" CssClass="teste" runat="server" ImageUrl="~/Imagem/star 1.png" OnClick="ImageButton5_Click" CommandArgument='<%# Eval("postagem_id") %>' onmouseover="star(this)" onmouseout="starQ(this)" />
                </div>
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
            <strong>Atenção!</strong> Não Existem mais Publicações, Se Possível Adicione Mais Usuários
        </div>
    </div>

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from Postagem as us WHERE us.login IN(Select(seguido) FROM usuarioSeguir as se WHERE se.login = @login) AND us.login != 'Admin' AND us.login != @login order by data_hora desc">

        <SelectParameters>
            <asp:SessionParameter SessionField="login" Name="login"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

