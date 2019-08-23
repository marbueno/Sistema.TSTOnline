$(document).ready(function () {
    carregarVendedores();
});


$("#txtBusca").on('keyup', function () {

    $("#tblVendedor tr").remove();

    var busca = $('#txtBusca').val();

    var listResult = filterValuePart(listVendedores, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo + '" data-nome="' + item.nome + '" name="IDVendedor" id="IDVendedor"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.nome + '</td>';
        cols += '<td>' + item.cpf + '</td>';
        newRow.append(cols);
        $("#tblVendedor").append(newRow);
    });
});

$("#addVendedor").on('click', function () {

    var checkBox = $("input[name='IDVendedor']:checked");
    var codigo = checkBox.val();
    var nome = checkBox[0].dataset.nome;

    $("#idVendedor").val(codigo);
    $("#VendedorNome").val(nome);
});