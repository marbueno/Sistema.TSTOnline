$(document).ready(function () {
    carregarEmpresas();
});


$("#txtBuscaEmpresa").on('keyup', function () {

    $("#tblEmpresa tr").remove();

    var busca = $('#txtBuscaEmpresa').val();

    var listResult = filterValuePart(listEmpresas, busca);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo + '" data-razaosocial="' + item.razaoSocial + '" name="IDEmpresa" id="IDEmpresa"></td>';
        cols += '<td>' + item.codigo + '</td>';
        cols += '<td>' + item.razaoSocial + '</td>';
        cols += '<td>' + item.nomeFantasia + '</td>';
        newRow.append(cols);
        $("#tblEmpresa").append(newRow);
    });
});

$("#addEmpresa").on('click', function () {

    var checkBox = $("input[name='IDEmpresa']:checked");
    var codigo = checkBox.val();
    var razaoSocial = checkBox[0].dataset.razaosocial;

    $("#idEmpresa").val(codigo);
    $("#RazaoSocial").val(razaoSocial);
});