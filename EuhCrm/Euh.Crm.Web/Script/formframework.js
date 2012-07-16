/// <reference path="core.js" />
/// <reference path="messagebus.js" />
EuhCrm.bus.subscribe(EuhCrm.bus.messagetype.DocumentReady, initFormFramework);

function initFormFramework() {
    initToolpane();
    initCurrentFormComponents();
}

function initToolpane() {
    EuhCrm.bus.subscribe(EuhCrm.bus.messagetype.NotifyComponentSelect, function (componentInfo) {
        $("#ec-toolpane").html("ItemId: " + componentInfo.id + ", ItemType: " + componentInfo.type);
        
    });
}

function initCurrentFormComponents() {
    $("SPAN").each(function () {
        var $currentSpan = $(this);

        if (!$currentSpan.attr("itemid")) {
            return;
        }

        var itmid = $currentSpan.attr("itemid");
        var itmtype = $currentSpan.attr("itemtype");
        
        var currentSpan = this;

        $currentSpan.bind("click", function () {
            var data = {
                id: itmid,
                type: itmtype,
                DOM: currentSpan
            };
            
            EuhCrm.bus.publish(EuhCrm.bus.messagetype.NotifyComponentSelect, data);
        });
    });
}