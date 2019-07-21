var appLoadData = new Vue({
    data: {
        parametros: {},

        listAdversario: [],
        listAtleta: [],
        listEquipe: [],
        listPerfil: [],
        listPosicao: [],
        listQuadra: [],
        listTipoDespesaReceita: [],
        listControlePagamento: [],
        listMeses: []
    },
    methods: {

        carregarAdversarios: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListAdversario')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listAdversario.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarAtletas: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListAtleta')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listAtleta.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarControlePagamento: function () {

            return new Promise((resolve) => {

                fetch('/Controles/ListControlePagamento')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listControlePagamento.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarEquipes: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListEquipe')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listEquipe.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarParametros: function () {

            return new Promise((resolve) => {

                fetch('/Administracao/ListParametros')
                    .then(res => res.json())
                    .then(data => {
                        this.parametros = data;
                        resolve(true);
                    });
            });
        },

        carregarPerfis: function () {

            return new Promise((resolve) => {

                fetch('/Account/ListPerfil')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listPerfil.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarPosicao: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListPosicao')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listPosicao.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarQuadras: function () {

            return new Promise((resolve) => {

                fetch('/Cadastros/ListQuadra')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listQuadra.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarTipoDespesaReceita: function () {

            return new Promise((resolve) => {

                fetch('/Controles/ListTipoDespesaReceita')
                    .then(res => res.json())
                    .then(data => {
                        var iCount = 0;
                        data.forEach(item => { item.id = iCount; this.listTipoDespesaReceita.push(item); iCount++; });
                        resolve(true);
                    });
            });
        },

        carregarMeses: function () {

            return new Promise((resolve) => {

                fetch('/Utils/ListarMeses')
                    .then(res => res.json())
                    .then(data => {
                        data.forEach(item => { this.listMeses.push(item); });
                        resolve(true);
                    });
            });
        }
    }
});