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
                cancelButton = "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar' onclick='codigo=" + row.idOrdemServico + "' title='Cancelar O.S.'>Cancelar</a>";

            return cancelButton;
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

$(document).ready(function () {
    carregarOrdemServicos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblOrdemServico', listOrdemServicos, columns);
        }
    });
});


$("#frmOrdemServico").submit(function (event) {
    debugger;
    event.preventDefault();
    var json = $(this).serializeObject();

    var ordemServico = {
        "idOrdemServico": json.IDOrdemServico === "" ? 0 : parseInt(json.IDOrdemServico),
        "dataServico": json.DataServico,
        "idResp": json.idResp,
        "idLocal": json.idLocal,
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
        })
        .catch(ex => {
            console.log(ex);
        });
});
