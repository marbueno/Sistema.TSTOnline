var tableName = "";
var tableData = null;
var tableColumns = null;
var tableOrder = null;
var tableColumDefs = null;
var order = [[0, 'desc']];

function loadTable(tableName, tableData, tableColumns, tableOrder, tableColumDefs) {

    if (tableOrder === null || tableOrder === undefined) {
        tableOrder = this.order;
    }

    this.tableName = tableName;
    this.tableData = tableData;
    this.tableColumns = tableColumns;
    this.tableOrder = tableOrder;
    this.tableColumDefs = tableColumDefs;

    try {
        $('#' + tableName).dataTable().fnClearTable();
        $('#' + tableName).dataTable().fnDestroy();

        $('#' + tableName).DataTable({
            "lengthMenu": [[20, -1], [20, "All"]],

            "language": {
                "lengthMenu": "Exibição _MENU_ Registros por página",
                "zeroRecords": "Nada encontrado - desculpe",
                "info": " Mostrando página _PAGE_ ate _PAGES_",
                "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                "infoFiltered": "(filtrado de _MAX_ total linhas)",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "thousands": ".",
                "search": "Pesquisar:",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                }
            },

            "data": tableData,

            "columns": tableColumns,

            "columnDefs": tableColumDefs,

            "order": tableOrder
        });
    }
    catch (ex) {
        console.log('Erro ao carregar tabela: ' + ex.message);
    }
};

function formOnFail(error) {

    if (error.status === 500)
        showMessage("error", error.responseText);
}

function showMessage(type, msg) {

    toastr.options = {
        positionClass: "toast-top-right",
        showDuration: "300",
        hideDuration: "1000",
        newestOnTop: false,
        progressBar: false,
        showEasing: "swing",
        hideEasing: "linear",
        animation: true,
        width: "500px"
    };

    switch (type) {

        case "error":
            toastr.error(msg).css({
                width: "500px",
                "max-width": "500px"
            });
            break;

        case "warning":
            toastr.warning(msg).css({
                width: "500px",
                "max-width": "500px"
            });
            break;

        case "success":
            toastr.success(msg).css({
                width: "500px",
                "max-width": "500px"
            });
            break;

        default:
            toastr.info(msg).css({
                width: "500px",
                "max-width": "500px"
            });
            break;
    }
}