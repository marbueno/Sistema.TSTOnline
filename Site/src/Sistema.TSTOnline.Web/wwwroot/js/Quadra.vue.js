var appQuadra = new Vue({
    el: '#appQuadra',
    data: {
        Codigo: 0,
        Nome: '',
        Endereco: '',
        Numero: '',
        Bairro: '',
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                { "data": "endereco" },
                { "data": "numero" },
                { "data": "bairro" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appQuadra.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appQuadra.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            this.Endereco = '';
            this.Numero = '';
            this.Bairro = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listQuadra[id].codigo;
            this.Nome = appLoadData.listQuadra[id].nome;
            this.Endereco = appLoadData.listQuadra[id].endereco;
            this.Numero = appLoadData.listQuadra[id].numero;
            this.Bairro = appLoadData.listQuadra[id].bairro;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listQuadra[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Cadastros/QuadraRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Cadastros/Quadra';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmQuadra';
        appLoadData.carregarQuadras()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblQuadra', appLoadData.listQuadra, this.columns);
                }
            });
    }
});