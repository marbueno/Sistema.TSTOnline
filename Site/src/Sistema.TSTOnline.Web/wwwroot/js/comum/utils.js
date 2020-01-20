function dateToPT(date) {
    var data = date.split('T')[0];
    return data.split('-').reverse().join('/');
}; 

function filterValuePart(arr, part) {
    return arr.filter(function (obj) {
        return Object.keys(obj)
            .some(function (k) {
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
            console.log(json);
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