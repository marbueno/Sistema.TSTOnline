var appParametros = new Vue({
    el: '#appParametros',
    data: {
        Codigo: 0,
        EsconderValorPagamentoSumula: false,
        CaminhoFotos: '',
        TamanhoFotos: '',
        ExtensaoFotos: '',
        CaminhoFotosAtletas: '',
        TamanhoAlturaFotos: '',
        TamanhoLarguraFotos: '',
        TipoReceita: ''
    },

    mounted() {

        appMain.formName = '#frmParametros';
        appLoadData.carregarTipoDespesaReceita();
        appLoadData.carregarParametros()
            .then(dataLoaded => {
                if (dataLoaded) {
                    this.Codigo = appLoadData.parametros.codigo;
                    this.EsconderValorPagamentoSumula = appLoadData.parametros.esconderValorPagamentoSumula;
                    this.CaminhoFotos = appLoadData.parametros.caminhoFotos;
                    this.TamanhoFotos = appLoadData.parametros.tamanhoFotos;
                    this.ExtensaoFotos = appLoadData.parametros.extensaoFotos;
                    this.CaminhoFotosAtletas = appLoadData.parametros.caminhoFotosAtletas;
                    this.TamanhoAlturaFotos = appLoadData.parametros.tamanhoAlturaFotos;
                    this.TamanhoLarguraFotos = appLoadData.parametros.tamanhoLarguraFotos;
                    this.TipoReceita = appLoadData.parametros.tipoReceita;
                }
            });
    }
});
