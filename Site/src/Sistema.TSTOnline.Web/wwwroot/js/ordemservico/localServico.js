var codigo = 0;
var columns = [
    { "data": "codigo" },
    { "data": "nome" },
    { "data": "cep" },
    { "data": "bairro" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {
            return "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.codigo + ")' title='Editar'>Editar</a>";
        }
    },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_0' onclick='codigo=" + row.codigo + "' title='Excluir'>Excluir</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/ordemservico/localServicoAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/ordemservico/localServicoDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarLocaisServicos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblLocalServico', listLocaisServicos, columns);
        }
    });
});