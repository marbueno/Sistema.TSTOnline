$(document).ready(function () {
    carregarEmpresas();
});


$("#txtBuscaEmpresa").on('keyup', function () {

    $("#tblEmpresa tr").remove();

    var busca = $('#txtBuscaEmpresa').val();

    var listResult = filterValuePart(listEmpresas, busca, ['codigo', 'razaoSocial', 'nomeFantasia']);

    listResult.forEach(item => {
        var cols = "";
        var newRow = $("<tr>");
        cols += '<td><input type="radio" value="' + item.codigo + '" data-razaosocial="' + item.razaoSocial + '" data-nomerespempresa="' + item.nomeRespEmpresa +
                                                                  '" data-cpfresponsavel="' + item.cpfResponsavel + '" data-telresponsavel="' + item.telResponsavel +
                                                                  '" data-nitresponsavel="' + item.nitResponsavel + '" data-emailresponsavel="' + item.emailResponsavel + '" name="IDEmpresa" id="IDEmpresa"></td>';
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
    var nomeRespEmpresa = checkBox[0].dataset.nomerespempresa;
    var cpfResponsavel = checkBox[0].dataset.cpfresponsavel;
    var telResponsavel = checkBox[0].dataset.telresponsavel;
    var nitResponsavel = checkBox[0].dataset.nitresponsavel;
    var emailResponsavel = checkBox[0].dataset.emailresponsavel;

    $("#idEmpresa").val(codigo);
    $("#RazaoSocial").val(razaoSocial);
    $("#ResponsavelEmpresaNome").val(nomeRespEmpresa);
    $("#ResponsavelEmpresaCPF").val(cpfResponsavel);
    $("#ResponsavelEmpresaTelefone").val(telResponsavel);
    $("#ResponsavelEmpresaNIT").val(nitResponsavel);
    $("#ResponsavelEmpresaEmail").val(emailResponsavel);
});