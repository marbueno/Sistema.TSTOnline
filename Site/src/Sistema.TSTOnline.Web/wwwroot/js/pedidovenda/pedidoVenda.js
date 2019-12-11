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
    { "data": "valorTotal" },
    { "data": "statusDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idPedido + ")' title='Editar'>Editar</a>";

            //if (row.status !== 1 && row.status !== 3)
            //    editButton = "";

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

//$("#slcProduto").change(function () {

//    var idProduto = $(this).val();

//    listProdutos.forEach(item => {
//        if (item.idProduto.toString() === idProduto) {
//            var precoItem = accounting.formatMoney(item.preco, "", 2, ".", ",");
//            debugger;
//            $("#txtQtde").val("1");
//            $("#txtValor").val(precoItem);
//        }
//    });
//});


$("#frmPedidoVenda").submit(function (event) {

    event.preventDefault();
    var json = $(this).serializeObject();

    var pedidoVenda = {
        "idPedido": json.IDPedido === "" ? 0 : parseInt(json.IDPedido),
        "dataVenda": json.DataVenda,
        "idVendedor": json.idVendedor,
        "idEmpresa": json.idEmpresa,
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
