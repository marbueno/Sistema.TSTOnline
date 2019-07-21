Vue.config.devtools = true;

//Configuração VueValidation

const config = {
    locale: 'pt_BR'
};

Vue.use(VeeValidate, config);

Vue.use(VueMask.VueMaskPlugin);

var appMain = new Vue({
    el: '#appMain',
    data: {
        loadingVisible: false,
        newRegister: false,
        formName: '',
        tableName: '',
        tableData: null,
        tableColumns: null,
        tableOrder: null
    },
    methods: {

        showForm: function () {
            this.newRegister = true;
        },

        validateData: function (e, form) {

            form.$validator.validate().then(result => {

                e.preventDefault();
                //se passou em todas as validações
                if (result) {
                    this.loadingVisible = true;
                    $(this.formName).submit();
                }
            });
        },

        cancelForm: function (e) {

            this.newRegister = false;
            e.preventDefault();

            this.$nextTick(() => {
                //DOM rendered
                this.loadTable(this.tableName, this.tableData, this.tableColumns, this.tableOrder);
            });
        },

        showModal: function () {
            $('#divConfirmar').modal({
                keyboard: false,
                show: true,
                backdrop: 'static'
            });
        },

        loadTable: function (tableName, tableData, tableColumns, tableOrder) {

            this.tableName = tableName;
            this.tableData = tableData;
            this.tableColumns = tableColumns;
            this.tableOrder = tableOrder;

            try {
                $('#' + tableName).dataTable().fnClearTable();
                $('#' + tableName).dataTable().fnDestroy();

                $('#' + tableName).DataTable({
                    "lengthMenu": [[20, -1], [20, "All"]],

                    "language": {
                        "lengthMenu": "Visualizar _MENU_ por pagina",
                        "zeroRecords": "Nao ha registros",
                        "info": "Mostrando de _START_ ate _END_ | Total de _TOTAL_ registros",
                        "infoEmpty": "Nao ha registros",
                        "infoFiltered": "(Filtrados de _MAX_ Total de Registros)",
                        "loadingRecords": "Carregando...",
                        "processing": "Processando Dados...",
                        "thousands": ".",
                        "search": "Procurar:",
                        "paginate": {
                            "first": "Primeiro",
                            "last": "Ultimo",
                            "next": "Proximo",
                            "previous": "Anterior"
                        }
                    },

                    "data": tableData,

                    "columns": tableColumns,

                    "order": tableOrder
                });

                $('#' + tableName + ' tbody').on('click', 'tr', function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    }
                    else {
                        $('#' + tableName).DataTable().$('tr.selected').removeClass('selected');
                        $(this).addClass('selected');
                    }
                });

                $('.dataTables_filter input').addClass('form-control form-control-controls');
                $('.dataTables_length select').addClass('form-control form-control-controls');
            }
            catch (ex) {
                console.log('Erro ao carregar tabela: ' + ex.message);
            }
        }
    }
});

$(function () {
    $('#side-menu').metisMenu();
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
$(function () {
    $(window).bind("load resize", function () {
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.sidebar-collapse').addClass('collapse');
        } else {
            $('div.sidebar-collapse').removeClass('collapse');
        }
    });
});