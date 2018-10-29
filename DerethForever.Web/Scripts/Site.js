
Number.prototype.toHexStr = function () {
    return ('00000000' + this.toString(16)).substr(-16);
}

function rad2deg(num) {
    return num * 180.0 / Math.PI;
}
function deg2rad(num) {
    return num * Math.PI / 180.0;
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

// Quaternion <=> Yaw/Pitch/Roll
$.fn.quat = function () {
    function updateQuat(el, ypr) {
        var ew = el.find("input[name$='W']");
        var ex = el.find("input[name$='X']");
        var ey = el.find("input[name$='Y']");
        var ez = el.find("input[name$='Z']");

        var ey0 = ypr.find(".yaw");
        var ep0 = ypr.find(".pitch");
        var er0 = ypr.find(".roll");

        var w = ew.val();
        var x = ex.val();
        var y = ey.val();
        var z = ez.val();
        var y0 = deg2rad(ey0.val());
        var p0 = deg2rad(ep0.val());
        var r0 = deg2rad(er0.val());

        var cy = Math.cos(y0 * 0.5);
        var sy = Math.sin(y0 * 0.5);
        var cr = Math.cos(r0 * 0.5);
        var sr = Math.sin(r0 * 0.5);
        var cp = Math.cos(p0 * 0.5);
        var sp = Math.sin(p0 * 0.5);

        w = cy * cr * cp + sy * sr * sp;
        x = cy * sr * cp - sy * cr * sp;
        y = cy * cr * sp + sy * sr * cp;
        z = sy * cr * cp - cy * sr * sp;
        ew.val(w);
        ex.val(x);
        ey.val(y);
        ez.val(z);

    }

    function updateYpr(el, ypr) {
        var ew = el.find("input[name$='W']");
        var ex = el.find("input[name$='X']");
        var ey = el.find("input[name$='Y']");
        var ez = el.find("input[name$='Z']");

        var ey0 = ypr.find(".yaw");
        var ep0 = ypr.find(".pitch");
        var er0 = ypr.find(".roll");

        var w = ew.val();
        var x = ex.val();
        var y = ey.val();
        var z = ez.val();
        var y0 = ey0.val();
        var p0 = ep0.val();
        var r0 = er0.val();

        // roll (x)
        var sr_cp = 2.0 * (w * x + y * z);
        var cr_cp = 1.0 - 2.0 * (x * x + y * y);
        r0 = Math.atan2(sr_cp, cr_cp);

        // pitch (y)
        var sp = 2.0 * (w * y - z * x);
        sp = (sp > 1) ? 1 : ((sp < -1) ? -1 : sp);
        p0 = Math.asin(sp);

        // yaw (z)
        var sy_cp = 2.0 * (w * z + x * y);
        var cy_cp = 1.0 - 2.0 * (y * y + z * z);
        y0 = Math.atan2(sy_cp, cy_cp);

        ey0.val(rad2deg(y0));
        ep0.val(rad2deg(p0));
        er0.val(rad2deg(r0));
    }

    this.each(function (idx, el) {
        var $el = $(el);

        var ypr = $(
            '<div class="row row-spacer">' +
            '<div class="col-md-2"><label>Yaw/Pitch/Roll</label></div>' +
            '<div class="col-md-2"><div class="input-group"><span class="input-group-addon">Yaw</span><input class="form-control yaw" type="text" value="0" /></div></div>' +
            '<div class="col-md-2"><div class="input-group"><span class="input-group-addon">Pitch</span><input class="form-control pitch" type="text" value="0" /></div></div>' +
            '<div class="col-md-2"><div class="input-group"><span class="input-group-addon">Roll</span><input class="form-control roll" type="text" value="0" /></div></div>' +
            '</div>');
        ypr.insertAfter($el);

        $el.find("input[name$='W']").change(function () {
            updateYpr($el, ypr);
        });
        $el.find("input[name$='X']").change(function () {
            updateYpr($el, ypr);
        });
        $el.find("input[name$='Y']").change(function () {
            updateYpr($el, ypr);
        });
        $el.find("input[name$='Z']").change(function () {
            updateYpr($el, ypr);
        });


        ypr.find(".yaw").change(function () {
            updateQuat($el, ypr);
        });
        ypr.find(".pitch").change(function () {
            updateQuat($el, ypr);
        });
        ypr.find(".roll").change(function () {
            updateQuat($el, ypr);
        });

        updateYpr($el, ypr);

    });

    return this;
};


$(function () {
    $('.quat').quat();

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