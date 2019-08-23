var _item = 1;

$(document).ready(function () {
    carregarItens();
});

function carregarItens() {

    var idPedido = $("#idPedido").val();

    carregarPedidosVendaItens(idPedido).then(dataLoaded => {
        if (dataLoaded) {
            listPedidosVendaItens.forEach(item => {
                addToTable(item.idProduto, item.produtoNome, item.qtde, item.valor);
            });
        }
    });
}

function existsItem(idProduto) {

    var exists = false;
    listPedidosVendaItens.forEach(item => {
        if (item.idProduto === idProduto) {
            exists = true;
        }
    });

    return exists;
}

function excluirItem(row, idProduto) {

    $("#" + row).remove();

    var index = 0;
    listPedidosVendaItens.forEach(item => {
        if (item.idProduto === idProduto) {
            listPedidosVendaItens.splice(index, 1);
        }
        index++;
    });
}

function adicionarItem() {
    try {

        var idProduto = $("#slcProduto option:selected").val();
        var produtoNome = $("#slcProduto option:selected").text();
        var qtde = $("#txtQtde").val();
        var valor = $("#txtValor").val();

        if (idProduto !== null && idProduto !== undefined && idProduto !== "0") {

            if (!existsItem(idProduto)) {

                listPedidosVendaItens.push(
                    { idProduto: idProduto, qtde: qtde, valor: valor }
                );

                addToTable(idProduto, produtoNome, qtde, valor);
            }
        }
    }
    catch (ex) {
        console.log(ex.message);
    }
}

function addToTable(idProduto, produtoNome, qtde, valor) {
    try {

        var cols = "";
        var rowID = "row" + _item.toString();
        var newRow = $("<tr id='" + rowID + "'>");

        cols += '<td>' + produtoNome + '</td>';
        cols += '<td>' + qtde + '</td>';
        cols += '<td>' + valor + '</td>';
        cols += '<td><a href="#" title="Excluir Item" onclick="excluirItem(\'' + rowID + '\',\'' + idProduto.toString() + '\')"><i class="far fa-trash-alt"></i></a></td>';
        newRow.append(cols);
        $("#tblPedidoVendaItens").append(newRow);

        _item += 1;
    }
    catch (ex) {
        console.log(ex.message);
    }
}