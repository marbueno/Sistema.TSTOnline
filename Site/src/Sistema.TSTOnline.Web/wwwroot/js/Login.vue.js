//import de biblioteca de validação e mask
Vue.use(VeeValidate);

//funcionalidades formulario Dados da Empresa (validations)
var appLogin = new Vue({
    el: '#appLogin',
    data: {
        Login: '',
        Senha: ''
    },
    methods: {
        validarDados: function (e) {

            this.$validator.localize('pt_BR');

            this.$validator.validate().then(result => {

                e.preventDefault();
                //se passou em todas as validações
                if (result) {
                    appMain.loadingVisible = true;
                    $("#frmLogin").submit();
                }
            });
        }
    }
});
