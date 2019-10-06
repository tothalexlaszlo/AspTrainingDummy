/* Kliens oldal fejlesztése Web Apihoz */

//$ == jQuery $-ral hívom meg a jquery könyvtárat és érem el a függvényeit
function sendAjaxRequest(httpMethod, url, callback, content) {
    $.ajax( 
        "/api/categories" + (url ? "/" + url : ""),
        {
            type: httpMethod,
            success: callback,
            data: content
        });
}

// ko == knockout object a knockoutban lévő függvényeket ezen keresztűl érem el  | DataBinding -> a felületen lévő objektum össze van kötve a memóriában lévővel, frissítik egymást
var model = {
    categories: ko.observableArray(),
    displaySummary: ko.observable(true),
    newCategory: {
        categoryName: ko.observable(""),
        description: ko.observable("")
    }
}

function hideSummary() {
    model.displaySummary(false);
}

function showSummary() {
    model.displaySummary(true);
}

// a js ugy mukodik ha nem adok meg parametert akkor automatikusan null-nak tekinti
function getCategories() {
    sendAjaxRequest("GET", "", function (response) {
        model.categories.removeAll();
        for (var i = 0; i < response.length; i++) {
            model.categories.push(response[i]);
        }
    });
}

// elmegyek a szerverre, a szerver visszajelez, hogy kitörölt, én kitörlöm a felületről
function deleteCategory(category) {
    sendAjaxRequest("DELETE", category.CategoryId, function (response) {
        for (var i = 0; i < model.categories().length; i++) {
            if (model.categories()[i].CategoryId == category.CategoryId) {
                model.categories.remove(model.categories()[i]);
            }
        }
    });
}

// category létrehozása, nincs inputja mert már benne van a modelban és onnan fogja kiolvasni
function createCategory() {
    sendAjaxRequest("POST", "", function (response) {
        model.categories.push(response);
        showSummary();
    },
    {
        CategoryName: model.newCategory.categoryName,
        Description: model.newCategory.categoryName
    });
}

$(document).ready(function () {
    getCategories();
    ko.applyBindings(model);
})