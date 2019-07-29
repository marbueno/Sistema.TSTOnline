var formName = "";
var tableName = "";
var tableData = null;
var tableColumns = null;
var tableOrder = null;
var order = [[0, 'desc']];

function loadTable (tableName, tableData, tableColumns, tableOrder) {

    if (tableOrder === null || tableOrder === undefined) {
        tableOrder = this.order;
    }

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

            "order": tableOrder
        });
    }
    catch (ex) {
        console.log('Erro ao carregar tabela: ' + ex.message);
    }
};
