
Vue.component('date-picker', VueBootstrapDatetimePicker);

var appEquipe = new Vue({
    el: '#appEquipe',
    data: {
        Codigo: 0,
        Nome: '',
        Responsavel: '',
        DataFundacao: '',
        DDD1: '',
        Telefone1: '',
        DDD2: '',
        Telefone2: '',
        ComQuadra: false,
        Quadra: '',
        Horario: '',
        columns:
            [
                { "data": "codigo" },
                { "data": "nome" },
                { "data": "responsavel" },
                { "data": "dataFundacaoFormatada" },
                { "data": "ddD1" },
                { "data": "telefone1" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appEquipe.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appEquipe.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ],

        config: {
            format: 'DD/MM/YYYY',
            useCurrent: false,
            showClear: true,
            showClose: true,
            locale: 'pt-br'
        }
    },

    methods: {

        newRegister: function () {
            this.Codigo = 0;
            this.Nome = '';
            this.Responsavel = '';
            this.DataFundacao = '';
            this.DDD1 = '';
            this.Telefone1 = '';
            this.DDD2 = '';
            this.Telefone2 = '';
            this.ComQuadra = false;
            this.Quadra = '';
            this.Horario = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listEquipe[id].codigo;
            this.Nome = appLoadData.listEquipe[id].nome;
            this.Responsavel = appLoadData.listEquipe[id].responsavel;
            this.DataFundacao = appLoadData.listEquipe[id].dataFundacaoFormatada;
            this.DDD1 = appLoadData.listEquipe[id].ddD1;
            this.Telefone1 = appLoadData.listEquipe[id].telefone1;
            this.DDD2 = appLoadData.listEquipe[id].ddD2;
            this.Telefone2 = appLoadData.listEquipe[id].telefone2;
            this.ComQuadra = appLoadData.listEquipe[id].comQuadra;
            this.Quadra = appLoadData.listEquipe[id].quadra;
            this.Horario = appLoadData.listEquipe[id].horario;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listEquipe[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Cadastros/EquipeRemove/' + this.Codigo, { method: 'delete'})
                    .then(data =>
                    {
                        window.location.href = '/Admin/Cadastros/Equipe';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmEquipe';
        appLoadData.carregarQuadras();
        appLoadData.carregarEquipes()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblEquipe', appLoadData.listEquipe, this.columns);
                }
            });
    }
});