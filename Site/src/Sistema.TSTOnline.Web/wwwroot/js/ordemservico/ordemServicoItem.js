var _item = 1;
var listOrdemServicoItens = [];

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

    var idOrdemServico = $("#idServico").val();

    carregarOrdemServicoItens(idOrdemServico).then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblOrdemServicoItens', listOrdemServicos, columns);
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
        if (item.idTipoServico === idTipoServico) {
            item.concluido = check.checked;
        }
    });
}

function adicionarItem(event) {
    try {

        var idTipoServico = $("#slcTipoServico option:selected").val();
        var descricaoServico = $("#slcTipoServico option:selected").text();
        var observacao = $("#txtObservacao").val();

        if (idTipoServico !== null && idTipoServico !== undefined && idTipoServico !== "0") {

            if (!existsItem(idTipoServico)) {

                listOrdemServicoItens.push(
                    { idTipoServico: idTipoServico, observacao: observacao, concluido: false }
                );

                var cols = "";
                var rowID = "row" + _item.toString();
                var newRow = $("<tr id='" + rowID + "'>");
                cols += '<td>' + descricaoServico + '</td>';
                cols += '<td>' + observacao + '</td>';
                cols += '<td><input name="concluido" type="checkbox" style="height: 20px; width: 40px;" onclick="changeStatus(this,\'' + idTipoServico.toString() + '\');" /></td>';
                cols += '<td><a href="#" title="Excluir Item" onclick="excluirItem(\'' + rowID + '\',\'' + idTipoServico.toString() + '\')"><i class="far fa-trash-alt"></i></a></td>';
                newRow.append(cols);
                $("#tblOrdemServicoItens").append(newRow);

                _item += 1;
            }
        }
    }
    catch (ex) {
        console.log(ex.message);
    }
}

$("#frmOrdemServico").submit(function (event) {
    debugger;
    event.preventDefault();
    var ordemServico = $(this).serializeObject();
    //ordemServico.ordemServicoItens = JSON.stringify(listOrdemServicoItens);

    //var dadosOrdemServico = { ordemServicoVM: JSON.stringify(ordemServico) };

    ordemServico.ordemServicoItens = listOrdemServicoItens;

    var dadosOrdemServico = { ordemServicoVM: ordemServico };

    fetch('/ordemservico/ordemServicoCreateOrUpdate',
        {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(ordemServico)
        })
        .then(response => {
            if (response.status === 200) {
                window.location.reload();
            }
        })
        .error(ex => {
            console.log(ex);
        });
});