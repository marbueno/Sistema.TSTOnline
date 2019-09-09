var codigo = 0;
var columns = [
    { "data": "idPedido" },
    {
        "data": "dataCadastro",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    {
        "data": "dataVenda",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "razaoSocial" },
    { "data": "vendedorNome" },
    { "data": "statusDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idPedido + ")' title='Editar'>Editar</a>";

            if (row.status !== 1)
                editButton = "";

            return editButton;
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

            if (row.status !== 1)
                cancelButton = "";

            return cancelButton;
        }
    }
];

function editRegister(id) {
    window.location = '/pedidovenda/pedidoVendaAddEdit/' + id;
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

$("#slcProduto").change(function () {

    var idProduto = $(this).val();

    listProdutos.forEach(item => {
        if (item.codigo.toString() === idProduto) {
            $("#txtValor").val(item.preco);
        }
    });
});


$("#frmPedidoVenda").submit(function (event) {

    event.preventDefault();
    var json = $(this).serializeObject();

    var pedidoVenda = {
        "idPedido": json.IDPedido === "" ? 0 : parseInt(json.IDPedido),
        "dataVenda": json.DataVenda,
        "idVendedor": json.idVendedor,
        "idEmpresa": json.idEmpresa,
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
