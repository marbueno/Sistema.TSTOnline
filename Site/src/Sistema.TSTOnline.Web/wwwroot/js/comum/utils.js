function dateToPT(date) {
    var data = date.split('T')[0];
    return data.split('-').reverse().join('/');
}; 

function filterValuePart(arr, part) {
    return arr.filter(function (obj) {
        return Object.keys(obj)
            .some(function (k) {
                return obj[k].toString().indexOf(part) !== -1;
            });
    });
};

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};