$(document).ready(function () {
    carregarProdutos();
});


$("#txtBuscaProduto").on('keyup', function () {

    $("#tblProduto tr").remove();

    var busca = $('#txtBuscaProduto').val();

    var listResult = filterValuePart(listProdutos, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        var preco = "R$ " + accounting.formatMoney(item.preco, "", 2, ".", ",");
        var precoAux = accounting.formatMoney(item.preco, "", 2, ".", ",");

        console.log(item);

        cols += '<td><input type="radio" value="' + item.idProduto + '" data-nome="' + item.nome + '" data-preco="' + precoAux + '" name="IDProduto" id="IDProduto"></td>';
        cols += '<td>' + item.idProduto + '</td>';
        cols += '<td>' + item.nome + '</td>';
        cols += '<td>' + preco + '</td>';
        newRow.append(cols);
        $("#tblProduto").append(newRow);
    });
});

$("#addProduto").on('click', function () {

    var checkBox = $("input[name='IDProduto']:checked");
    var idProduto = checkBox.val();
    var nome = checkBox[0].dataset.nome;
    var preco = checkBox[0].dataset.preco;
    var qtde = "1";

    $("#idProduto").val(idProduto);
    $("#ProdutoNome").val(nome);

    if ($("#txtQtde"))
        $("#txtQtde").val(qtde);

    if ($("#txtValor"))
        $("#txtValor").val(preco);
});