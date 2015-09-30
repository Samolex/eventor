$(document).ready(function () {
    
    var tabsChanged = function(event) {
        
        var hash = window.location.hash;
        if (hash) {
        
            // Show/Hide Tabs
            console.log(hash);
            $('.tabs ' + hash).show().siblings().hide();

            var currentClass = hash.replace('#', '.');
            console.log(currentClass);
            $('.tabs .tab-links ' + currentClass).addClass('active').siblings().removeClass('active');
        }
    }
    tabsChanged();
    window.addEventListener('hashchange', tabsChanged, false);
    $('.datepicker').datepicker({
        format: "dd/mm/yyyy",
        startDate: "+0d",
        language: "ru",
        autoclose: true
    });

    

});
