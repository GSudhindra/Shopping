﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

// ************************************
// Create a Closure
// ************************************
var mainController = (function () {
    // ************************************
    // Private Functions
    // ************************************
    function pleaseWait() {
        $("#pleaseWait").removeClass("d-none");
        $("header").addClass("pleaseWaitArea");
        $("main").addClass("pleaseWaitArea");
        $("footer").addClass("pleaseWaitArea");
    }

    // ************************************
    // Public Functions
    // ************************************
    return {
        "pleaseWait": pleaseWait
    }
})();
