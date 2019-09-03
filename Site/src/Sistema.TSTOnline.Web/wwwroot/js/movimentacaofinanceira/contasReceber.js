var codigo = 0;
var columns = [
    { "data": "idContasReceber" },
    {
        "data": "dataCadastro",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "razaoSocial" },
    { "data": "numeroTitulo" },
    {
        "data": "dataVencimento",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "valor" },
    { "data": "valorPago" },
    { "data": "statusDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idContasReceber + ")' title='Editar'>Editar</a>";

            if (row.status === 2 || row.status === 4 || row.origem === 2)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Baixar Titulo",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_3' onclick='codigo=" + row.idContasReceber + "' title='Efetua a baixa do título'>Baixar</a>";

            if (row.status !== 1)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Cancelar",
        mRender: function (data, type, row) {
            var cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_1' onclick='codigo=" + row.idContasReceber + "' title='Cancelar Título'>Cancelar</a>";

            if (row.status !== 1)
                cancelButton = "";

            return cancelButton;
        }
    }
];

function editRegister(id) {
    window.location = '/movimentacaofinanceira/contasReceberAddEdit/' + id;
}

function baixarTitulo() {
    if (codigo !== 0) {

        fetch('/movimentacaofinanceira/alterarStatusContasReceber/' + codigo + '/2', { method: 'put' })
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

        fetch('/movimentacaofinanceira/alterarStatusContasReceber/' + codigo + '/4', { method: 'put' })
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
    carregarContasReceber().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblContasReceber', listContasReceber, columns);
        }
    });
});