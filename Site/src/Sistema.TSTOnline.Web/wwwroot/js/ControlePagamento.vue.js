Vue.component('date-picker', VueBootstrapDatetimePicker);

var appControlePagamento = new Vue({
    el: '#appControlePagamento',
    data: {
        Codigo: 0,
        Atleta: 0,
        DataPagto: '',
        ValorPago: '',
        MesReferencia: 0,
        columns:
            [
                { "data": "codigo" },
                { "data": "nomeAtleta" },
                { "data": "dataPagtoFormatada" },
                { "data": "valorPagoFormatado" },
                { "data": "mesReferenciaDescricao" },
                {
                    "mDataProp": "Editar",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appControlePagamento.editRegister(" + row.id + ")' title='Editar'>Editar</a>";
                    }
                },
                {
                    "mDataProp": "Excluir",
                    mRender: function (data, type, row) {
                        return "<a href='#' onclick='appControlePagamento.deleteRegister(" + row.id + ", false)' title='Excluir'>Excluir</a>";
                    }
                }
            ],

        order: [[0, 'desc']],

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
            this.Atleta = 0;
            this.DataPagto = '';
            this.ValorPago = '';
            this.MesReferencia = '';
            appMain.showForm();
        },

        editRegister: function (id) {
            this.Codigo = appLoadData.listControlePagamento[id].codigo;
            this.Atleta = appLoadData.listControlePagamento[id].atleta;
            this.DataPagto = appLoadData.listControlePagamento[id].dataPagtoFormatada;
            this.ValorPago = appLoadData.listControlePagamento[id].valorPago;
            this.MesReferencia = appLoadData.listControlePagamento[id].mesReferencia;
            appMain.showForm();
        },

        deleteRegister: function (id, confirmed) {
            if (confirmed === false) {
                this.Codigo = appLoadData.listControlePagamento[id].codigo;
                appMain.showModal();
            }
            else {
                appMain.loadingVisible = true;
                fetch('/Controles/ControlePagamentoRemove/' + this.Codigo, { method: 'delete'})
                    .then(() =>
                    {
                        window.location.href = '/Admin/Controles/ControlePagamento';
                    });
            }
        }
    },

    mounted() {

        appMain.formName = '#frmControlePagamento';
        appLoadData.carregarMeses();
        appLoadData.carregarAtletas();
        appLoadData.carregarControlePagamento()
            .then(dataLoaded => {
                if (dataLoaded) {
                    appMain.loadTable('tblControlePagamento', appLoadData.listControlePagamento, this.columns, this.order);
                }
            });
    }
});