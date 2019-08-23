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
    { "data": "statusDescricao" },
    { "data": "vendedorNome" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idPedido + ")' title='Editar'>Editar</a>";

            if (row.status === 4 || row.status === 5)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Fechar Pedido",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar2' onclick='codigo=" + row.idPedido + "' title='Fechar Pedido'>Fechar Pedido</a>";

            if (row.status !== 1)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Cancelar",
        mRender: function (data, type, row) {
            var cancelButton = "";

            if (row.status !== 4)
                cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar1' onclick='codigo=" + row.idPedido + "' title='Cancelar Pedido'>Cancelar</a>";

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
            .then(() => {
                window.location.reload();
            });
    }
}

function cancelRegister () {
    if (codigo !== 0) {

        fetch('/pedidovenda/alterarStatus/' + codigo + '/4', { method: 'put' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarPedidosVenda().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblPedidoVenda', listPedidosVenda, columns);
        }
    });
});


$("#frmPedidoVenda").submit(function (event) {
    debugger;
    event.preventDefault();
    var json = $(this).serializeObject();

    var pedidoVenda = {
        "idPedido": json.IDPedido === "" ? 0 : parseInt(json.IDPedido),
        "dataVenda": json.DataVenda,
        "idVendedor": json.idVendedor,
        "idUsuario": 1,
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
                window.location = '/pedidovenda/pedidoVenda';
            }
        })
        .catch(ex => {
            console.log(ex);
        });
});
