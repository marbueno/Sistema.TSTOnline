var codigo = 0;
var nome = "";
var cpf = "";
var bairro = "";
var columns = [
    { "data": "codigo" },
    { "data": "nome" },
    { "data": "rg" },
    { "data": "cpf" },
    {
        "data": "dataNascimento",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "email" },
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

function newRegister() {
    codigo = 0;
    nome = "";
    cpf = "";
    bairro = "";
    showForm();
}

function editRegister(id) {
    window.location = '/cadastros/vendedorAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/cadastros/vendedorDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarVendedores().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblVendedor', listVendedores, columns);
        }
    });
});