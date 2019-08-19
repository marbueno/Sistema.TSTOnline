$(document).ready(function () {
    carregarLocaisServicos();
});


$("#txtLocalServico").on('keyup', function () {

    $("#tblLocalServico tr").remove();

    var busca = $('#txtLocalServico').val();

    var listResult = filterValuePart(listLocaisServicos, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo + '" data-nomelocalservico="' + item.nome + '" data-endereco="' + item.endereco + '" data-cidade="' + item.cidade + '" data-uf="' + item.uf + '" name="IDLocal" id="IDLocal"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.nome + '</td>';
        cols += '<td>' + item.endereco + '</td>';
        cols += '<td>' + item.bairro + '</td>';
        cols += '<td>' + item.cidade + '</td>';
        cols += '<td>' + item.uf + '</td>';
        newRow.append(cols);
        $("#tblLocalServico").append(newRow);
    });
});

$("#addLocalServico").on('click', function () {

    var checkBox = $("input[name='IDLocal']:checked");
    var codigo = checkBox.val();
    var nomeLocalServico = checkBox[0].dataset.nomelocalservico;
    var endereco = checkBox[0].dataset.endereco;
    var cidade = checkBox[0].dataset.cidade;
    var uf = checkBox[0].dataset.uf;

    $("#IDLocal").val(codigo);
    $("#LocalDescricao").val(nomeLocalServico + ' | ' + endereco + ' | ' + cidade + '-' + uf);
});