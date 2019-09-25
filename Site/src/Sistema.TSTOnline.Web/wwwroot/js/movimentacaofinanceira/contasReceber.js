var codigo = 0;
var columns = [
    { "data": "idContasReceber" },
    { "data": "razaoSocial" },
    { "data": "numeroTitulo" },
    {
        "data": "dataVencimento",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    {
        "mDataProp": "valor",
        mRender: function (data, type, row) {

            var valor = "R$ " + accounting.formatMoney(row.valor, "", 2, ".", ",");

            return valor;
        }
    },
    {
        "mDataProp": "valorPago",
        mRender: function (data, type, row) {

            var valorPago = "R$ " + accounting.formatMoney(row.valorPago, "", 2, ".", ",");

            return valorPago;
        }
    },
    { "data": "statusDescricao" },
    {
        "mDataProp": "Link Fatura",
        mRender: function (data, type, row) {
            var linkFatura = '';
            var linkFaturaGerada = "<a class='btn btn-primary btn-sm' href='" + row.linkFatura + "' target='_blank' style='text-align:center;width:100%' title='Clique para Visualizar Fatura'>Visualizar</a>";
            var linkGerarFatura = "<a class='btn btn-warning btn-sm' href='#' style='text-align:center;width:100%' data-toggle='modal' data-target='#divConfirmar_4' onclick='codigo=" + row.idContasReceber + "' title='Gera Link da Fatura'>Gerar Fatura</a>";

            if (row.status !== 2) {
                if (row.linkFatura === '' || row.linkFatura === null || row.linkFatura === undefined)
                    linkFatura = linkGerarFatura;
                else
                    linkFatura = linkFaturaGerada;
            }

            return linkFatura;
        }
    },
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

            var editButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_3' onclick='codigo=" + row.idContasReceber + "' title='Efetuar Baixa do Titulo'>Baixar</a>";

            if (row.status !== 1)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Cancelar",
        mRender: function (data, type, row) {
            var cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_1' onclick='codigo=" + row.idContasReceber + "' title='Cancelar Titulo'>Cancelar</a>";

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

function gerarFatura() {
    if (codigo !== 0) {

        fetch('/movimentacaofinanceira/contasReceberGerarFatura/' + codigo, { method: 'put' })
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