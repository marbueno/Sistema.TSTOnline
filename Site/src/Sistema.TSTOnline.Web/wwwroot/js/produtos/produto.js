var codigo = 0;
var columns = [
    { "data": "idProduto" },
    //{ "data": "sku" },
    { "data": "nome" },
    { "data": "fornecedorRazaoSocial" },
    { "data": "categoriaDescricao" },
    {
        "mDataProp": "preco",
        mRender: function (data, type, row) {

            var preco = "R$ " + accounting.formatMoney(row.preco, "", 2, ".", ",");

            return preco;
        }
    },
    {
        "mDataProp": "Editar",
        mRender: function (data, type, row) {
            return "<a class='btn btn-primary btn-sm' href='#' onclick='editRegister(" + row.idProduto + ")' title='Editar'>Editar</a>";
        }
    },
    {
        "mDataProp": "Excluir",
        mRender: function (data, type, row) {
            return "<a class='btn btn-danger btn-sm' href='#' data-toggle='modal' data-target='#divConfirmar_0' onclick='codigo=" + row.idProduto + "' title='Excluir'>Excluir</a>";
        }
    }
];

function editRegister(id) {
    window.location = '/produtos/produtoAddEdit/' + id;
}

function deleteRegister () {
    if (codigo !== 0) {

        fetch('/produtos/produtoDelete/' + codigo, { method: 'delete' })
            .then(() =>
            {
                window.location.reload();
            });
    }
}

$(document).ready(function () {
    carregarProdutos().then(dataLoaded => {
        if (dataLoaded) {
            loadTable('tblProduto', listProdutos, columns);
        }
    });
});


$("#frmProduto").submit(function (event) {

    event.preventDefault();

    debugger;

    var json = $(this).serializeObject();

    var preco = json.Preco.toString().replace('.', '').replace(',', '.');

    var produto = {
        "idProduto": json.IDProduto === "" ? 0 : parseInt(json.IDProduto),
        //"sku": json.sku,
        "nome": json.Nome,
        "descricao": json.Descricao,
        "idFornecedor": json.idFornecedor,
        "idCategoria": json.idCategoria,
        "idSubCategoria": json.idSubCategoria,
        "preco": preco
    };

    fetch('/produtos/produtoCreateOrUpdate',
        {
            method: 'post',

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(produto)
        })
        .then(response => {
            if (response.status === 200) {

                showMessage("success", "Produto Salvo com sucesso");

                window.location = '/produtos/produto';
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