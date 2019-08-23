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
        cols += '<td><input type="radio" value="' + item.codigo + '" data-sku="' + item.sku + '" data-nome="' + item.nome + '" name="IDProduto" id="IDProduto"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.sku + '</td>';
        cols += '<td>' + item.nome + '</td>';
        newRow.append(cols);
        $("#tblProduto").append(newRow);
    });
});

$("#addProduto").on('click', function () {

    var checkBox = $("input[name='IDProduto']:checked");
    var codigo = checkBox.val();
    var sku = checkBox[0].dataset.sku;
    var nome = checkBox[0].dataset.nome;

    $("#idProduto").val(codigo);
    $("#ProdutoNome").val(sku + " | " + nome);
});