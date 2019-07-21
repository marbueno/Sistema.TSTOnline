var appPerfil = new Vue({
    el: '#appPerfil',
    data: {
        Codigo: 0,
        Nome: '',
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPerfil.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appPerfil.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listPerfil[id].codigo;
            this.Nome = appLoadData.listPerfil[id].nome;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listPerfil[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Account/PerfilRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Account/Perfil';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmPerfil';
        appLoadData.carregarPerfis()
            .then(dataLoaded =>
            {
                if (dataLoaded) {
                    appMain.loadTable('tblPerfil', appLoadData.listPerfil, this.columns);
                }
            });
    }
});