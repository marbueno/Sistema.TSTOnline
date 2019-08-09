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
}