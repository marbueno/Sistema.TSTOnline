var _item = 1;

var columns = [
    { "data": "idTipoServico" },
    { "data": "item" },
    { "data": "tipoServicoDescricao" },
    { "data": "observacao" },
    { "data": "concluido" },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a href='#' title='Excluir Item'><i class='far fa-trash-alt'></i></a>";
        }
    }
];

var columnDefs = [
    {
        "render": function (data, type, row, meta) {
            return "<input name='idTipoServico' type='hidden' value='" + data + "' />";
        },
        "targets": [0]
    }
];

$(document).ready(function () {
    carregarItens();
});

function carregarItens() {

    var idOrdemServico = $("#idOrdemServico").val();

    carregarOrdemServicoItens(idOrdemServico).then(dataLoaded => {
        if (dataLoaded) {
            listOrdemServicoItens.forEach(item => {
                addToTable(item.idTipoServico, item.tipoServicoDescricao, item.observacao, item.concluido);
            });
        }
    });
}

function existsItem(idTipoServico) {

    var exists = false;
    listOrdemServicoItens.forEach(item => {
        if (item.idTipoServico === idTipoServico) {
            exists = true;
        }
    });

    return exists;
}

function excluirItem(row, idTipoServico) {

    $("#" + row).remove();

    var index = 0;
    listOrdemServicoItens.forEach(item => {
        if (item.idTipoServico === idTipoServico) {
            listOrdemServicoItens.splice(index, 1);
        }
        index++;
    });
}

function changeStatus(check, idTipoServico) {
    listOrdemServicoItens.forEach(item => {
        if (item.idTipoServico.toString() === idTipoServico) {
            item.concluido = check.checked;
        }
    });
}

function adicionarItem() {
    try {

        var idTipoServico = $("#slcTipoServico option:selected").val();
        var tipoServicoDescricao = $("#slcTipoServico option:selected").text();
        var observacao = $("#txtObservacao").val();

        if (idTipoServico !== null && idTipoServico !== undefined && idTipoServico !== "0") {

            if (!existsItem(idTipoServico)) {

                listOrdemServicoItens.push(
                    { idTipoServico: idTipoServico, observacao: observacao, concluido: false }
                );

                addToTable(idTipoServico, tipoServicoDescricao, observacao, false);
            }
        }
    }
    catch (ex) {
        console.log(ex.message);
    }
}

function addToTable(idTipoServico, tipoServicoDescricao, observacao, concluido) {
    try {

        var cols = "";
        var rowID = "row" + _item.toString();
        var newRow = $("<tr id='" + rowID + "'>");
        var checked = "";
        if (concluido)
            checked = "checked";

        cols += '<td>' + tipoServicoDescricao + '</td>';
        cols += '<td>' + observacao + '</td>';
        cols += '<td><input name="concluido" type="checkbox" style="height: 20px; width: 40px;" ' + checked + ' onclick="changeStatus(this,\'' + idTipoServico.toString() + '\');" /></td>';
        cols += '<td><a href="#" title="Excluir Item" onclick="excluirItem(\'' + rowID + '\',\'' + idTipoServico.toString() + '\')"><i class="far fa-trash-alt"></i></a></td>';
        newRow.append(cols);
        $("#tblOrdemServicoItens").append(newRow);

        _item += 1;
    }
    catch (ex) {
        console.log(ex.message);
    }
}