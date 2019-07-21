var appTipoDespesaReceita = new Vue({
    el: '#appTipoDespesaReceita',
    data: {
        Codigo: 0,
        Descricao: '',
        TipoDespesaReceita: '',
        columns:
            [
                { "data": "codigo" },
                { "data": "descricao" },
                { "data": "tipoDespesaReceita" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appTipoDespesaReceita.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appTipoDespesaReceita.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Descricao = '';
            this.TipoDespesaReceita = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listTipoDespesaReceita[id].codigo;
            this.Descricao = appLoadData.listTipoDespesaReceita[id].descricao;
            this.TipoDespesaReceita = appLoadData.listTipoDespesaReceita[id].tipoDespesaReceita;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listTipoDespesaReceita[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Controles/TipoDespesaReceitaRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Controles/TipoDespesaReceita';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmTipoDespesaReceita';
        appLoadData.carregarTipoDespesaReceita()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblTipoDespesaReceita', appLoadData.listTipoDespesaReceita, this.columns);
                }
            });
    }
});