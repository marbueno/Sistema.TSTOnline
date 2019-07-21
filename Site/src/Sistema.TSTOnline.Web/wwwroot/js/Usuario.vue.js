var appUsuario = new Vue({
    el: '#appUsuario',
    data: {
        Codigo: 0,
        Nome: '',
        Login: '',
        Email: '',
        Perfil: '',
        listUsuario: [],
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                { "data": "login" },
                { "data": "email" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appUsuario.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appUsuario.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ]
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            this.Login = '';
            this.Email = '';
            this.Perfil = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = this.listUsuario[id].codigo;
            this.Nome = this.listUsuario[id].nome;
            this.Login = this.listUsuario[id].login;
            this.Email = this.listUsuario[id].email;
            this.Perfil = this.listUsuario[id].perfil;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = this.listUsuario[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Account/UsuarioRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Account/Usuario';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmUsuario';
        appLoadData.carregarPerfis();
        fetch('/Account/ListUsuario')
            .then(res => res.json())
            .then(data => {
                var iCount = 0;
                data.forEach(item => { item.id = iCount; this.listUsuario.push(item); iCount++; });
                appMain.loadTable('tblUsuario', this.listUsuario, this.columns);
            });
    }
});