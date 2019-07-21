var appAdversario = new Vue({
    el: '#appAdversario',
    data: {
        Codigo: 0,
        Nome: '',
        Responsavel: '',
        DDD1: '',
        Telefone1: '',
        DDD2: '',
        Telefone2: '',
        ComQuadra: false,
        Quadra: '',
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                { "data": "responsavel" },
                { "data": "ddD1" },
                { "data": "telefone1" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appAdversario.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appAdversario.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            this.Responsavel = '';
            this.DDD1 = '';
            this.Telefone1 = '';
            this.DDD2 = '';
            this.Telefone2 = '';
            this.ComQuadra = false;
            this.Quadra = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listAdversario[id].codigo;
            this.Nome = appLoadData.listAdversario[id].nome;
            this.Responsavel = appLoadData.listAdversario[id].responsavel;
            this.DDD1 = appLoadData.listAdversario[id].ddD1;
            this.Telefone1 = appLoadData.listAdversario[id].telefone1;
            this.DDD2 = appLoadData.listAdversario[id].ddD2;
            this.Telefone2 = appLoadData.listAdversario[id].telefone2;
            this.ComQuadra = appLoadData.listAdversario[id].comQuadra;
            this.Quadra = appLoadData.listAdversario[id].quadra;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listAdversario[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Cadastros/AdversarioRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Cadastros/Adversario';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmAdversario';
        appLoadData.carregarQuadras();
        appLoadData.carregarAdversarios()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblAdversario', appLoadData.listAdversario, this.columns);
                }
            });
    }
});