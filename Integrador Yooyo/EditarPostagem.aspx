<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaterTeste.Master" AutoEventWireup="true" CodeBehind="EditarPostagem.aspx.cs" Inherits="Integrador_Yooyo.EditarPostagem" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
   

    


    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
    <script>


        function star(x) {


            x.src = "/Imagem/star_full.png";

        }

        function starQ(x) {
            x.src = "/Imagem/star 1.png";

        }
        function ConfirmaExclusao() {
            return confirm('Deseja realmente denunciar esta postagem?'), false;
        }
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
       

        <!-- The Modal -->
       
       

   



<asp:Repeater ID="ReEdit" OnItemCommand="ReEdit_ItemCommand" EnableViewState="false" runat="server">
        <ItemTemplate>

            <div style="width: 950px;" class="container mt-3 card">
                <div class="">
                    <%-- Dono da postagem --%>
                    <a href="PaginaPerfilVisita.aspx?user=<%#Eval("login") %>">
                        <h4 id="loginTXT" runat="server" style="border: none; background-color: white; color: purple; font-size: medium; cursor: pointer"><%# Eval("login") %></h4>
                    </a>
                    <h4>Editar Título</h4><br />
                    <%-- TextBox de Ediçao do titulo --%>
                    <asp:TextBox ID="TextBox1"  class="form-control"  runat="server" Text='<%#Eval("titulo")%>'></asp:TextBox>       
                <br>
               
                <asp:HiddenField runat="server" ID="HfieldID" Value='<%# Eval("postagem_id")%>' />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT * FROM [comentario] WHERE [postagem_id] = @postagem_id">
                    <SelectParameters>
                        <asp:ControlParameter Name="postagem_id" PropertyName="Value" ControlID="HfieldID" DbType="String" />

                    </SelectParameters>
                </asp:SqlDataSource>
                <!-- Tab panes -->

                <%-- TextBox de Ediçao da avaliação_vantagem --%>
                      <h4>Editar Vantagem</h4><br />
                <asp:TextBox ID="TextBox2" class="form-control"  runat="server"  Text='<%#Eval("avaliacao_vantagem")%>'></asp:TextBox>
                  <h4>Editar Desvantagem</h4><br />
                <%-- TextBox de Ediçao da avaliação_desvantagem --%>
                <asp:TextBox ID="TextBox3"  class="form-control"  runat="server"  Text='<%#Eval("avaliacao_desvantagem")%>'></asp:TextBox><br />

                <asp:LinkButton ID="Button5" runat="server" class="btn btn-success" CommandName="Salvar" CommandArgument='<%# Eval("postagem_id") %>'  Text="Salvar" />                        
            <asp:Button ID="Button1" runat="server" class="btn btn-danger" PostBackUrl="~/PaginaPerfilPrincipal.aspx"  Text="Cancelar Edição"/>    
        </ItemTemplate>

    </asp:Repeater>


    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Postagem_visita %>' SelectCommand="select * from Postagem"></asp:SqlDataSource>
</asp:Content>
