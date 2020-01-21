$(document).ready(function () {
    carregarAmbientes();
});


$("#txtBuscaAmbiente").on('keyup', function () {

    $("#tblAmbiente tr").remove();

    var busca = $('#txtBuscaAmbiente').val();

    var listResult = filterValuePart(listAmbientes, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo +   '" data-nomeestabelecimento="' + item.nomeEstabelecimento +
                                                                    '" data-cnpj="' + item.cnpj +
                                                                    '" data-email="' + item.email +
                                                                    '" data-cep="' + item.cep +
                                                                    '" data-endereco="' + item.endereco +
                                                                    '" name="IDAmbiente" id="IDAmbiente"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.cnpj + '</td>';
        cols += '<td>' + item.nomeEstabelecimento + '</td>';
        newRow.append(cols);
        $("#tblAmbiente").append(newRow);
    });
});

$("#addAmbiente").on('click', function () {

    var checkBox = $("input[name='IDAmbiente']:checked");
    var codigo = checkBox.val();
    var nomeEstabelecimento = checkBox[0].dataset.nomeestabelecimento;
    var cep = checkBox[0].dataset.cep;
    var endereco = checkBox[0].dataset.endereco;

    $("#IDLocal").val(codigo);
    $("#LocalDescricao").val(nomeEstabelecimento + ' | ' + cep + ' | ' + endereco);
});