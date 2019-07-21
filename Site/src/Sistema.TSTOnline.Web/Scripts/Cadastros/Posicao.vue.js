var appPosicao = new Vue({
    el: '#appPosicao',
    data: {
        Codigo: 0,
        Descricao: '',
        Goleiro: false,
        Tecnico: false,
        columns:
            [
                { "data": "codigo" },
                { "data": "descricao" },                {
                    "mDataProp": "goleiro",                    mRender: function (data, type, row) {
                        var checked = "";                        if (data === true)                            checked = "checked='checked'";                        return "<input class='form-control' type='checkbox' " + checked + " disabled style='height:30px; width:40px; margin-left:10px;'>";
                    }
                },                {
                    "mDataProp": "tecnico",                    mRender: function (data, type, row) {
                        var checked = "";                        if (data === true)                            checked = "checked='checked'";                        return "<input class='form-control' type='checkbox' " + checked + " disabled style='height:30px; width:40px; margin-left:10px;'>";
                    }
                },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPosicao.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPosicao.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Descricao = '';
            this.Goleiro = false;
            this.Tecnico = false;
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listPosicao[id].codigo;
            this.Descricao = appLoadData.listPosicao[id].descricao;
            this.Goleiro = appLoadData.listPosicao[id].goleiro;
            this.Tecnico = appLoadData.listPosicao[id].tecnico;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listPosicao[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Cadastros/PosicaoRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Cadastros/Posicao';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmPosicao';
        appLoadData.carregarPosicao()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblPosicao', appLoadData.listPosicao, this.columns);
                }
            });
    }
});