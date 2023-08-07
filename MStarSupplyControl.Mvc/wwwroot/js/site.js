$(document).ready(function () {
    getDataTable('#table-mercadorias');
})

function getDataTable(id) {
    $('#table-mercadorias').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

$(function () {
    // Função para carregar os cursos no select de cursos
    $.ajax({
        url: '/Gerenciamento/ObterMercadorias',
        type: 'GET',
        dataType: 'json',
        success: function (mercadorias) {
            var select = $('select[name="Mercadoria"]');
            select.empty();
            select.append($('<option>', { value: '', text: 'Selecione uma mercadoria' }));
            $.each(mercadorias, function (index, mercadoria) {
                select.append($('<option>', { value: mercadoria, text: mercadoria }));
            });
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});


/*Mascara para a data*/
$(document).ready(function () {
    $('#dataCampo').mask('99/99/9999');
});

/*Mascara para a hora*/
$(document).ready(function () {
    $('#horaCampo').mask('99:99');
});


/*Função para fechar a mensagem (Sucesso ou Erro)*/
$('.close-alert').click(function () {
    $('.alert').hide('hide');
});


/*Grafico Mensal*/