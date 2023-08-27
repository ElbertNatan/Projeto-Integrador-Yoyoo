<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PaginaAdminNew.aspx.cs" Inherits="Integrador_Yooyo.PaginaAdminNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <script>
        function myFunction() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableDENUNPOST");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
        function myFunction2() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput2");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableDENUUSER");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

        function myFunction3() {
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("myInput3");
            filter = input.value.toUpperCase();
            table = document.getElementById("tableBanidos");
            tr = table.getElementsByTagName("tr");
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
        function openModal() {
            $('#ModalCriaCategoria').modal({ show: true });
        }
    </script>

    <style>
        #myInput {
            background-position: 10px 10px;
            background-repeat: no-repeat;
            width: 100%;
            font-size: 16px;
            padding: 12px 20px 12px 40px;
            border: 1px solid #ddd;
            margin-bottom: 12px;
        }

        #user .avatar {
            width: 60px;
        }

            #user .avatar > img {
                width: 50px;
                height: 50px;
                border-radius: 10%;
            }
        /*Card*/
        #user .panel-thumb {
            margin: 5px auto;
            text-align: center;
        }

            #user .panel-thumb .avatar-card {
                text-align: center;
                height: 200px;
                margin: auto;
                overflow: hidden;
            }

                #user .panel-thumb .avatar-card > img {
                    max-width: 200px;
                    max-height: 200px;
                }

        /* table*/
        #user .panel-table {
            animation-duration: 3s;
        }

            #user .panel-table .panel-body .table {
                margin: 0px;
            }

            #user .panel-table .panel-body {
                padding: 0px;
            }

                #user .panel-table .panel-body .table-bordered > thead > tr > th {
                    text-align: center;
                }

            #user .panel-table .panel-footer {
                height: 60px;
                padding: 0px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootswatch/3.3.6/lumen/bootstrap.min.css">
    <link rel="stylesheet" href="https://daneden.github.io/animate.css/animate.min.css">
    <script typeof="javascript">
        function filter($state) {
            var x = document.getElementsByClassName($state);
            var btn = document.getElementById($state);

            if (btn.className == "btn") {
                btn.className = btn.dataset.class;
                for (i = 0; i < x.length; i++) { x[i].className = " animated fadeInLeft " + $state; }
            }
            else {
                for (i = 0; i < x.length; i++) { x[i].className = " animated fadeOutRight " + $state; }
                btn.className = "btn";
            }

        }
    </script>
    <div class="container" style="margin-top: 60px;">
        <asp:Button runat="server" class="btn btn-primary" Text="Ver Denuncias de postagens" OnClick="btnshowpostdenun_Click" ID="btnshowpostdenun" />
        <asp:Button runat="server" class="btn btn-primary" Text="Ver Denuncias de Usuários" OnClick="btnshowuserdenun_Click" ID="btnshowuserdenun" />
        <asp:Button runat="server" class="btn btn-warning" Text="Usuários Banidos" ID="btnbanidos" OnClick="btnbanidos_Click" />
        <asp:Button runat="server" class="btn btn-success" data-toggle="modal" OnClientClick="return false;" data-target="#ModalCriaCategoria" Text="Categorias" ID="btncriacat" />
        <asp:Button runat="server" class="btn btn-primary" OnClick="btnshowsolicita_Click" Text="Ver Solicitações de Categorias" ID="btnshowsolicita" />
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString %>' SelectCommand="select * from postagem where postagem_id IN (select distinct(postagem_id) from denuncia_postagem where status = 'pendente')"></asp:SqlDataSource>
       
        

        <div class="modal" style="z-index: 100000;" id="modalCria_categoria">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Criando Categoria</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <asp:TextBox ID="CriaCatTXT" placeholder="Sub-Categoria" runat="server"></asp:TextBox><br />
                        <strong>Categoria</strong><br />
                        <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource8" DataTextField="sub_categoria" DataValueField="sub_categoria"></asp:ListBox><br />
                        <asp:Button ID="btncriacat2" class="btn btn-success" OnClick="btncriacat_Click" runat="server" Text="Criar" />
                        <asp:Button ID="CancelCat" class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />
                        <asp:SqlDataSource runat="server" ID="SqlDataSource8" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString3 %>' SelectCommand="SELECT DISTINCT(sub_categoria) FROM categoria"></asp:SqlDataSource>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                    </div>

                </div>
            </div>
        </div>
        <div class="modal" style="z-index: 100000;" id="modalatt_categoria">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Atualizando Categoria</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <asp:TextBox ID="attCatTXT" placeholder="Sub-Categoria" runat="server"></asp:TextBox><br />
                        <strong>Categoria</strong><br />
                        <asp:ListBox ID="ListBox3" runat="server" DataSourceID="sqlselectcat" DataTextField="descricao" DataValueField="categoria_id"></asp:ListBox><br />
                        <asp:Button ID="btnAttCat" class="btn btn-success" OnClick="btnAttCat_Click" runat="server" Text="Atualizar" />
                        <asp:Button ID="Button2" class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            Fechar
                        </button>
                    </div>

                </div>
            </div>
        </div>
        
        <div style="margin-top: 10px;">
            <div class="modal" id="ModalCriaCategoria" style="z-index: 10000;">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Opções de Categoria</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <asp:Button ID="btnInsertCat" data-toggle="modal" OnClientClick="return false;" data-target="#modalCria_categoria" class="btn btn-info" Width="200px" runat="server" Text="Criar Nova Categoria" /><br />
                            <br />
                            <asp:Button ID="btnUpdateCat" data-toggle="modal" OnClientClick="return false;" data-target="#modalatt_categoria" class="btn btn-info" Width="200px" runat="server" Text="Atualizar Categorias" /><br />
                            <br />
                            <asp:Button ID="btnDeleteCat" OnClick="btnDeleteCat_Click" OnClientClick="return confirm('Deseja Realmente Excluir essa Categoria Permanentemente?')" class="btn btn-info" Width="200px" runat="server" Text="Excluir Categorias" /><br />
                            <br />
                            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="sqlselectcat" DataTextField="descricao" DataValueField="categoria_id"></asp:ListBox>
                            <asp:SqlDataSource runat="server" ID="sqlselectcat" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString3 %>' SelectCommand="SELECT * FROM categoria"></asp:SqlDataSource>
                            <br />
                            <br />

                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-target="ModalCriaCategoria" data-dismiss="modal">Fechar</button>
                        </div>

                    </div>
                </div>


            </div>
            <div id="divdepos" runat="server" style="display: none;">
                <div class="row">
                    <div id="user" class="col-md-12">
                        <div class="panel panel-primary panel-table animated slideInDown">
                            <div class="panel-heading " style="padding: 5px;">
                                <div class="row">

                                    <div class="col col-xs-5 text-center">
                                        <h1 class="panel-title">Lista de Denúncias de Postagem</h1>
                                    </div>

                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="list">
                                        <table id="tableDENUNPOST" class="table table-striped table-bordered table-list">
                                            <thead>
                                                <tr>
                                                    <th class="avatar">Foto</th>
                                                    <th>Dono da Postagem</th>
                                                    <th>Requisitante</th>
                                                    <th>ID da Postagem</th>
                                                    <th><em class="fa fa-cog"></em></th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString %>' SelectCommand="select * from denuncia_postagem where [status] = 'pendente' AND [postagem_id] != '-1'"></asp:SqlDataSource>

                                                <input type="text" id="myInput" class="form-control" onkeyup="myFunction()" placeholder="Procurar denunciados" title="Type in a name"></input>
                                                <asp:Repeater ID="Repeater1" DataSourceID="SqlDataSource1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="ok">
                                                            <td class="avatar">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg"></td>
                                                            <td><%# Eval("postagem_dono") %></td>
                                                            <td><%# Eval("login") %></td>
                                                            <td><%# Eval("postagem_id") %></td>
                                                            <td align="center">
                                                                <button type="button" title="ver postagem" class="btn btn-primary" style="" data-toggle="modal" data-target='#mod<%# Eval("postagem_id") %>'><i class="fa fa-newspaper-o"></i></button>

                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Excluir a Postagem?')" CommandArgument='<%# Eval("postagem_id") %>' ID="btnexcluirpost" OnClick="btnexcluirpost_Click" runat="server" title="excluir postagem" class="btn btn-warning"><i title="excluir postagem" class="fa fa-ban"></i>&nbsp;</asp:LinkButton>
                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Excluir a Solicitação?')" CommandArgument='<%# Eval("denuncia_postagem_id") %>' ID="btnexcluirsol" OnClick="btnexcluirsol_Click" title="exluir solicitação" runat="server" class="btn btn-danger"><i title="exluir solicitação" class="fa fa-trash"></i>&nbsp;</asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>


                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- END id="list" -->

                                    <div role="tabpanel" class="tab-pane " id="thumb">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="ok">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Djelal Eddine</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="ban">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Moh Aymen</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3511252200/f97a40336742d17609e0b0ca17e301b8_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban">admitted</i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="new">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Dia ElHak</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3023221270/fcb34337f850c1037af9840ebe510d36_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-success" title="validate"><i class="fa fa-check-square">validate</i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- END id="thumb" -->

                                </div>
                                <!-- END tab-content -->
                            </div>


                        </div>
                        <!--END panel-table-->
                    </div>
                </div>
            </div>

            <div id="divdeuser" runat="server" style="display: none;">
                <div class="row" id="divdenunciauser" style="width: 1140px;">
                    <div id="user" class="col-md-12">
                        <div class="panel panel-primary panel-table animated slideInDown">
                            <div class="panel-heading " style="padding: 5px;">
                                <div class="row">

                                    <div class="col col-xs-5 text-center">
                                        <h1 class="panel-title">Lista de Denúncias de Usuário</h1>
                                    </div>

                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="list">
                                        <table id="tableDENUUSER" class="table table-striped table-bordered table-list">
                                            <thead>
                                                <tr>
                                                    <th class="avatar">Foto</th>
                                                    <th>Denunciado</th>
                                                    <th>Requisitante</th>
                                                    <th>Motivo da Denúncia</th>
                                                    <th><em class="fa fa-cog"></em></th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString %>' SelectCommand="select * from denuncia_usuario where [status] = 'pendente'"></asp:SqlDataSource>
                                                <input type="text" id="myInput2" class="form-control" onkeyup="myFunction2()" placeholder="Procurar denunciados" title="Type in a name"></input>
                                                <asp:Repeater ID="Repeater4" DataSourceID="SqlDataSource3" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="ok">
                                                            <td class="avatar">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg"></td>
                                                            <td><%# Eval("denunciado") %></td>
                                                            <td><%# Eval("login") %></td>
                                                            <td><%# Eval("motivo_denuncia") %></td>
                                                            <td align="center">
                                                                <a href='PaginaPerfilVisita.aspx?user=<%# Eval("denunciado") %>'>
                                                                    <button type="button" title="ver Perfil" class="btn btn-primary" style=""><i class="fa fa-address-card"></i></button>
                                                                </a>

                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Banir o Usuário?')" CommandArgument='<%# Eval("denunciado") + ";" + Eval("denuncia_usuario_id")%>' ID="btnbaniruser" OnClick="btnbaniruser_Click" runat="server" title="Banir Usuário" class="btn btn-warning"><i title="excluir postagem" class="fa fa-ban"></i>&nbsp;</asp:LinkButton>
                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Excluir a Solicitação?')" CommandArgument='<%# Eval("denuncia_usuario_id") %>' ID="btnexcluirdenunuser" OnClick="btnexcluirdenunuser_Click" title="exluir solicitação" runat="server" class="btn btn-danger"><i title="exluir solicitação" class="fa fa-trash"></i>&nbsp;</asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>


                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- END id="list" -->

                                    <div role="tabpanel" class="tab-pane " id="thumb1">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="ok">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Djelal Eddine</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="ban">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Moh Aymen</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3511252200/f97a40336742d17609e0b0ca17e301b8_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban">admitted</i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="new">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Dia ElHak</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3023221270/fcb34337f850c1037af9840ebe510d36_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-success" title="validate"><i class="fa fa-check-square">validate</i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- END id="thumb" -->

                                </div>
                                <!-- END tab-content -->
                            </div>


                        </div>
                        <!--END panel-table-->
                    </div>
                </div>
            </div>




            <div id="divdebanidos" runat="server" style="display: none;">
                <div class="row">
                    <div id="user" class="col-md-12">
                        <div class="panel panel-primary panel-table animated slideInDown">
                            <div class="panel-heading " style="padding: 5px;">
                                <div class="row">

                                    <div class="col col-xs-5 text-center">
                                        <h1 class="panel-title">Lista de Banidos</h1>
                                    </div>

                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="list">
                                        <table id="tableBanidos" class="table table-striped table-bordered table-list">
                                            <thead>
                                                <tr>
                                                    <th class="avatar">Foto</th>
                                                    <th>Usuário Banido</th>

                                                    <th><em class="fa fa-cog"></em></th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString %>' SelectCommand="select * from denuncia_postagem where [status] = 'pendente'"></asp:SqlDataSource>

                                                <input type="text" id="myInput3" class="form-control" onkeyup="myFunction3()" placeholder="Procurar Banidos" title="Type in a name"></input>
                                                <asp:Repeater ID="Repeater5" DataSourceID="SqlDataSource6" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="ok">
                                                            <td class="avatar">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg"></td>

                                                            <td><%# Eval("login") %></td>

                                                            <td align="center">


                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Desbanir o Usuário?')" CommandArgument='<%# Eval("login") %>' ID="btndesbanir" OnClick="btndesbanir_Click" runat="server" title="Desbanir" class="btn btn-warning"><i title="Desbanir" class="fa fa-ban"></i>&nbsp;</asp:LinkButton>

                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>


                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- END id="list" -->

                                    <div role="tabpanel" class="tab-pane " id="thumb">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="ok">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Djelal Eddine</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="ban">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Moh Aymen</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3511252200/f97a40336742d17609e0b0ca17e301b8_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban">admitted</i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="new">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Dia ElHak</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3023221270/fcb34337f850c1037af9840ebe510d36_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-success" title="validate"><i class="fa fa-check-square">validate</i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- END id="thumb" -->

                                </div>
                                <!-- END tab-content -->
                            </div>


                        </div>
                        <!--END panel-table-->
                    </div>
                </div>
            </div>
            <div id="divdesolicita" runat="server" style="display: none;">
                <div class="row" id="divdenunciauser" style="width: 1140px;">
                    <div id="user" class="col-md-12">
                        <div class="panel panel-primary panel-table animated slideInDown">
                            <div class="panel-heading " style="padding: 5px;">
                                <div class="row">

                                    <div class="col col-xs-5 text-center">
                                        <h1 class="panel-title">Lista de Solicitações de Categoria</h1>
                                    </div>

                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane active" id="list">
                                        <table id="tableDENUUSER" class="table table-striped table-bordered table-list">
                                            <thead>
                                                <tr>
                                                    <th class="avatar">Foto</th>
                                                    <th>Requisitante</th>
                                                    <th>Sub-Categoria</th>
                                                    <th>Categoria</th>
                                                    <th><em class="fa fa-cog"></em></th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:SqlDataSource runat="server" ID="SqlDataSource7" ConnectionString='<%$ ConnectionStrings:2019YoyooConnectionString %>' SelectCommand="select * from solicita_categoria where [status] = 'pendente'"></asp:SqlDataSource>
                                                <input type="text" id="myInput2" class="form-control" onkeyup="myFunction2()" placeholder="Procurar denunciados" title="Type in a name"></input>
                                                <asp:Repeater ID="Repeater6" DataSourceID="SqlDataSource7" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="ok">
                                                            <td class="avatar">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg"></td>
                                                            <td><%# Eval("login") %></td>
                                                            <td><%# Eval("descricao") %></td>
                                                            <td><%# Eval("sub_categoria") %></td>
                                                            <td align="center">
                                                                <a href='PaginaPerfilVisita.aspx?user=<%# Eval("login") %>'>
                                                                    <button type="button" title="ver Perfil" class="btn btn-primary" style=""><i class="fa fa-address-card"></i></button>
                                                                </a>

                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Aprovar a Categoria??')" runat="server" CommandArgument='<%# Eval("descricao") + ";" + Eval("sub_categoria") + ";" + Eval("solicita_categoria_id")%>' ID="btnaprovacategoria" OnClick="btnaprovacategoria_Click" title="Aprovar categoria" class="btn btn-warning"><i title="Aprovar categoria" class="fa fa-check-square"></i>&nbsp;</asp:LinkButton>
                                                                <asp:LinkButton OnClientClick="return confirm('Deseja Realmente Excluir a Solicitação?')" CommandArgument='<%# Eval("solicita_categoria_id") %>' ID="btnrecusacategoria" OnClick="btnrecusacategoria_Click" title="Excluir solicitação" runat="server" class="btn btn-danger"><i title="Excluir solicitação" class="fa fa-window-close"></i>&nbsp;</asp:LinkButton>
                                                            </td>
                                                        </tr>

                                                    </ItemTemplate>

                                                </asp:Repeater>


                                            </tbody>
                                        </table>
                                    </div>
                                    <!-- END id="list" -->

                                    <div role="tabpanel" class="tab-pane " id="thumb1">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <div class="ok">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Djelal Eddine</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/746779035720683521/AyHWtpGY_400x400.jpg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="ban">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Moh Aymen</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3511252200/f97a40336742d17609e0b0ca17e301b8_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban">admitted</i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="new">
                                                    <div class="col-md-3">
                                                        <div class="panel panel-default panel-thumb">
                                                            <div class="panel-heading">
                                                                <h3 class="panel-title">Dia ElHak</h3>
                                                            </div>
                                                            <div class="panel-body avatar-card">
                                                                <img src="https://pbs.twimg.com/profile_images/3023221270/fcb34337f850c1037af9840ebe510d36_400x400.jpeg">
                                                            </div>
                                                            <div class="panel-footer">
                                                                <a href="#" class="btn btn-primary" title="Edit"><i class="fa fa-pencil"></i></a>
                                                                <a href="#" class="btn btn-success" title="validate"><i class="fa fa-check-square">validate</i></a>
                                                                <a href="#" class="btn btn-warning" title="ban"><i class="fa fa-ban"></i></a>
                                                                <a href="#" class="btn btn-danger" title="delete"><i class="fa fa-trash"></i></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- END id="thumb" -->

                                </div>
                                <!-- END tab-content -->
                            </div>


                        </div>
                        <!--END panel-table-->
                    </div>
                </div>
            </div>
             <asp:Repeater ID="repeater2" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                <div class="modal" style="z-index: 1000000;" id="mod<%# Eval("postagem_id") %>">
                    <div class="modal-dialog">
                        <div class="modal-content" style="width:700px;">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Postagem Denunciada</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                                 <div style="width: 532px;" class="container mt-3 card">
                                        <div class="">
                                            <%-- Dono da postagem --%>
                                            <a href="PaginaPerfilVisita.aspx?user=<%#Eval("login") %>">
                                                <h4 id="loginTXT" runat="server" style="border: none; background-color: white; color: purple; font-size: medium; cursor: pointer"><%# Eval("login") %></h4>
                                            </a>
                                            <h2 style="width: 300px;" id="tituloH2" runat="server" visible="True"><%#Eval("titulo")%></h2>
                                            <%-- TextBox de Ediçao do titulo --%>
                                            <asp:TextBox ID="TextBox1" CssClass="TextBoxTitu d-none" data="editTitu" runat="server" Text='<%#Eval("titulo")%>'></asp:TextBox>

                                            <%-- TextBox de Ediçao da avaliação_desvantagem --%>
                                            <asp:TextBox ID="TextBox3" CssClass="TextBoxEditDesVanta d-none" runat="server" data="editDesVanta" Text='<%#Eval("avaliacao_desvantagem")%>'></asp:TextBox>


                                            <!--Botões de opcões na postagem-->
                                            <div style="margin-top: -45px;" class="d-flex justify-content-end">
                                                <div class="toast">
                                                    <div class="toast-header">
                                                        Toast Header
                                                    </div>
                                                    <div class="toast-body">
                                                      
                                                    </div>
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

                                        <!-- Tab panes -->

                                        <div class="tab-content card" style="width: 400px;">
                                            <div id="van<%# Eval("postagem_id") %>" class="container tab-pane active">
                                                <br>
                                                <%-- TextBox de Ediçao da avaliação_vantagem --%>
                                                <asp:TextBox ID="TextBox2" CssClass="TextBoxEditAvaVanta d-none" runat="server" data="editAvaVanta" Text='<%#Eval("avaliacao_vantagem")%>'></asp:TextBox>
                                                <p><%# Eval("avaliacao_vantagem") %></p>
                                            </div>
                                            <div id="des<%# Eval("postagem_id") %>" class="container tab-pane fade">
                                                <br>
                                                <p><%# Eval("avaliacao_desvantagem") %></p>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button5" runat="server" class="SumirBotaoSalvar d-none" data="SalveEdicao" Text="Salvar" />
                                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:2019YoyooConnectionString %>" SelectCommand="SELECT * FROM tblImages as tbl WHERE postagem_id = @postagemid">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="postagemid" PropertyName="Value" ControlID="HfieldID" DbType="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <section class="awSlider d-flex justify-content-end">
                                            <div id="carro<%# Eval("postagem_id") %>" class="carousel slide" data-ride="carousel">

                                                <!-- Indicators -->

                                                <!-- The slideshow -->



                                                <div class="carousel-inner" style="width: 500px">
                                                    <div class="carousel-item active">
                                                        <img src="Imagem/Yoyoo B.png" alt="Chicago" width="500px" height="350px">
                                                    </div>

                                                    <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource5">
                                                        <ItemTemplate>

                                                            <div style="" runat="server" id="divIMGID" class="carousel-item">

                                                                <img src='<%# getimage(Eval("postagem_id"), Eval("imagedata")) %>' alt="Chicago" width="500px" height="350px">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>

                                                <!-- Left and right controls -->
                                                <a class="carousel-control-prev" href="#carro<%# Eval("postagem_id") %>" style="background-color: rgb(183, 181, 181)" data-slide="prev">
                                                    <span class="carousel-control-prev-icon"></span>
                                                </a>
                                                <a class="carousel-control-next" href="#carro<%# Eval("postagem_id") %>" style="background-color: rgb(183, 181, 181)" data-slide="next">
                                                    <span class="carousel-control-next-icon"></span>
                                                </a>
                                            </div>
                                        </section>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
                 </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString='<%$ ConnectionStrings:Ver_usuarios %>' SelectCommand="select * from usuario where banido = '1'"></asp:SqlDataSource>
            </div>
</asp:Content>
