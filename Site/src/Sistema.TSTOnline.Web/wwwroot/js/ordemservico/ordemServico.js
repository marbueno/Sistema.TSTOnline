var codigo = 0;
var columns = [
    { "data": "idOrdemServico" },
    {
        "data": "dataCadastro",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    {
        "data": "dataServico",
        "render": function (data, type, row) {
            return dateToPT(data);
        }
    },
    { "data": "statusDescricao" },
    { "data": "razaoSocial" },
    { "data": "responsavelNome" },
    { "data": "localDescricao" },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {

            var editButton = "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idOrdemServico + ")' title='Editar'>Editar</a>";

            if (row.status === 4 || row.status === 5)
                editButton = "";

            return editButton;
        }
    },
    {
        "mDataProp": "Cancelar",
        mRender: function (data, type, row) {
            var cancelButton = "";

            if (row.status !== 5)
                cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_1' onclick='codigo=" + row.idOrdemServico + "' title='Cancelar O.S.'>Cancelar</a>";

            return cancelButton;
        }
    },
    {
        "mDataProp": "ImprimirOS",
        mRender: function (data, type, row) {

            return "<a class='btn btn-primary btn-sm' href='#' onclick='imprimirOS(" + row.idOrdemServico + ")' title='Clique para Imprimir a O.S.'>Imprimir O.S.</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/ordemservico/ordemServicoAddEdit/' + id;
}

function cancelRegister () {
    if (codigo !== 0) {

        fetch('/ordemservico/alterarStatus/' + codigo + '/5', { method: 'put' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

function imprimirOS(id) {

    try {
        window.open('/ordemservico/imprimir/' + id, '_blank');
    }
    catch (ex) {
        console.log(ex);
        showMessage("error", ex);
    }
}


$(document).ready(function () {
    carregarOrdemServicos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblOrdemServico', listOrdemServicos, columns);
        }
    });
});

$("#chkClienteSemCadastro").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#divClienteComCadastroCliente").css("display", "none");
        $("#divClienteComCadastroLocalServico").css("display", "none");
        $("#divClienteSemCadastro").css("display", "");
    }
    else {
        $("#divClienteComCadastroCliente").css("display", "");
        $("#divClienteComCadastroLocalServico").css("display", "");
        $("#divClienteSemCadastro").css("display", "none");
    }
});

$("#SC_PF").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#SC_CPF").css("display", "");
        $("#SC_CNPJ").css("display", "none");
    }
});

$("#SC_PJ").change(function () {

    var checked = $(this)[0].checked;

    if (checked) {
        $("#SC_CPF").css("display", "none");
        $("#SC_CNPJ").css("display", "");
    }
});


$("#frmOrdemServico").submit(function (event) {

    event.preventDefault();
    var json = $(this).serializeObject();

    var osExpress = false;

    if ($("#chkClienteSemCadastro")[0] !== undefined && $("#chkClienteSemCadastro")[0] !== null) {
        osExpress = $("#chkClienteSemCadastro")[0].checked;
    }

    var tipoPessoa = 1;

    if ($("#SC_PJ")[0] !== undefined && $("#SC_PJ")[0] !== null) {
        if ($("#SC_PJ")[0].checked)
            tipoPessoa = 2;
    }

    var uf = $("#slcUF option:selected").val();

    var ufEstab = $("#slcUFEstab option:selected").val();

    var ordemServico = {
        "idOrdemServico": json.IDOrdemServico === "" ? 0 : parseInt(json.IDOrdemServico),
        "dataServico": json.DataServico,
        "horarioServico": json.HorarioServico,
        "idResp": json.idResp,
        "idLocal": json.idLocal,

        "osExpress": osExpress,
        "idEmpresa": json.idEmpresa,

        "tipoPessoa": tipoPessoa,
        "cpf": json.CPF,
        "cnpj": json.CNPJ,
        "nomeOuRazaoSocial": json.NomeOuRazaoSocial,
        "email": json.Email,
        "cep": json.CEP,
        "endereco": json.Endereco,
        "numero": json.Numero,
        "complemento": json.Complemento,
        "bairro": json.Bairro,
        "cidade": json.Cidade,
        "uf": uf,
        "telefoneOE": json.TelefoneOE,
        "whatsAppOE": json.WhatsAppOE,

        "nomeEstab": json.NomeEstab,
        "cepEstab": json.CepEstab,
        "enderecoEstab": json.EnderecoEstab,
        "numeroEstab": json.NumeroEstab,
        "complementoEstab": json.ComplementoEstab,
        "bairroEstab": json.BairroEstab,
        "cidadeEstab": json.CidadeEstab,
        "ufEstab": ufEstab,

        "nomeContato": json.NomeContato,
        "telefone": json.Telefone,
        "whatsApp": json.WhatsApp,
        "ordemServicoItens": listOrdemServicoItens
    };

    fetch('/ordemservico/ordemServicoCreateOrUpdate',
        {
            method: 'post',

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(ordemServico)
        })
        .then(response => {
            if (response.status === 200) {
                window.location = '/ordemservico/ordemServico';
            }
            else if (response.status === 500) {
                return response.text();
            }
        })
        .then(response => {
            showMessage("error", response);
        })
        .catch(error => {
            console.log(error);
            showMessage("error", error);
        });
});
