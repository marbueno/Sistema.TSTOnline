var codigo = 0;
var columns = [
    { "data": "idPedido" },
    {
        "data": "dataVenda",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "razaoSocial" },
    { "data": "vendedorNome" },
    { "data": "tipoPagamentoDescricao" },
    { "data": "valorTotalFormatado" },
    { "data": "statusDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idPedido + ")' title='Editar'>Editar</a>";

            return editButton;
        }
    },
    {
        "mDataProp": "ImprimirPedido",
        mRender: function (data, type, row) {

            return "<a class='btn btn-primary btn-sm' href='#' onclick='imprimirPedido(" + row.idPedido + ")' title='Clique para Imprimir o Pedido'>Imprimir</a>";
        }
    },
    {
        "mDataProp": "Fechar Pedido",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_2' onclick='codigo=" + row.idPedido + "' title='Fechar Pedido'>Fechar Pedido</a>";

            if (row.status !== 1)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Cancelar",
        mRender: function (data, type, row) {
            var cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_1' onclick='codigo=" + row.idPedido + "' title='Cancelar Pedido'>Cancelar</a>";

            if (row.status !== 1 && row.status !== 2)
                cancelButton = "";

            return cancelButton;
        }
    }
];

function editRegister(id) {
    window.location = '/pedidovenda/pedidoVendaAddEdit/' + id;
}

function imprimirPedido(id) {

    try {
        window.open('/pedidovenda/imprimir/' + id, '_blank');
    }
    catch (ex) {
        console.log(ex);
        showMessage("error", ex);
    }
}

function fecharPedido() {
    if (codigo !== 0) {

        fetch('/pedidovenda/alterarStatus/' + codigo + '/2', { method: 'put' })
            .then(response => {
                if (response.status === 200) {

                    window.location.reload();
                }
                else if (response.status === 500) {
                    return response.text();
                }
            })
            .then(response => {
                showMessage("error", response);
            })
            .catch(error => {
                console.log(error);
                showMessage("error", error);
            });
    }
}

function cancelRegister () {
    if (codigo !== 0) {

        fetch('/pedidovenda/alterarStatus/' + codigo + '/4', { method: 'put' })
            .then(response => {
                if (response.status === 200) {

                    window.location.reload();
                }
                else if (response.status === 500) {
                    return response.text();
                }
            })
            .then(response => {
                showMessage("error", response);
            })
            .catch(error => {
                console.log(error);
                showMessage("error", error);
            });
    }
}

$(document).ready(function () {
    carregarPedidosVenda().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblPedidoVenda', listPedidosVenda, columns);
        }
    });
    carregarProdutos();
});

$("#chkClienteSemCadastro").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#divClienteComCadastro").css("display", "none");
        $("#SC_DadosResponsavel_1").css("display", "none");
        $("#SC_DadosResponsavel_2").css("display", "none");
        $("#divClienteSemCadastro").css("display", "");
    }
    else {
        $("#divClienteComCadastro").css("display", "");
        $("#SC_DadosResponsavel_1").css("display", "");
        $("#SC_DadosResponsavel_2").css("display", "");
        $("#divClienteSemCadastro").css("display", "none");
    }
});

$("#SC_PF").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#SC_CPF").css("display", "");
        $("#SC_CNPJ").css("display", "none");
    }
});

$("#SC_PJ").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#SC_CPF").css("display", "none");
        $("#SC_CNPJ").css("display", "");
    }
});

$("#frmPedidoVenda").submit(function (event) {

    debugger;
    event.preventDefault();
    var json = $(this).serializeObject();

    var vendaExpress = false;

    if ($("#chkClienteSemCadastro")[0] !== undefined && $("#chkClienteSemCadastro")[0] !== null) {
        vendaExpress = $("#chkClienteSemCadastro")[0].checked;
    }

    var tipoPessoa = 1;

    if ($("#SC_PJ")[0] !== undefined && $("#SC_PJ")[0] !== null) {
        if ($("#SC_PJ")[0].checked)
            tipoPessoa = 2;
    }

    var uf = $("#slcUF option:selected").val();

    var pedidoVenda = {
        "idPedido": json.IDPedido === "" ? 0 : parseInt(json.IDPedido),
        "dataVenda": json.DataVenda,
        "idVendedor": json.idVendedor,

        "vendaExpress": vendaExpress,
        "idEmpresa": json.idEmpresa,

        "tipoPessoa": tipoPessoa,
        "cpf": json.CPF,
        "cnpj": json.CNPJ,
        "nomeOuRazaoSocial": json.NomeOuRazaoSocial,
        "email": json.Email,
        "cep": json.CEP,
        "endereco": json.Endereco,
        "numero": json.Numero,
        "complemento": json.Complemento,
        "bairro": json.Bairro,
        "cidade": json.Cidade,
        "uf": uf,
        "telefone": json.Telefone,
        "whatsApp": json.WhatsApp,

        "tipoPagamento": json.tipoPagamento,
        "qtdeParcelas": json.qtdeParcelas,
        "idUsuario": 1,
        "observacao": json.Observacao,
        "pedidoVendaItens": listPedidosVendaItens
    };

    fetch('/pedidovenda/pedidoVendaCreateOrUpdate',
        {
            method: 'post',

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(pedidoVenda)
        })
        .then(response => {
            if (response.status === 200) {

                showMessage("success", "Pedido Salvo com sucesso");

                window.location = '/pedidovenda/pedidoVenda';
            }
            else if (response.status === 500) {
                return response.text();
            }
        })
        .then(response => {
            showMessage("error", response);
        })
        .catch(error => {
            console.log(error);
            showMessage("error", error);
        });
});
