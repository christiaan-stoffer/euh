
/* Message bus */
EuhCrm = {
    bus: {
        _subscribers: [],
        publish: function(type, msg) {
            if (!this._subscribers[type]) {
                return;
            }

            for (var i in this._subscribers[type]) {
                this._subscribers[type][i](msg);
            }
        },
        subscribe: function(type, handler) {
            if (!this._subscribers[type]) {
                this._subscribers[type] = [];
            }
            this._subscribers[type].push(handler);
        },
        messagetype: {
            DocumentReady: "doc_ready",
            NotifyComponentSelect: "notify_comp_select"
        }
    }
};

/// <reference path="~/Script/messagebus.js" />
/* Core */
$(function () {
    EuhCrm.bus.publish(EuhCrm.bus.messagetype.DocumentReady, null);
});

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
        
        $(componentInfo.DOM).find("input").val("FUCK JEY!");
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
