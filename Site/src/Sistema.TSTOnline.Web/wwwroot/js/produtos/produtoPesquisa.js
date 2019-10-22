$(document).ready(function () {
    carregarProdutos();
});


$("#txtBusca").on('keyup', function () {

    $("#tblProduto tr").remove();

    var busca = $('#txtBusca').val();

    var listResult = filterValuePart(listProdutos, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        var preco = "R$ " + accounting.formatMoney(item.preco, "", 2, ".", ",");

        console.log(item);

        cols += '<td><input type="radio" value="' + item.idProduto + '" data-nome="' + item.nome + '" data-preco="' + preco + '" name="IDProduto" id="IDProduto"></td>';
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

    $("#idProduto").val(idProduto);
    $("#ProdutoNome").val(nome);
});