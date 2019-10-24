var codigo = 0;
var columns = [
    { "data": "idFluxoCaixa" },
    {
        "data": "dataLancamento",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "tipoLancamentoDescricao" },
    { "data": "origemDescricao" },
    { "data": "pedidoVendaNumero" },
    { "data": "contasReceberParcela" },
    { "data": "razaoSocial" },
    {
        "mDataProp": "valor",
        mRender: function (data, type, row) {

            var valor = "R$ " + accounting.formatMoney(row.valor, "", 2, ".", ",");

            return valor;
        }
    },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idFluxoCaixa + ")' title='Editar'>Editar</a>";

            if (row.origem === 2)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "ImprimirFluxo",
        mRender: function (data, type, row) {

            return "<a class='btn btn-primary btn-sm' href='#' onclick='imprimirFluxo(" + row.idFluxoCaixa + ")' title='Clique para Imprimir'>Imprimir</a>";
        }
    },
];

function editRegister(id) {
    window.location = '/movimentacaofinanceira/fluxoCaixaAddEdit/' + id;
}

function imprimirFluxo(id) {

    try {
        window.open('/movimentacaofinanceira/fluxoCaixaImprimir/' + id, '_blank');
    }
    catch (ex) {
        console.log(error);
        showMessage("error", error);
    }
}

$(document).ready(function () {
    carregarFluxoCaixa().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblFluxoCaixa', listFluxoCaixa, columns);
        }
    });
});