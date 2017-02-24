var initTable1 = function () {

    var table = $('#productTable');
    // begin first table
    table.dataTable({

        // Internationalisation. For more info refer to http://datatables.net/manual/i18n
        "language": {
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            },
            "emptyTable": "Kayıt Bulunamadı",
            "info": "Gösterilen _START_ ile _END_ arasında toplam _TOTAL_ kayıt ",
            "infoEmpty": "Herhangi bir kayıt bulunamadı.",
            "infoFiltered": "(filtered1 from _MAX_ total records)",
            "lengthMenu": "Show _MENU_",
            "search": "Search:",
            "zeroRecords": "Eşleşen bir sonuç bulunamadı.",
            "paginate": {
                "previous": "Prev",
                "next": "Next",
                "last": "Last Page",
                "first": "First Page",
                "proccessing": "Loading"
            }
        },

        // Or you can use remote translation file
        //"language": {
        //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
        //},

        // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
        // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
        // So when dropdowns used the scrollable div should be removed. 
        //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",
        buttons: [{
            extend: 'collection',
            className: 'btn green  btn-outline dropdown-toggle',
            text: 'Tools',
            buttons: [
              { extend: "excel", className: "fa fa-file-excel-o" },
              { extend: "pdf", className: "fa fa-file-pdf-o" },
              { extend: "print", className: "fa fa-print" }
            ]
        }
        ],

        "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.
        "bProccessing": true,
        "sAjaxSource": "/Product/AjaxHandler",


        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"] // change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "pagingType": "bootstrap_full_number",
        "columnDefs": [
          {  // set default column settings
              'orderable': false,
              'searchable': false,
              'targets': [0],
              'render': function (data, type, row) {
                  return '<label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes" value="1" /><span></span></label>';
              }
          },

            {
                'orderable': false,
                'searchable': false,
                'targets': [5],
                'render': function (data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-xs green dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="false">Eylemler<i class="fa fa-angle-down"></i></button>'
                        + '<ul class="dropdown-menu" role="menu"><li><a href="/Product/Edit/' + row[0] + '"><i class="icon-note"></i> Düzenle</a></li><li><a href="/Product/Details/' + row[0] + '"><i class="icon-list"></i> Detaylar</a></li><li>'
                      + '<a href="/Product/Delete/' + row[0] + '" onclick="if (!confirm(\'Bu kaydı silmek istediğinize emin misiniz? Bu işlem geri alınamaz.\')) return false;"><i class="icon-ban"></i> Sil</a></li></ul></div>';
                }

            }

        ],
        "dom": "<'row' <'col-md-12'B>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",
        "order": [
            [1, "asc"]
        ] // set first column as a default sort by asc
    });

    var tableWrapper = jQuery('#productTable_wrapper');

    table.find('.group-checkable').change(function () {
        var set = jQuery(this).attr("data-set");
        var checked = jQuery(this).is(":checked");
        jQuery(set).each(function () {
            if (checked) {
                $(this).prop("checked", true);
                $(this).parents('tr').addClass("active");
            } else {
                $(this).prop("checked", false);
                $(this).parents('tr').removeClass("active");
            }
        });
    });

    table.on('change', 'tbody tr .checkboxes', function () {
        $(this).parents('tr').toggleClass("active");
    });
}