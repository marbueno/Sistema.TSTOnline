function dateToPT(date) {
    var data = date.split('T')[0];
    return data.split('-').reverse().join('/');
}; 

function filterValuePart(arr, part, columnsToFilter) {
    return arr.filter(function (obj) {
        return Object.keys(obj)
            .some(function (k) {
                if (obj[k] !== null && columnsToFilter.includes(k))
                    return obj[k].toString().toLowerCase().indexOf(part.toString().toLowerCase()) !== -1;
            });
    });
};

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

$("input[name=CEP]").on("blur", function () {
    debugger;
    let cep = $(this).val();

    $.ajax({
        url: 'http://api.postmon.com.br/v1/cep/' + cep,
        type: 'GET',
        dataType: 'json',
        success: function (json) {

            if (typeof json.logradouro !== 'undefined') {
                $("input[name=Endereco]").val(json.logradouro);
                $("input[name=Bairro]").val(json.bairro);
                $("input[name=Cidade]").val(json.cidade);
                $("#slcUF").val(json.estado);
            }
            $("input[name=Numero]").focus();
        }
    });
});

$("input[name=CepEstab]").on("blur", function () {
    debugger;
    let cep = $(this).val();

    $.ajax({
        url: 'http://api.postmon.com.br/v1/cep/' + cep,
        type: 'GET',
        dataType: 'json',
        success: function (json) {

            if (typeof json.logradouro !== 'undefined') {
                $("input[name=EnderecoEstab]").val(json.logradouro);
                $("input[name=BairroEstab]").val(json.bairro);
                $("input[name=CidadeEstab]").val(json.cidade);
                $("#slcUFEstab").val(json.estado);
            }
            $("input[name=NumeroEstab]").focus();
        }
    });
});

$("input[name=CPF]").on("blur", function () {
    debugger;
    let cpfCnpj = $(this).val();

    $.ajax({
        url: '/Cadastros/empresaByCpfCnpj?cpfCnpj=' + cpfCnpj,
        type: 'GET',
        dataType: 'json',
        success: function (json) {
            preencherCamposPesquisaCpfCnpj(json);
            pesquisarAmbiente(cpfCnpj);
            carregarAmbientes(cpfCnpj);
        }
    });
});

$("input[name=CNPJ]").on("blur", function () {
    debugger;
    let cpfCnpj = $(this).val();

    $.ajax({
        url: '/Cadastros/empresaByCpfCnpj?cpfCnpj=' + cpfCnpj,
        type: 'GET',
        dataType: 'json',
        success: function (json) {
            preencherCamposPesquisaCpfCnpj(json);
            pesquisarAmbiente(cpfCnpj);
            carregarAmbientes(cpfCnpj);
        }
    });
});

function pesquisarAmbiente(cpfCnpj) {

    $.ajax({
        url: '/Cadastros/ambienteByCpfCnpj?cpfCnpj=' + cpfCnpj,
        type: 'GET',
        dataType: 'json',
        success: function (json) {
            preencherCamposLocaisServico(json);
        }
    });

}

function preencherCamposPesquisaCpfCnpj(json) {

    if (json.codigo !== 0 && $("input[name=NomeOuRazaoSocial]").val() === '') {
        $("input[name=NomeOuRazaoSocial]").val(json.razaoSocial);
        $("input[name=Email]").val(json.emailResponsavel);
        $("input[name=Telefone]").val(json.emailResponsavel);
        $("input[name=WhatsApp]").val(json.emailResponsavel);
        $("input[name=CEP]").val(json.cep);
        $("input[name=Endereco]").val(json.endereco);
        $("input[name=Numero]").val(json.numero);
        $("input[name=Complemento]").val(json.complemento);
        $("input[name=Bairro]").val(json.bairro);
        $("input[name=Cidade]").val(json.cidade);
        $("#slcUF").val(json.uf);
        $("input[name=ResponsavelEmpresaNomeVE]").val(json.nomeRespEmpresa);
        $("input[name=ResponsavelEmpresaCPFVE]").val(json.cpfResponsavel);
        $("input[name=ResponsavelEmpresaTelefoneVE]").val(json.telResponsavel);
        $("input[name=ResponsavelEmpresaEmailVE]").val(json.emailResponsavel);
        $("input[name=NomeOuRazaoSocial]").focus();
    }
}

function preencherCamposLocaisServico(json) {

    if (json.codigo !== 0 && $("input[name=NomeEstab]").val() === '') {
        $("input[name=NomeEstab]").val(json.nomeEstabelecimento);
        $("input[name=CepEstab]").val(json.cep);
        $("input[name=EnderecoEstab]").val(json.endereco);
        $("input[name=NumeroEstab]").val(json.numero);
        $("input[name=ComplementoEstab]").val(json.complemento);
        $("input[name=BairroEstab]").val(json.bairro);
        $("input[name=CidadeEstab]").val(json.cidade);
        $("#slcUFEstab").val(json.uf);
        $("input[name=NomeOuRazaoSocial]").focus();
    }
}