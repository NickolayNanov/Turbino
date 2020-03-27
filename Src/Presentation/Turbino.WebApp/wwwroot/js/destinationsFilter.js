'use strict';

let filterObject = null;

function submitFilterDestinations() {
    let searchQuery = getInputValueById("inputEmail3");
    //let month = getInputValueById("inlineFormInputName32");
    //let tourType = getInputValueById("inlineFormInputName1");
    //let sortOrder = getInputValueById("inlineFormInputName4");
    //let first = document.getElementsByClassName('ui-slider-handle');
    //let amount = getInputValueById('amount');
    //let min = amount.split(' - ');
    //let minValue = min[0].substr(1);
    //let maxValue = min[1].substr(1);

    let body = {
        searchQuery: searchQuery
        //month: month,   
        //tourType: tourType,
        //sortOrder: sortOrder,
        //minPrice: Number.parseFloat(minValue),
        //maxPrice: Number.parseFloat(maxValue)
    };

    filterObject = body;
    doAjax("Destination/Filter?searchQuery=" + searchQuery);
}

function getInputValueById(id) {
    let element = document.getElementById(id);
    return element.value;
}

function doAjax(url) {
    fetch(url)
        .then(r => console.log(r));
}
