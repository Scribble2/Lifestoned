
Number.prototype.toHexStr = function () {
    return ('00000000' + this.toString(16)).substr(-16);
}

function displayWeenie(item) {
    return `(${item.WeenieClassId}) ${item.Name}`;
}

function findWeenie(data, callback) {
    $.post('/Weenie/WeenieFinder', data,
        function (data, status, xhr) {
            callback(data, status, xhr);
        }
    );
}

$(function () {
    $('input.weenie-select').each(function (idx, el) {
        var $el = $(el);
        var display = $el.clone();
        $el.prop('type', 'hidden');
        display.removeAttr('id').removeAttr('name').addClass('typeahead');
        display.prop('autocomplete', 'off').data('provide', 'typeahead');
        display.insertBefore($el);

        var id = $el.val();
        if (id) {
            findWeenie({ WeenieClassId: id },
                function (data, status, xhr) {
                    if (data) {
                        display.val(displayWeenie(data[0]));
                    }
                });
        }

        display.typeahead({
            displayText: function (item) {
                return displayWeenie(item);
            },
            afterSelect: function (item) {
                $el.val(item.WeenieClassId);
            },
            source: function (val, cb) {
                findWeenie({ PartialName: val },
                    function (data, status, xhr) {
                        cb(data);
                    }
                );
            }
        });

    });
});