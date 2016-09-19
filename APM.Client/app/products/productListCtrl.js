(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                       ["productResource",
                           ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.searchCriteria = "GDN";

        //cool stuff here with Odata querys
        //what am doing here, am skipping the first entry, then picking up the first top 3 entries from my list
        //{$skip:1, $top:4}
        productResource.query( function (data) {
            vm.products = data;
        });
    }

}());