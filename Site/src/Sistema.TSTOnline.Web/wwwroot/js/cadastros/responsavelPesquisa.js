$(document).ready(function () {
        carregarResponsaveis();
});


$("#txtNomeResponsavel").on('keyup', function () {

    $("#tblResponsavel tr").remove();

    var busca = $('#txtNomeResponsavel').val();

    var listResult = filterValuePart(listResponsaveis, busca, ['codigo', 'nomeResponsavel', 'cpf']);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo + '" data-nomeresponsavel="' + item.nomeResponsavel + '" name="IDResp" id="IDResp"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.nomeResponsavel + '</td>';
        cols += '<td>' + item.cpf + '</td>';
        newRow.append(cols);
        $("#tblResponsavel").append(newRow);
    });
});

$("#addResponsavel").on('click', function () {

    var checkBox = $("input[name='IDResp']:checked");
    var codigo = checkBox.val();
    var nomeResponsavel = checkBox[0].dataset.nomeresponsavel;

    $("#IDResp").val(codigo);
    $("#ResponsavelNome").val(nomeResponsavel);
});