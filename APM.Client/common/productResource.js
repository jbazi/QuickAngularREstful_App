﻿(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource",
                    ["$resource",
                        "appSettings",
                            productResource])

    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/product/:id", null, {
            'update':{method:'PUT'}
        }); //:id here donates optional
    }


}());