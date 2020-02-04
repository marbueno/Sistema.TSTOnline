$(document).ready(function () {
    carregarLocaisServicos();
});


$("#txtLocalServico").on('keyup', function () {

    $("#tblLocalServico tr").remove();

    var busca = $('#txtLocalServico').val();

    var listResult = filterValuePart(listLocaisServicos, busca, ['codigo', 'nome', 'endereco', 'bairro', 'cidade', 'uf']);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        debugger;
        cols += '<td><input type="radio" value="' + item.codigo + '" data-nomelocalservico="' + item.nome + '" data-endereco="' + item.endereco + '" data-cidade="' + item.cidade + '" data-uf="' + item.uf + '" data-nomeContato="' + item.nomeContato + '" data-telefone="' + item.telefone + '" data-whatsApp="' + item.whatsApp + '" name="IDLocal" id="IDLocal"></td>';
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
    var nomeContato = checkBox[0].dataset.nomecontato;
    var telefone = checkBox[0].dataset.telefone;
    var whatsApp = checkBox[0].dataset.whatsapp;

    $("#IDLocal").val(codigo);
    $("#NomeContato").val(nomeContato);
    $("#Telefone").val(telefone);
    $("#WhatsApp").val(whatsApp);
    $("#LocalDescricao").val(nomeLocalServico + ' | ' + endereco + ' | ' + cidade + '-' + uf);
});