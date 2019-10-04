var _item = 1;

$(document).ready(function () {
    carregarItens();
});

function carregarItens() {

    var idPedido = $("#idPedido").val();

    carregarPedidosVendaItens(idPedido).then(dataLoaded => {
        if (dataLoaded) {
            listPedidosVendaItens.forEach(item => {
                var valorAux = accounting.formatMoney(item.valor, "", 2, ".", ",");
                var valorTotalAux = accounting.formatMoney(item.valorTotal, "", 2, ".", ",");
                addToTable(item.idProduto, item.produtoNome, item.qtde, valorAux, valorTotalAux);
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
    debugger;
    var index = 0;
    listPedidosVendaItens.forEach(item => {
        if (item.idProduto.toString() === idProduto) {
            listPedidosVendaItens.splice(index, 1);
        }
        index++;
    });
}

function validouCampos() {
    var idProduto = $("#slcProduto option:selected").val();
    var qtde = $("#txtQtde").val();
    var valor = $("#txtValor").val();
    var arrayMsg = [];

    if (idProduto === null || idProduto === undefined || idProduto === "0")
        arrayMsg.push("Produto nao selecionado.");

    if (qtde === null || qtde === undefined || qtde === "0" || qtde <= 0)
        arrayMsg.push("Qtde nao informada ou invalida.");

    if (valor === null || valor === undefined || valor === "0" || valor <= 0)
        arrayMsg.push("Valor nao informado ou invalido.");

    arrayMsg.forEach(item => {
        showMessage("error", item);
    });

    return arrayMsg.length === 0;
}

function adicionarItem() {
    try {

        var idProduto = $("#slcProduto option:selected").val();
        var produtoNome = $("#slcProduto option:selected").text();
        var qtde = $("#txtQtde").val();
        var valor = $("#txtValor").val();

        if (validouCampos()) {

            if (!existsItem(idProduto)) {
                var valorAux = valor.toString().replace('.', '').replace(',', '.');
                var valorTotalAux = parseInt(qtde) * parseFloat(valorAux);
                valorTotalAux = accounting.formatMoney(valorTotalAux, "", 2, ".", ",");

                listPedidosVendaItens.push(
                    { idProduto: idProduto, qtde: qtde, valor: valorAux }
                );

                addToTable(idProduto, produtoNome, qtde, valor, valorTotalAux);
            }
        }
    }
    catch (ex) {
        console.log(ex.message);
    }
}

function addToTable(idProduto, produtoNome, qtde, valor, valorTotal) {
    try {

        var cols = "";
        var rowID = "row" + _item.toString();
        var newRow = $("<tr id='" + rowID + "'>");
        var valorFormatado = "R$ " + valor.toString();
        var valorTotalFormatado = "R$ " + valorTotal.toString();

        cols += '<td>' + produtoNome + '</td>';
        cols += '<td>' + qtde + '</td>';
        cols += '<td>' + valorFormatado + '</td>';
        cols += '<td>' + valorTotalFormatado + '</td>';
        cols += '<td><a href="#" title="Excluir Item" onclick="excluirItem(\'' + rowID + '\',\'' + idProduto.toString() + '\')"><i class="far fa-trash-alt"></i></a></td>';
        newRow.append(cols);
        $("#tblPedidoVendaItens").append(newRow);

        _item += 1;
    }
    catch (ex) {
        console.log(ex.message);
    }
}