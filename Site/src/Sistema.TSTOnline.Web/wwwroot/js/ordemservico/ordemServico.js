var codigo = 0;
var columns = [
    { "data": "codigo" },
    { "data": "dataCadastro" },
    { "data": "dataServico" },
    { "data": "statusDescricao" },
    { "data": "responsavelNome" },
    { "data": "localDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {
            return "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.codigo + ")' title='Editar'>Editar</a>";
        }
    },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar' onclick='codigo=" + row.codigo + "' title='Excluir'>Excluir</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/ordemservico/ordemServicoAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/ordemservico/ordemServicoDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarOrdemServicos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblOrdemServico', listOrdemServicos, columns);
        }
    });
});
