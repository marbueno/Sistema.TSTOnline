var appProfile = new Vue({
    el: '#appProfile',
    data: {
        Email: '',
        Nome: '',
        Perfil: ''
    },

    mounted() {

        appMain.formName = '#frmProfile';
        appLoadData.carregarPerfis();
    }
});
